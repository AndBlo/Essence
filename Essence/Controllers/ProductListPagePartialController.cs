using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Html.StringParsing;
using EPiServer.Filters;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Search;
using EPiServer.Search.Queries.Lucene;
using EPiServer.Security;
using EPiServer.Web.Mvc;
using Essence.Business.ExtensionMethods;
using Essence.Models.Pages;
using Essence.Models.ViewModels;

namespace Essence.Controllers
{
    public class ProductListPagePartialController : PartialContentController<ProductListPage>
    {
        public override ActionResult Index(ProductListPage currentPage)
        {
            return PartialView(PageViewModel.Create(currentPage));
        }
    }
}
