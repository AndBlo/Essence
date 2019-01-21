using System;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using Essence.Models.Pages;

namespace Essence.Business.SceduledJobs
{
    [ScheduledPlugIn(DisplayName = "Product Price Increase Ten Percent")]
    public class ProductPriceIncreaseTenPercentScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;
        private readonly IContentRepository repo;

        public ProductPriceIncreaseTenPercentScheduledJob(IContentRepository repo)
        {
            this.repo = repo;
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

            //Add implementation
            var shopPage = repo.GetChildren<PageData>(ContentReference.StartPage).FirstOrDefault(p => p.Name == "Shop");

            if (shopPage == null)
            {
                return "Job stopped. A Shop page has not yet been created as a child to the Start page.";
            }

            var listPages = FilterForVisitor
                    .Filter(repo.GetChildren<PageData>(shopPage.ContentLink))
                    .Cast<ProductListPage>().Where(p => p.VisibleInMenu);

            int pageCount = 0;

            foreach (var pListPage in listPages)
            {
                var productPages = FilterForVisitor
                    .Filter(repo.GetChildren<PageData>(pListPage.ContentLink))
                    .Cast<ProductPage>().Where(p => p.VisibleInMenu);

                pageCount = productPages.Count();

                foreach (var page in productPages)
                {
                    var clone = page.CreateWritableClone() as ProductPage;

                    var newPrice = clone.ProductPrice * 1.1;

                    clone.ProductPrice = Math.Floor(newPrice);

                    repo.Save(clone,
                        EPiServer.DataAccess.SaveAction.Publish,
                        EPiServer.Security.AccessLevel.NoAccess);
                }
            }


            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return $"{pageCount} product prices updated.";
        }
    }
}
