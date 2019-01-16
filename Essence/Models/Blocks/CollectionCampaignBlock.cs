using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Essence.Models.Blocks
{
    [ContentType(DisplayName = "Collection campaign",
        GUID = "12566557-c4b2-45a4-b3f8-018b911ddf14",
        GroupName = SiteGroupNames.Specialized,
        Description = "Use this block to store collection campaign links.")]
    [SiteBlockIcon]
    public class CollectionCampaignBlock : CampaignBlock
    {
        [CultureSpecific]
        [Display(
            Name = "Brand",
            Description = "Field for brand name.",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual string Brand { get; set; }
    }
}
