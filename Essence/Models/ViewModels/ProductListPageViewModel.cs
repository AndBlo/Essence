using Essence.Models.Pages;
using System.Collections.Generic;

namespace Essence.Models.ViewModels
{
    public class ProductListPageViewModel : PageViewModel<ProductListPage>
    {
        public ProductListPageViewModel(ProductListPage currentPage) : base(currentPage)
        {
        }

        public string SearchText { get; set; }
        public List<ProductPage> SearchResult { get; set; }
    }
}
