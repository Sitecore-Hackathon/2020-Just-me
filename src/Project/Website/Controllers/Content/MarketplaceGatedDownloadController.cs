using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Constellation.Foundation.ModelMapping;
using Constellation.Foundation.Mvc;
using Constellation.Foundation.Mvc.Patterns.Controllers;
using Website.Models.SemanticContent;

namespace Website.Controllers.Content
{
    public class MarketplaceGatedDownloadController : DatasourceRenderingController<TargetMarketplaceItem>
    {
        public MarketplaceGatedDownloadController(IViewPathResolver viewPathResolver, IModelMapper modelMapper) : base(viewPathResolver, modelMapper)
        {
        }
    }
}