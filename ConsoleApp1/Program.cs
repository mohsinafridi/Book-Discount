using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<Book> books = new List<Book>();
            books.Add(new Book
            {
                Id = "Test Book Id 1",
                Name = "Introduction to C#",                
                Price = 40,
              
                  RentDate = DateTime.Now.AddDays(-4)  
            }) ;

            books.Add(new Book
            {
                Id = "Test Book Id 2",
                Name = "SQL Server",                
                Price = 200,
                RentDate = DateTime.Now
            });

            books.Add(new Book
            {
                Id = "Test Book Id 3",
                Name = "Finance",
                Price = 400,
                RentDate = DateTime.Now
            });




            Library lib = new Library();
            lib.Books = books;

            if (lib.Books.Count > 0)            
            {
                // If the library doesn't rent out any book to anyone in the last 48 hours
                foreach (var book in lib.Books)
                {

                    var isBookRented = book.RentDate < DateTime.Now.AddDays(-2);

                    if (!isBookRented)
                    {     
                        var discount = 20 * book.Price / 100;
                        book.DiscountedPrice =  book.Price - discount;  // all books go on 20% discount for a month
                        Console.WriteLine("Old Price of Book: "+ book.Name + "is " +book.Price +  " , After Discounted, it is , " + book.DiscountedPrice);
                        
                    }
                }
                Console.ReadKey();
            }            
        }
    }

    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime RentDate { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }

        
    }

    public class Library
    {
        public List<Book> Books { get; set; }
    }
}
