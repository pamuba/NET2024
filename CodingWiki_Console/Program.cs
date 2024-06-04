using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

//using (ApplicationDbContext context = new()) 
//{
//    context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count() > 0) { 
//        context.Database.Migrate(); 
//    }
//}

//AddBook();
//GetAllBooks();
GetBook();

void GetAllBooks() {
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();

    foreach (var book in books) {
        Console.WriteLine(book.Title+"--"+book.ISBN);
    }
}

void AddBook() { 
    Book book = new Book(){ Title="We need Dockers as well", ISBN="123321456",Price=12.34m, Publisher_Id=1};
    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    Console.WriteLine(books);
    context.SaveChanges();
}

void GetBook() {
    Fluent_Book defaultBook = new Fluent_Book() { Title = "Default Book", ISBN = "123321456", Price = 12.34m, Publisher_Id = 1 };
    try {
        //using var context = new ApplicationDbContext();
        ////Fluent_Book book = context.Books_fluent.First();
        //// ?? Fluent_Book book = context.Books_fluent.FirstOrDefault<Fluent_Book>(defaultBook);

        //Fluent_Book book = context.Books_fluent.FirstOrDefault<Fluent_Book>();
        //if (book == null) { 
        //    book = defaultBook;
        //}
        //Console.WriteLine(book.Title + " - " + book.ISBN);


        using var context = new ApplicationDbContext();
        //title && ISBN  && Publisher_Id
        Book book = context.Books.Where(u=> u.Title == "Ironman" && u.Publisher_Id==1).FirstOrDefault();
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}