using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    class Book : LibraryItem
    {

        private readonly string author;

        public Book(string id,string title,string author) : base(id, title)
        {
            this.author = author;
        }

        public override string GetAuthorOrPublisher()
        {
            return author;
        }
    }
}
