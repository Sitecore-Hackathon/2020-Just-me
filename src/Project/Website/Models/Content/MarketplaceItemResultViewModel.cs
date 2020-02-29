using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Constellation.Foundation.ModelMapping.MappingAttributes;
using Website.Models.SemanticContent;

namespace Website.Models.Content
{
    public class MarketplaceItemResultViewModel
    {
        [DoNotMap]
        public ICollection<TargetMarketplaceItem> Items { get; set; }
    }
}