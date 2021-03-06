using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Essence.Business.ExtensionMethods;
using Essence.Models.Pages;
using Essence.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Essence.Controllers
{
    public abstract class PageControllerBase<T>
        : PageController<T> where T : SitePageData
    {
        protected readonly IContentLoader loader;

        public PageControllerBase(IContentLoader loader)
        {
            this.loader = loader;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        protected IPageViewModel<TPage> CreatePageViewModel<TPage>(
            TPage currentPage) where TPage : SitePageData
        {
            var viewmodel = PageViewModel.Create(currentPage);

            Init(viewmodel);

            return viewmodel;
        }

        internal void Init<P> (PageViewModel<P> viewmodel) where P : SitePageData
        {
            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            viewmodel.MenuPages = FilterForVisitor.Filter(
                loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu)
                .Select(p => GetMenuPage(p));

            viewmodel.Section = viewmodel.CurrentPage.ContentLink.GetSection();

            viewmodel.Categories = viewmodel.MenuPages.FirstOrDefault(m => m.Name == "Shop")?.Children.Cast<ProductListPage>();
        }

        internal IMenuPage GetMenuPage(SitePageData sitePageData)
        {
            return new MenuPage
            {
                Name = sitePageData.Name,
                Page = sitePageData,
                Children = FilterForVisitor.Filter(loader.GetChildren<SitePageData>(sitePageData.ContentLink))
                .Cast<SitePageData>()
                .Where(page => page.VisibleInMenu)
            };
        }

        //public static PageData PageFromURL(string url)
        //{
        //    var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
        //    IContent contentData = urlResolver.Route(new UrlBuilder(url));

        //    PageReference current_ref = new PageReference(contentData.ContentLink.ID);

        //    PageData current = DataFactory.Instance.GetPage(current_ref);

        //    return current;
        //}
    }
}
