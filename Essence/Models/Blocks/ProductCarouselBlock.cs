using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Essence.Models.Pages;

namespace Essence.Models.Blocks
{
    [ContentType(DisplayName = "Product Carousel",
        GUID = "ac7bea8b-3c61-461a-8ebd-d08f5248cc5d",
        GroupName = SiteGroupNames.Specialized,
        Description = "Choose this block to store and display a carousel with product links")]
    public class ProductCarouselBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "The heading of the carousel",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [Display(
            Name = "Products",
            Description = "Content area for product pages to render product thumbs and links to the page itself.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(ProductPage))]
        public virtual ContentArea Products { get; set; }

    }
}
