using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Console;
using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Systems.Concretes;
using LMS.DataAccess.Systems.Entities.Borrowing;


namespace LMS.DataAccess.Utils;

public class PrepareData
{
    private static void PreparePatrons(PatronManager patronManager)
    {
        List<Patron> Patrons = new List<Patron>();
        PatronCreator creator = new PatronCreator();
        Patron patron1 = (Patron) creator.CreateUser("Polo", Generator.GenerateMembershipNumber(), 121243, "Sud", "Polo123");
        Patron patron2 = (Patron) creator.CreateUser("Marco", Generator.GenerateMembershipNumber(), 212121, "With Polo", "Marco123");
        Patron patron3 = (Patron) creator.CreateUser("Midas", Generator.GenerateMembershipNumber(), 999999, "Gold Castle", "Midas123");

        Patrons.Add(patron1);
        Patrons.Add(patron2);
        Patrons.Add(patron3);

        foreach (Patron patron in Patrons)
        {
            patronManager.Add(patron);
        }
    }

    private static void PrepareStaff(StaffManager staffManager)
    {
        List<Staff> Staffs = new List<Staff>();
        StaffCreator creator = new StaffCreator();
        Staff patron1 = (Staff) creator.CreateUser("Admin", Generator.GenerateMembershipNumber(), 111112, "Heraldo Town", "Admin123");
        Staff patron2 = (Staff) creator.CreateUser("Stelio", Generator.GenerateMembershipNumber(), 222221, "SuperMarket", "Stelio123");

        Staffs.Add(patron1);
        Staffs.Add(patron2);

        foreach (Staff staff in Staffs)
        {
            staffManager.Add(staff);
        }
    }

    private static void PrepareBooks(BookManager repository)
    {
        List<Book> books = new List<Book>();

        books.Add(new Book("1984", "George Orwell", "Dystopian", new DateTime(1949, 6, 8), Generator.GenerateISBN()));
        books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", new DateTime(1960, 7, 11), Generator.GenerateISBN()));
        books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Classic", new DateTime(1925, 4, 10), Generator.GenerateISBN()));
        books.Add(new Book("Moby Dick", "Herman Melville", "Adventure", new DateTime(1851, 10, 18), Generator.GenerateISBN()));
        books.Add(new Book("Pride and Prejudice", "Jane Austen", "Romance", new DateTime(1813, 1, 28), Generator.GenerateISBN()));

        foreach (var book in books)
        {
            book.setStock(10);
            repository.Add(book);
        }
    }

    private static void PrepareBorrows(BorrowManager borrowManager, List<Patron> patrons, List<Book> books)
    {
        List<Borrow> borrows = new List<Borrow>();

        DateTime overdue = new DateTime(2024, 02, 12);

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

        foreach (var borrow in borrows)
        {
            borrowManager.Add(borrow);
        }
    }

    public static Library PrepareLibrary()
    {
        PatronManager Patrons = new PatronManager();
        PreparePatrons(Patrons);
        StaffManager Staffs = new StaffManager();
        PrepareStaff(Staffs);
        BookManager Books = new BookManager();
        PrepareBooks(Books);

        FineManager Fines = new FineManager();
        BorrowManager Borrows = new BorrowManager();
        PrepareBorrows(Borrows, Patrons.GetAll(), Books.GetAll());
        return new Library(Patrons, Staffs, Borrows, Books, Fines);
    }
}
