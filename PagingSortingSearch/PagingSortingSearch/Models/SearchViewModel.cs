using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagingSortingSearch.Models
{
	public class SearchItem
	{
		public int RestaurantID { get; set; }
		public string RestaurantName { get; set; }
		public string RestaurantCategory { get; set; }
		public string RestaurantCity { get; set; }

		public SearchItem(Restaurant dbRestaurant)
		{
			RestaurantID = dbRestaurant.ID;
			RestaurantName = dbRestaurant.Name;
			RestaurantCategory = dbRestaurant.Category.Name;
			RestaurantCity = dbRestaurant.City.Name;
		}

	}


	public class SearchViewModel
	{
		public const int PageSize = 3; //
		public string LastSortColumn { get; set; }
		public string LastSortDirection { get; set; }
		public List<SearchItem> SearchItems;

		public int CurrentPageIndex { get; set; }
		public int TotalPageCount { get; set; }
		public int TotalItemsCount { get; set; }

		public bool HasFirstPage
		{
			get { return CurrentPageIndex > 1; }
		}

		public bool HasPrevPage
		{
			get { return CurrentPageIndex > 1; }
		}

		public bool HasLastPage
		{
			get { return CurrentPageIndex < TotalPageCount; }
		}

		public bool HasNextPage
		{
			get { return CurrentPageIndex < TotalPageCount; }
		}

		public SearchViewModel()
		{
			SearchItems = new List<SearchItem>();
		}
		public SearchViewModel(List<Restaurant> list, int pageIndex, int recordCount) 
			: this()
		{
			list.ForEach(item => SearchItems.Add(new SearchItem(item)));
			TotalItemsCount = recordCount;
			TotalPageCount = ((recordCount - 1) / PageSize) + 1;
			CurrentPageIndex = pageIndex;
		}
	}
}