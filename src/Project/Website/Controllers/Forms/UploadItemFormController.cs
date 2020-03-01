using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Constellation.Foundation.ModelMapping;
using Sitecore.Data.Items;
using Website.Models;

namespace Website.Controllers.Forms
{
    public class UploadItemFormController : Controller
    {
        public IModelMapper ModelMapper { get; set; }

        public UploadItemFormController()
        {
            ModelMapper = DependencyResolver.Current.GetService<IModelMapper>();
        }

        public ActionResult Index()
        {
            Item datasourceItem = Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Item;
            var model = ModelMapper.MapItemToNew<UploadItemForm>(datasourceItem);
            return View(model);
        }
    }
}