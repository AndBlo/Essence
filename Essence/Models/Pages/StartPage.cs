using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Essence;
using System.ComponentModel.DataAnnotations;

namespace Essence.Models.Pages
{
    [ContentType(DisplayName = "Start",
        GUID = "53DCDC86-4D5A-469E-9987-F8FFE2152515",
        GroupName = SiteGroupNames.Specialized, Order = 10,
        Description = "The home page for a website with an area for blocks and partial pages.")]
    [SitePageIcon]
    public class StartPage : SitePageData
    {
        [Display(Name = "Site name",
            Description = "The name of the site",
            GroupName = SiteTabNames.SiteSettings, Order = 10)]
        public virtual string SiteName { get; set; }

        [Display(Name = "Site logo header",
            Description = "The site logo for the header",
            GroupName = SiteTabNames.SiteSettings, Order = 12)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference SiteLogoHeader { get; set; }

        [Display(Name = "Site logo footer",
            Description = "The site logo for the footer",
            GroupName = SiteTabNames.SiteSettings, Order = 14)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference SiteLogoFooter { get; set; }

        //[CultureSpecific]
        //[Display(Name = "Heading",
        //    Description = "If the Heading is not set, the page falls back to showing the Name.",
        //    GroupName = SystemTabNames.Content, Order = 15)]
        //public virtual string Heading { get; set; }

        //[CultureSpecific]
        //[Display(Name = "Main body",
        //    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
        //    GroupName = SystemTabNames.Content, Order = 20)]
        //public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(Name = "Main content area",
            Description = "Drag and drop images, blocks, folders, and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [AllowedTypes(typeof(StandardPage),
            typeof(BlockData), typeof(ImageData),
            typeof(ContentFolder))]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(Name = "Search",
            Description = "If you add a Search page to the site, set this property to reference it to enable search from every page.",
            GroupName = SiteTabNames.SiteSettings,
            Order = 40)]
        [AllowedTypes(typeof(ProductListPage))]
        public virtual PageReference SearchPageLink { get; set; }

        [CultureSpecific]
        [Display(Name = "Footer text",
            Description = "The footer text will be shown at the bottom of every page.",
            GroupName = SiteTabNames.SiteSettings, Order = 10)]
        public virtual string FooterText { get; set; }
    }
}
