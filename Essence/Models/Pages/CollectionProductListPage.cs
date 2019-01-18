using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Essence.Models.Pages
{
    [ContentType(DisplayName = "Collection Product List",
        GroupName = SiteGroupNames.Specialized,
        GUID = "7081bbc1-3d91-4a4c-a6fd-abed118cc4fd",
        Description = "Choose this to populate with products no matter what product list they are under.")]
    public class CollectionProductListPage : ProductListPage
    {
        [Display(
            Name = "Products",
            Description = "Content area for product pages to render product thumbs and links to the page itself.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [AllowedTypes(typeof(ProductPage))]
        public virtual ContentArea Products { get; set; }
    }
}
