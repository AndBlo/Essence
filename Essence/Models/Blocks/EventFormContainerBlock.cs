using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Web;

namespace Essence.Models.Blocks
{
    [ContentType(DisplayName = "Event Form Container",
        GUID = "287d6cf6-750b-4b37-8ba4-8f090f019bdf",
        GroupName = SiteGroupNames.Specialized,
        Description = "Use this block to store form blocks.")]
    public class EventFormContainerBlock : BlockData
    {
        [Display(
            Name = "Form container",
            Description = "The form container.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [AllowedTypes(typeof(FormContainerBlock))]
        public virtual ContentArea Forms { get; set; }

        [Display(
            Name = "Background Image",
            Description = "The background image for the block",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }

    }
}
