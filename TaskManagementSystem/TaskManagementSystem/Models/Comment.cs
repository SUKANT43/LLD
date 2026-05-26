using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Observer;

namespace TaskManagementSystem.Models
{
    class Comment
    {
        private string id;
        private string content;
        private User author;
        private DateTime timeStamp;

        public Comment(string content,User author)
        {
            this.id = Guid.NewGuid().ToString();
            this.content = content;
            this.author = author;
            timeStamp = DateTime.Now;
        }

        public User GetAuthor => author;

    }
}
