using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Essence.Models.Pages
{
    [ContentType(DisplayName = "ProductList",
        GUID = "f6bcdd70-af3e-444d-ae8c-3223aea9834e",
        GroupName = SiteGroupNames.Common,
        Order = 50,
        Description = "Use this page for product listings.")]
    [SitePageIcon]
    public class ProductListPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [Display(
            Name = "List all products",
            Description = "Make this product list a list for all published products.",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual bool ListAllProducts { get; set; }

    }
}
