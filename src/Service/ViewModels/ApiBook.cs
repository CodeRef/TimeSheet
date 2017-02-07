using System;
using System.Collections.Generic;

namespace TimeTracker.Service.ViewModels
{
    public class Shelf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ApiBook
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }

        // public virtual List<Author> Authers { get; set; }
        public string Picture { get; set; }
    }

    public class UserShelf
    {
        public Shelf Shelf { get; set; }
        public List<ApiBook> UserBooks { get; set; }
    }
}