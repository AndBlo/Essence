using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Essence.Models.Pages;
using Essence.Models.ViewModels;

namespace Essence.Controllers
{
    public class ProductPagePartialController : PartialContentController<ProductPage>
    {
        public override ActionResult Index(ProductPage currentPage)
        {
            return PartialView(PageViewModel.Create(currentPage));
        }
    }
}
