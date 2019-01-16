using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Essence.Models.Blocks
{
    [ContentType(DisplayName = "CampaignBlock",
        GUID = "ab5a3b22-0eb9-4d90-b53b-1d37b415b4e8",
        GroupName = SiteGroupNames.Specialized,
        Description = "Use this block to store campaign links.")]
    public class CampaignBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Campaign heading.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Page link",
            Description = "Link to page.",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual PageReference PageReference { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Campaign image",
            Description = "Image for campaign display.",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [UIHint(UIHint.Image)] // filters to only show images
        public virtual ContentReference Image { get; set; }

    }
}
