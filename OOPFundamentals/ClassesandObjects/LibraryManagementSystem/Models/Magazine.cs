using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    class Magazine : LibraryItem
    {

        private readonly string publisher;

        public Magazine(string id, string title, string publisher) : base(id, title)
        {
            this.publisher = publisher;
        }

        public override string GetAuthorOrPublisher()
        {
            return publisher;
        }
    }
}
