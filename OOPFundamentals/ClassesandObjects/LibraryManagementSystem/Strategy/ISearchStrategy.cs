using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Strategy
{
    interface ISearchStrategy
    {
        List<LibraryItem> Search(string query, List<LibraryItem> items);
    }
}
