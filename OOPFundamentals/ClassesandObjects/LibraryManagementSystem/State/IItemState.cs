using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.State
{
    interface IItemState
    {
        void PlaceHold(BookCopy copy, Member member);
        void Checkout(BookCopy copy, Member member);
        void ReturnItem(BookCopy copy);
    }
}
