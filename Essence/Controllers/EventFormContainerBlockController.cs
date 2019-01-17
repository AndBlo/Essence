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
    public class EventFormContainerBlockController : BlockController<EventFormContainerBlock>
    {
        public override ActionResult Index(EventFormContainerBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Wide })]
    public class EventFormContainerWideBlockController : BlockController<EventFormContainerBlock>
    {
        public override ActionResult Index(EventFormContainerBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Narrow })]
    public class EventFormContainerNarrowBlockController : BlockController<EventFormContainerBlock>
    {
        public override ActionResult Index(EventFormContainerBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
