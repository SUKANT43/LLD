using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Strategy
{
    class SearchByTitleStrategy : ISearchStrategy
    {
        public List<LibraryItem> Search(string query, List<LibraryItem> items)
        {
            return items.Where(item => item.GetTitle().ToLower().Contains(query.ToLower())).ToList();
        }
    }
}
