using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Essence.Models.Blocks
{
    [ContentType(DisplayName = "Store",
        GUID = "e617350f-4b7c-42b9-a659-fe5b81f227e6",
        GroupName = SiteGroupNames.Specialized,
        Order = 10,
        Description = "Use this to store information about a store.")]
    [SiteBlockIcon]
    public class StoreBlock : BlockData
    {
        [Display(
            Name = "Name",
            Description = "The name of the store.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Name { get; set; }

        [Display(
            Name = "City",
            Description = "The city of the store.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string City { get; set; }

        [Display(
            Name = "Street",
            Description = "The street address to the store.",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string StreetAddress { get; set; }

        [Display(
            Name = "Email",
            Description = "The email to the store.",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual string Email { get; set; }

        [Display(
            Name = "Phone",
            Description = "The phone number to the store.",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string Phone { get; set; }

        [Display(
            Name = "Open hours",
            Description = "The open hours of the store.",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string OpenHours { get; set; }

        [Display(
            Name = "Store Image",
            Description = "Image of store",
            GroupName = SystemTabNames.Content,
            Order = 70)]
        public virtual ContentReference Image { get; set; }

    }
}
