using Essence.Models.Pages;
using System.Collections.Generic;

namespace Essence.Models.ViewModels
{
    public class CollectionProductListPageViewModel : PageViewModel<CollectionProductListPage>
    {
        public CollectionProductListPageViewModel(CollectionProductListPage currentPage) : base(currentPage)
        {
        }

        public int? ProductPageCount
            => CurrentPage.Products?.Count;
    }
}
