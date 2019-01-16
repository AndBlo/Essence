using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Essence.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Essence.Business.ExtensionMethods
{
    public static class MiscExtensions
    {
        /// <summary>
        /// Truncate strings after n words
        /// </summary>
        /// <param name="input"></param>
        /// <param name="noWords"></param>
        /// <returns></returns>
        public static string TruncateAtWord(this string input, int noWords)
        {
            string output = string.Empty;
            string[] inputArr = input.Split(new[] { ' ' }); if (inputArr.Length <= noWords)
                return input; if (noWords > 0)
            {
                for (int i = 0; i < noWords; i++)
                {
                    output += inputArr[i] + " ";
                }
                output += "...";
                return output;
            }
            return input;
        }

        public static string ExternalURLFromReference(this PageReference p)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            PageData page = loader.Get<PageData>(p);

            UrlBuilder pageURLBuilder = new UrlBuilder(page.LinkURL);

            Global.UrlRewriteProvider.ConvertToExternal(pageURLBuilder, page.PageLink, UTF8Encoding.UTF8);

            string pageURL = pageURLBuilder.ToString();

            UriBuilder uriBuilder = new UriBuilder(EPiServer.Web.SiteDefinition.Current.SiteUrl);

            uriBuilder.Path = pageURL;

            return uriBuilder.Uri.AbsoluteUri;
        }

        public static string ExternalURLFromSitePageData(this SitePageData page)
        {

            UrlBuilder pageURLBuilder = new UrlBuilder(page.LinkURL);

            Global.UrlRewriteProvider.ConvertToExternal(pageURLBuilder, page.PageLink, UTF8Encoding.UTF8);

            string pageURL = pageURLBuilder.ToString();

            UriBuilder uriBuilder = new UriBuilder(EPiServer.Web.SiteDefinition.Current.SiteUrl);

            uriBuilder.Path = pageURL;

            return uriBuilder.Uri.AbsoluteUri;
        }

        public static IEnumerable<PageData> GetChildren(this PageData CurrentPage)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            IEnumerable<PageData> pages = new List<PageData>();
            PageReference listRoot = CurrentPage.PageLink;

            pages = loader.GetChildren<PageData>(listRoot).OfType<PageData>();

            return pages;
        }

        public static bool HasChildren(this PageData CurrentPage)
        {
            return CurrentPage.GetChildren().Any();
        }
    }
}
