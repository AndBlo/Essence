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
    [TemplateDescriptor(Tags = new[] { SiteTags.Full })]
    public class StoreBlockController : BlockController<StoreBlock>
    {
        public override ActionResult Index(StoreBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Wide })]
    public class StoreWideBlockController : BlockController<StoreBlock>
    {
        public override ActionResult Index(StoreBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Narrow })]
    public class StoreNarrowBlockController : BlockController<StoreBlock>
    {
        public override ActionResult Index(StoreBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
