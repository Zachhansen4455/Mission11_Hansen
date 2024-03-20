namespace Mission11_Hansen.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookstoreContext _context;
        public EFBookRepository(BookstoreContext temp)
        {
            _context = temp;
        } //constructor
        public IQueryable<Book> Books => _context.Books;
    }
}
