using EPiServer.Core;
using Essence.Models.Pages;
using System.Collections.Generic;
using System.Linq;

namespace Essence.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        StartPage StartPage { get; }
        //IEnumerable<SitePageData> MenuPages { get; }
        IEnumerable<IMenuPage> MenuPages { get; }
        IContent Section { get; }
        IEnumerable<SitePageData> Children { get; }
        IEnumerable<ProductListPage> Categories { get; }
    }

    public interface IMenuPage
    {
        string Name { get; }
        SitePageData Page { get; }
        bool HasChildren { get; }
        IEnumerable<SitePageData> Children { get; }
    }

    public class MenuPage : IMenuPage
    {
        public string Name { get; set; }
        public SitePageData Page { get; set; }
        public IEnumerable<SitePageData> Children { get; set; }
        public bool HasChildren
        {
            get
            {
                if (Children != null)
                {
                    return Children.Count() > 0;
                }
                return false;
            }
        }
    }
}
