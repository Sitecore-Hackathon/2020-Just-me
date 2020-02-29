using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using Sitecore.Sites;
using Website.Constants;

namespace Website.Models.Forms
{
    [Serializable]
    public class DownloadButtonViewModel : FieldViewModel
    {

        public string FileUrl { get; set; }

        public string HtmlTag { get; set; }

        protected override void InitItemProperties(Item item)
        {
            base.InitItemProperties(item);
            // on load of the form
            string pageUrl = System.Web.HttpContext.Current.Request.Headers.GetValues("Referer").FirstOrDefault();
            var url = new Uri(pageUrl);

            // Obtain a SiteContext for the host and virtual path
            var siteContext = SiteContextFactory.GetSiteContext(url.Host, url.PathAndQuery);

            // Get the path to the Home item
            var homePath = siteContext.StartPath;
            if (!homePath.EndsWith("/"))
                homePath += "/";

            // Get the path to the item, removing virtual path if any
            var itemPath = url.AbsolutePath.ToLower();

            if (itemPath.StartsWith(siteContext.VirtualFolder))
                itemPath = itemPath.Remove(0, siteContext.VirtualFolder.Length);

            // Obtain the item
            var fullPath = homePath + itemPath.Replace("-", " ");
            var contextItem = siteContext.Database.GetItem(fullPath);

            if (contextItem != null)
            {
                FileField downloadField = contextItem.Fields[new ID(SitecoreItemsConstants.FILE_URL_FIELD_ID)];

                if (downloadField.MediaItem != null)
                {
                    //var downloadItem = new MediaItem(downloadField.MediaItem);
                    FileUrl = StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(downloadField.MediaItem));
                }
                else
                {
                    FileUrl = String.Empty;
                }

            }
            else
            {
                FileUrl = String.Empty;
            }

           
        }

        protected override void UpdateItemFields(Item item)
        {
            // upon save

            base.UpdateItemFields(item);
        }

    }
}