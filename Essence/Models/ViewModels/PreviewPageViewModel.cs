using Essence.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Essence.Models.ViewModels
{
    public class PreviewPageViewModel : PageViewModel<SitePageData>
    {
        public PreviewPageViewModel(SitePageData currentPage,
            IContent contentToPreview) : base(currentPage)
        {
            this.PreviewArea = new ContentArea();
            this.PreviewArea.Items.Add(new ContentAreaItem
            {
                ContentLink = contentToPreview.ContentLink
            });
        }

        public ContentArea PreviewArea { get; set; }
    }
}
