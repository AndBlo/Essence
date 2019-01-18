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
    public class ProductListPageController : PageControllerBase<ProductListPage>
    {
        private SearchHandler searchHandler;

        public ProductListPageController(IContentLoader loader, SearchHandler searchHandler) : base(loader)
        {
            this.searchHandler = searchHandler;
        }

        //public ActionResult Index(ProductListPage currentPage)
        //{
        //    return View(CreatePageViewModel(currentPage));
        //}

        public ActionResult Index(ProductListPage currentPage, string q)
        {
            var viewmodel = new ProductListPageViewModel(currentPage);

            Init(viewmodel);
            //viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            //viewmodel.MenuPages = FilterForVisitor.Filter(
            //    loader.GetChildren<SitePageData>(ContentReference.StartPage))
            //    .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            //viewmodel.Section = currentPage.ContentLink.GetSection();

            if (currentPage.ListAllProducts)
            {
                ListAll(currentPage, viewmodel);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(q))
                {
                    MakeSearch(q, viewmodel);
                }
                else
                {
                    ListChildren(currentPage, viewmodel);
                }
            }
            return View(viewmodel);
        }

        private void ListChildren(ProductListPage currentPage, ProductListPageViewModel viewmodel)
        {

            var productPages =
                FilterForVisitor
                .Filter(loader.GetChildren<ProductPage>(currentPage.ContentLink, Thread.CurrentThread.CurrentUICulture))
                .Cast<ProductPage>()
                .Where(page => page.VisibleInMenu);

            viewmodel.ProductsToDisplay = new List<ProductPage>(productPages);
        }

        private void ListAll(ProductListPage currentPage, ProductListPageViewModel viewmodel)
        {
            viewmodel.SearchText = "all";

            var productListRoot = loader.Get<ProductListPage>(currentPage.ContentLink, Thread.CurrentThread.CurrentUICulture);
            var productListPages =
                FilterForVisitor
                .Filter(loader.GetChildren<ProductListPage>(productListRoot.ContentLink, Thread.CurrentThread.CurrentUICulture))
                .Cast<ProductListPage>()
                .Where(page => page.VisibleInMenu);

            viewmodel.ProductsToDisplay = new List<ProductPage>();
            foreach (var page in productListPages)
            {
                viewmodel.ProductsToDisplay.AddRange(page.GetChildren().Cast<ProductPage>());
            }
        }

        private void MakeSearch(string q, ProductListPageViewModel viewmodel)
        {
            // 1. only productpages
            var onlyPages = new ContentQuery<ProductPage>();

            // 2. free-text query
            var freeText = new FieldQuery(q);

            // 3. only what the current user can read
            var readAccess = new AccessControlListQuery();
            readAccess.AddAclForUser(PrincipalInfo.Current, HttpContext);

            // 4. only productpages
            var inProductPages = new VirtualPathQuery();
            foreach (var page in viewmodel.MenuPages.Where(p => p.Name == "Shop"))
            {
                inProductPages.AddContentNodes(page.Page.ContentLink);
            }

            // build the query from the expressions
            var query = new GroupQuery(LuceneOperator.AND);
            query.QueryExpressions.Add(freeText);
            query.QueryExpressions.Add(onlyPages);
            query.QueryExpressions.Add(readAccess);
            query.QueryExpressions.Add(inProductPages);

            // get the first page of ten results
            SearchResults results = searchHandler.GetSearchResults(query, 1, 10);

            viewmodel.SearchText = q;

            if (results.TotalHits > 0)
            {
                viewmodel.ProductsToDisplay =
                    results.IndexResponseItems
                    .Where(p => p.Id.ToUpper().Contains(Thread.CurrentThread.CurrentUICulture.Name.ToUpper()))
                    .Select(p => loader.Get<ProductPage>(Guid.Parse(p.Id.Split('|').First())))
                    .ToList();
            }
            else
            {
                viewmodel.ProductsToDisplay = new List<ProductPage>();
            }
        }
    }
}
