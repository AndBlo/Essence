using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Essence.Models.Pages;

namespace Essence.Models.Blocks
{
    [ContentType(DisplayName = "Categories",
        GUID = "16ac6933-b6e3-4026-b00e-5ee31e8508c9",
        GroupName = SiteGroupNames.Specialized,
        Order = 10,
        Description = "Use this to display product categories.")]
    [SiteBlockIcon]
    public class CategoriesBlock : BlockData
    {
        [Display(
            Name = "Product categories",
            Description = "Add any product list pages to display as links.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [AllowedTypes(typeof(ProductListPage))]
        public virtual ContentArea Categories { get; set; }
    }
}
