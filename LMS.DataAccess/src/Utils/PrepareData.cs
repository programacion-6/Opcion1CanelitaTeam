using BookSystem;
using BorrowSystem;
using FinesSystem;
using LibraryConsole;
using Opcion1AlexPaca.Creator;
using userSystem;
using userSystem.Concrete;

namespace Utils;
public class PrepareData
{
    private static List<Patron> PreparePatrons()
    {
        List<Patron> Patrons = new List<Patron>();
        PatronCreator creator = new PatronCreator();
        Patron patron1 = (Patron)creator.CreateUser("Polo", 1212, 121243, "Sud", "Polo123");
        Patron patron2 = (Patron)creator.CreateUser("Marco", 1213, 212121, "With Polo", "Marco123");
        Patron patron3 = (Patron)creator.CreateUser("Midas", 1214, 999999, "Gold Castle", "Midas123");

        Patrons.Add(patron1);
        Patrons.Add(patron2);
        Patrons.Add(patron3);

        return Patrons;
    }

    private static List<Staff> PrepareStaff()
    {
        List<Staff> Staffs = new List<Staff>();
        StaffCreator creator = new StaffCreator();
        Staff patron1 = (Staff)creator.CreateUser("Admin", 2222, 111112, "Heraldo Town", "Admin123");
        Staff patron2 = (Staff)creator.CreateUser("Stelio", 1111, 222221, "SuperMarket", "Stelio123");

        Staffs.Add(patron1);
        Staffs.Add(patron2);


        return Staffs;
    }

    private static List<Book> PrepareBooks()
    {
        List<Book> books = new List<Book>();

        books.Add(new Book("1984", "George Orwell", "Dystopian", new DateTime(1949, 6, 8), "1234567890"));
        books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", new DateTime(1960, 7, 11), "0987654321"));
        books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Classic", new DateTime(1925, 4, 10), "1122334455"));
        books.Add(new Book("Moby Dick", "Herman Melville", "Adventure", new DateTime(1851, 10, 18), "6677889900"));
        books.Add(new Book("Pride and Prejudice", "Jane Austen", "Romance", new DateTime(1813, 1, 28), "3344556677"));

        foreach (var book in books)
        {
            book.setStock(10);
        }

        return books;
    }

    private static List<Borrow> PrepareBorrows(List<Patron> patrons, List<Book> books)
    {
        List<Borrow> borrows = new List<Borrow>();

        DateTime overdue = new DateTime(2024,02,12);

        Borrow borrow1 = new Borrow(patrons[0], books[0], DateTime.Now.AddDays(-10), DateTime.Now.AddDays(20));
        Borrow borrow2 = new Borrow(patrons[1], books[1], DateTime.Now.AddDays(-5), DateTime.Now.AddDays(25));
        Borrow borrow3 = new Borrow(patrons[2], books[2], DateTime.Now.AddDays(-15), overdue);
        Borrow borrow4 = new Borrow(patrons[0], books[4], DateTime.Now.AddDays(-10), DateTime.Now.AddDays(20));
        Borrow borrow5 = new Borrow(patrons[0], books[4], DateTime.Now.AddDays(-10), DateTime.Now.AddDays(20));

        borrows.Add(borrow1);
        borrows.Add(borrow2);
        borrows.Add(borrow3);
        borrows.Add(borrow4);
        borrows.Add(borrow5);

        return borrows;
    }

    public static Library PrepareLibrary(){
        PatronManager Patrons = new PatronManager();
        Patrons.SetPatrons(PreparePatrons());
        StaffManager Staffs = new StaffManager();
        Staffs.SetStaffs(PrepareStaff());
        BookRepository Books = new BookRepository();
        Books.SetBooksList(PrepareBooks());

        FineManager Fines = new FineManager(); 
        BorrowManager Borrows = new BorrowManager(PrepareBorrows(PreparePatrons(),PrepareBooks()));
        return new Library(Patrons, Staffs, Borrows, Books, Fines);
    }
}