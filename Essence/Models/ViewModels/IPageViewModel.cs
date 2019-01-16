using EPiServer.Core;
using Essence.Models.Pages;
using System.Collections.Generic;

namespace Essence.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        StartPage StartPage { get; }
        IEnumerable<SitePageData> MenuPages { get; }
        IContent Section { get; }
        IEnumerable<SitePageData> Children { get; }
    }
}
