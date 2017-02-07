using RestMeet.Model;
using RestMeet.Repository;
using RestMeet.Service;

namespace BookStore
{
    public class Root
    {
        public IBook Book;
        public IShopService Shop;
        public IToDoService ToDo;

        public Root()
        {
            var Context = new DataContext();
            var UnitOfWork = new UnitOfWork(Context);
            Book = new BookService(UnitOfWork, new BookRepository(Context));
            Shop = new ShopService(UnitOfWork, new ShopRepository(Context));
            ToDo = new ToDoService(UnitOfWork, new ToDoRepository(Context));
        }
    }
}