using System.Collections;
using System.Collections.Generic;

namespace Store_Front.Models
{
    public class SearchViewModel:CustomerBaseViewModel
    {
        public int SearchViewModelId { get; set; }
        public IEnumerable<spSearchProducts_Result> Products { get; set; }
    }
}