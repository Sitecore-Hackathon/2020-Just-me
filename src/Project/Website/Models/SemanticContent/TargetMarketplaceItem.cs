using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Constellation.Foundation.ModelMapping.MappingAttributes;
using Sitecore.ContentSearch.Extracters.IFilterTextExtraction;
using Website.Models.Navigation;

namespace Website.Models.SemanticContent
{
    public class TargetMarketplaceItem : TargetItem
    {
        [RawValueOnly]
        public string Name { get; set; }

        [RawValueOnly]
        public string FileUrl { get; set; }
    }
}