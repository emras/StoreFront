using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Store_Front.Models
{
    public class SearchViewModel:CustomerBaseViewModel
    {
        [Display(Name="Search Products: ")]
        public string SearchText { get; set; }

        public List<SearchResultsViewModel> Results { get; set; }

        public SearchViewModel()
        {
            Results = new List<SearchResultsViewModel>();
        }

    }
}