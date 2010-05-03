﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml.Linq;
using umbraco.cms.businesslogic.media;

namespace UmbracoExamine.DataServices
{

    /// <summary>
    /// Data service used to query for media
    /// </summary>
    public class UmbracoMediaService : UmbracoExamine.DataServices.IMediaService
    {

        /// <summary>
        /// This is quite an intensive operation...
        /// get all root media, then get the XML structure for all children,
        /// then run xpath against the navigator that's created
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public XDocument GetLatestMediaByXpath(string xpath)
        {

            Media[] rootMedia = Media.GetRootMedias();
            var xmlMedia = XDocument.Parse("<media></media>");
            foreach (Media media in rootMedia)
            {
                xmlMedia.Root.Add(GetMediaItem(media.Id));
            }
            var umbXml = (XPathNodeIterator)xmlMedia.CreateNavigator().Evaluate(xpath);
            return umbXml.ToXDocument();
        }

        private XElement GetMediaItem(int nodeId)
        {
            var nodes = umbraco.library.GetMedia(nodeId, true);
            return XElement.Parse(nodes.Current.OuterXml);
        }
        

    }
}
