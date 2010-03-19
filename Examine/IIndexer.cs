﻿using System.Xml.Linq;

namespace Examine
{
    public interface IIndexer
    {
        /// <summary>
        /// Forces a particular XML node to be reindexed
        /// </summary>
        /// <param name="node">XML node to reindex</param>
        /// <param name="type">Type of index to use</param>
        void ReIndexNode(XElement node, IndexType type);
        /// <summary>
        /// Deletes a node from the index
        /// </summary>
        /// <param name="node">Node to delete</param>
        void DeleteFromIndex(XElement node);
        
        /// <summary>
        /// Re-indexes all data for the index type specified
        /// </summary>
        /// <param name="type"></param>
        void IndexAll(IndexType type);

        /// <summary>
        /// Rebuilds the entire index from scratch for all index types
        /// </summary>
        void RebuildIndex();

        IIndexCriteria IndexerData { get; set; }

    }
}
