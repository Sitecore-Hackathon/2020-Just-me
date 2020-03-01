using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Constellation.Foundation.ModelMapping;
using Constellation.Foundation.Mvc.Patterns.Repositories;
using Sitecore.Data;
using Website.Constants;
using Website.Models.SemanticContent;


namespace Website.Repositories
{
    public class MarketplaceItemRepository : IRepository
    {
        protected IModelMapper ModelMapper { get; set; }

        public MarketplaceItemRepository(IModelMapper modelMapper)
        {
            ModelMapper = modelMapper;
        }

        public ICollection<TargetMarketplaceItem> GetAll()
        {
            var item = Sitecore.Context.Database.Items[Sitecore.Context.Site.StartPath];
            return item.GetChildren()
                .Where(i => i.TemplateID == new ID(SitecoreTemplateConstants.MARKETPLACE_ITEM_PAGE_TEMPLATE_ID))
                .Select(i => ModelMapper.MapItemToNew<TargetMarketplaceItem>(i))
                .ToList();
        }
    }
}