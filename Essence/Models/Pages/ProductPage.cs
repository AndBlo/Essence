using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace Essence.Models.Pages
{
    [ContentType(DisplayName = "Product",
        GUID = "7dc39172-68e2-44df-9f6d-86360292ec83",
        GroupName = SiteGroupNames.Common,
        Description = "Choose this for product details page.")]
    public class ProductPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Brand",
            Description = "The product brand",
            GroupName = SystemTabNames.Content,
            Order = 110)]
        public virtual string Brand { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Product name",
            Description = "The name of the product.",
            GroupName = SystemTabNames.Content,
            Order = 120)]
        public virtual string ProductName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Product price",
            Description = "The product price.",
            GroupName = SystemTabNames.Content,
            Order = 130)]
        public virtual double ProductPrice { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Product sizes",
            Description = "The available product sizes.",
            GroupName = SystemTabNames.Content,
            Order = 140)]
        public virtual IList<string> ProductSizes { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Product colors",
            Description = "The available product colors.",
            GroupName = SystemTabNames.Content,
            Order = 145)]
        public virtual IList<string> ProductColors { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 150)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(Name = "Product images",
            GroupName = SystemTabNames.Content, Order = 450)]
        [UIHint(UIHint.Image)] // filters to only show images
        public virtual IList<ContentReference> ProductImages { get; set; }

    }
}
