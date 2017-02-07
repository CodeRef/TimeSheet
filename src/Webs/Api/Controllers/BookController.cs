using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TimeTracker.Service.IService;
using TimeTracker.Service.ViewModels;

namespace TimeTracker.Api.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BookController : BaseApiController
    {
        private readonly IBookService _book;
        private readonly IShelfBookService _shelfBookService;

        public BookController(IBookService book, IShelfBookService shelfBookService)
        {
            if (book == null) throw new ArgumentNullException("Book Service!");
            _book = book;
            if (shelfBookService == null) throw new ArgumentNullException("Shelf Book Service Cannot be null!");
            _shelfBookService = shelfBookService;
        }

        // GET: api/Book
        public async Task<List<UserShelf>> Get()
        {
            var user = await this.AppUserManager.FindByIdAsync(User.Identity.GetUserId());
            var shelves = new List<UserShelf>();
            user.Shelfs.ForEach(s =>
            {
                var sBooks = new UserShelf();
                //sBooks.Shelf = new TimeTracker.ViewModels.Shelf { Id = s.Id, Name = s.Name, Title = s.Title, Description = s.Description };
                sBooks.UserBooks = new List<ApiBook>();
                _shelfBookService.GetBookByShelfId(s.Id).ForEach(b =>
                {
                    sBooks.UserBooks.Add(new ApiBook
                    {
                        Id = b.Id,
                        ISBN = b.ISBN,
                        Name = b.Name,
                        Title = b.Title,
                        Description = b.Description,
                        PublicationDate = b.PublicationDate,
                        Picture = b.Picture
                    });
                });
                shelves.Add(sBooks);
            });
            return shelves;
        }

        // GET: api/Book/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Book
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
    }
}