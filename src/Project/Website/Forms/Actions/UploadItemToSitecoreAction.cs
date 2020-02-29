using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using Sitecore.IO;
using static System.FormattableString;
using Convert = System.Convert;

namespace Website.Forms.Actions
{
    public class UploadItemToSitecoreAction : SubmitActionBase<string>
    {
        public UploadItemToSitecoreAction(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));

            if (!formSubmitContext.HasErrors)
            {
                return SubmitFormToEloqua(formSubmitContext);
            }
            else
            {
                Logger.Warn(Invariant($"Form {formSubmitContext.FormId} submitted with errors: {string.Join(", ", formSubmitContext.Errors.Select(t => t.ErrorMessage))}."), this);
            }

            return true;
        }

        public bool SubmitFormToEloqua(FormSubmitContext formSubmitContext)
        {
            Logger.Info(Invariant($"Form {formSubmitContext.FormId} submitted successfully."), this);
            HttpPostedFileBase file = null;
            string fileName = null;
            foreach (IViewModel field in formSubmitContext.Fields)
            {
                if (field is FileUploadViewModel)
                {
                    var fileUpload = field as FileUploadViewModel;
                    if (fileUpload.Files.Count > 0)
                    {
                        file = fileUpload.Files.First();
                    }
                }

                if (field.Name == "fileName")
                {
                    var textField = field as StringInputViewModel;
                    fileName = textField.Value;
                }
            }

            if (file != null && fileName != null)
            {
                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    var master = Sitecore.Configuration.Factory.GetDatabase("master");
                    // Create the options
                    Sitecore.Resources.Media.MediaCreatorOptions options = new Sitecore.Resources.Media.MediaCreatorOptions();
                    // Store the file in the database, not as a file
                    options.FileBased = false;
                    // Remove file extension from item name
                    options.IncludeExtensionInItemName = false;
                    // Overwrite any existing file with the same name
                    options.OverwriteExisting = true;
                    // Do not make a versioned template
                    options.Versioned = false;
                    // set the path
                    options.Destination = "/sitecore/media library/Items/Uploaded/"+fileName;
                    // Set the database
                    options.Database = master;

                    var mediaItem = Sitecore.Resources.Media.MediaManager.Creator.CreateFromStream(file.InputStream, fileName+"." + file.FileName.Split(Convert.ToChar(".")).Last(), options);

                    Item parentItem = master.Items[Sitecore.Context.Site.StartPath];
                    TemplateItem template = master.GetTemplate(new ID("{744445AA-E445-44C4-85D9-88E5EF8C44F3}"));

                    Item marketplaceItem = parentItem.Add(fileName, template);

                    marketplaceItem.Editing.BeginEdit();

                    try
                    {
                        marketplaceItem.Fields["Name"]?.SetValue(fileName, true);
                        var fileField = (FileField) marketplaceItem.Fields["File"];
                        fileField.MediaID = mediaItem.ID;
                        marketplaceItem.Editing.EndEdit();
                    }
                    catch (Exception ex)
                    {
                        marketplaceItem.Editing.CancelEdit();
                    }

                  



                }
            }

            return true;
        }
    }
}