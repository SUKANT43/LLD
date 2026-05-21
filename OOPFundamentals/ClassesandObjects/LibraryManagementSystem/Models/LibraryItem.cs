using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    abstract class LibraryItem
    {
        private readonly string id;
        private readonly string title;

        private List<BookCopy> copies = new List<BookCopy>();
        private List<Member> observers = new List<Member>();

        public LibraryItem(string id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public void RemoveObserver(Member member)
        {
            observers.Remove(member);
        }

        public string GetId()
        {
            return id;
        }

        public void AddCopy(BookCopy copy)
        {
            copies.Add(copy);
        }

        public bool IsObserver(Member member)
        {
            return observers.Contains(member);
        }

        public abstract string GetAuthorOrPublisher();

        public long GetAvailableCopyCount()
        {
            return copies.Count;
        }

        public string GetTitle()
        {
            return title;
        }



        public BookCopy GetAvilableCopy(BookCopy copy)
        {
            return copies.FirstOrDefault(e => e == copy);
        }

        public void AddObserver(Member member)
        {
            observers.Add(member);
        }

        public bool HasObservers()
        {
            return observers.Count > 0;
        }

        public void NotifyObservers()
        {
            Console.WriteLine($"Notifying {observers.Count} observers for '{title}'...");
            var observersCopy = new List<Member>(observers);
            foreach (var observer in observersCopy)
            {
                observer.Update(this);
            }
        }

        public List<BookCopy> GetCopies()
        {
            return copies;
        }
    }
}
