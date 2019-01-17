using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Essence.Models.Blocks;

namespace Essence.Controllers
{
    [TemplateDescriptor(Tags = new[] { SiteTags.Full }, AvailableWithoutTag = true)]
    public class SalesCampaignBlockController : BlockController<SalesCampaignBlock>
    {
        public override ActionResult Index(SalesCampaignBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Wide })]
    public class SalesCampaignWideBlockController : BlockController<SalesCampaignBlock>
    {
        public override ActionResult Index(SalesCampaignBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Narrow })]
    public class SalesCampaignNarrowBlockController : BlockController<SalesCampaignBlock>
    {
        public override ActionResult Index(SalesCampaignBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
