﻿namespace Examine.LuceneEngine.Faceting
{
    public struct FacetLevel : IFacetLevel
    {
        public int FacetId;

        public float Level;


        
        FacetLevel IFacetLevel.ToFacetLevel(FacetMap map)
        {
            return this;
        }
    }
}