using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Essence.Models.Pages
{
    [ContentType(DisplayName = "Contact",
        GUID = "B93AA4E9-7EA1-4088-BDCC-3488D34D5273",
        GroupName = SiteGroupNames.Specialized,
        Description = "Use this page type to display contact information.")]
    [SitePageIcon]
    public class ContactPage : SitePageData
    {
        [CultureSpecific]
        [Display(Name = "Heading",
            Description = "If the Heading is not set, the page falls back to showing the Name.",
            GroupName = SystemTabNames.Content, Order = 120)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 150)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(Name = "Main content area",
            Description = "Drag and drop images, blocks, folders, and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [AllowedTypes(typeof(StandardPage),
            typeof(BlockData), typeof(ImageData),
            typeof(ContentFolder))]
        public virtual ContentArea MainContentArea { get; set; }

    }
}
