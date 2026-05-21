using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Strategy
{
    class SearchByAuthorStrategy : ISearchStrategy
    {
        public List<LibraryItem> Search(string query, List<LibraryItem> items)
        {
            return items.Where(item => item.GetAuthorOrPublisher().ToLower().Contains(query.ToLower())).ToList();
        }
    }
}
