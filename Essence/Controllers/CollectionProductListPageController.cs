using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class CollectionProductListPageController : PageControllerBase<CollectionProductListPage>
    {
        public CollectionProductListPageController(IContentLoader loader) : base(loader)
        {
        }

        public ActionResult Index(CollectionProductListPage currentPage, string q)
        {
            var viewmodel = new CollectionProductListPageViewModel(currentPage);

            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            viewmodel.MenuPages = FilterForVisitor.Filter(
                loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu)
                .Select(p => GetMenuPage(p));

            viewmodel.Section = currentPage.ContentLink.GetSection();

            viewmodel.Categories = viewmodel.MenuPages.FirstOrDefault(m => m.Name == "Shop")?.Children.Cast<ProductListPage>();

            return View(viewmodel);
        }
    }
}
