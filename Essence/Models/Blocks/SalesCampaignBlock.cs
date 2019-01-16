using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Essence.Models.Blocks
{
    [ContentType(DisplayName = "Sales campaign",
        GUID = "c7f1aead-6706-4d73-a1a0-3e48e4368501",
        GroupName = SiteGroupNames.Specialized,
        Description = "Use this block to store sales campaign links.")]
    [SiteBlockIcon]
    public class SalesCampaignBlock : CampaignBlock
    {
        [CultureSpecific]
        [Display(
            Name = "Discount text",
            Description = "Campaign discount message.",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual string DiscountText { get; set; }
    }
}
