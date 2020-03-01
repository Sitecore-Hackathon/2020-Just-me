using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Constellation.Foundation.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Framework.Commands.ContentEditor.Validators;
using Website.Models.Content;
using Website.Repositories;

namespace Website.Controllers.Content
{
    public class MarketplaceItemResultController : ConventionController
    {

        public MarketplaceItemRepository MarketplaceItemRepository { get; set; }

        public MarketplaceItemResultController(IViewPathResolver viewPathResolver, MarketplaceItemRepository marketplaceItemRepository) : base(viewPathResolver)
        {
            MarketplaceItemRepository = marketplaceItemRepository;
        }

        protected override object GetModel(Item datasource, Item contextItem)
        {
            var model = new MarketplaceItemResultViewModel();
            model.Items = MarketplaceItemRepository.GetAll();
            return model;
        }
    }
}