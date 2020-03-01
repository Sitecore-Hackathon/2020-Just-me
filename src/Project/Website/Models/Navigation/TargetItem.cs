using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Constellation.Foundation.ModelMapping.MappingAttributes;
using Sitecore.Data;

namespace Website.Models.Navigation
{
    public class TargetItem
    {
        /// <summary>The Item's ID</summary>
        public ID ID { get; set; }

        /// <summary>The Item's Display Name</summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The Item's URL as created by the context LinkManager settings.
        /// </summary>
        public string Url { get; set; }
    }
}