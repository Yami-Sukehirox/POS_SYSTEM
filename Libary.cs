using System;
using System.Collections.Generic;

class LibaryManagementSystem
{
    class Book
    {
        public int bookId;
        public string title;
        public string author;
        public int quantity;
    }

    class BorrowRecord
    {
        public int recordId;
        public string borrowName;
        public Book book;
        public DateTime borrowDate;
        public bool isReturned;
    }

    static List<Book> books = new List<Book>();
    static List<BorrowRecord> BorrowRecords = new List<BorrowRecord>();

    static void Main(string[] args)
    {
        

        int choice = 0;

        while (choice != 9)
        {
            DisplayMenu();

            Console.WriteLine("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    ViewBooks();
                    break;
                case 3: 
                    SearchBook();
                    break;
                case 4:
                    UpdateBook();
                    break;
                case 5:
                    DeleteBook();
                    break;
                case 6:
                    BorrowBook();
                    break;
                case 7:
                    ReturnBook();
                    break;
                case 8:
                    ViewBorrowingHistory();
                    break;
                case 9:
                    Console.WriteLine("Thank you for");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter Book ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Book title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Book author: ");
        string author = Console.ReadLine();

        Console.Write("Enter Book quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Book newBook = new Book();

        newBook.bookId = id;
        newBook.title = title;
        newBook.author = author;
        newBook.quantity = quantity;

        books.Add(newBook);

        Console.WriteLine("Book added successfully");
        
    }

    static void ViewBooks()
    {

    }

    static Book SearchBook(int bookId)
    {

    }

    static void UpdateBook(int bookId)
    {

    }

    static void DeleteBook(int bookId)
    {

    }

    static void BorrowBook()
    {

    }

    static void ReturnBook(int recordId)
    {

    }

    static void ViewBorrowingHistory()
    {

    }

    static BorrowRecord GetBorrowRecord()
    {

    }
    
    static void DisplayMenu()
    {
        Console.WriteLine("\n======= MENU =========");
        Console.WriteLine("1. Add Books");
        Console.WriteLine("2. View All Books");
        Console.WriteLine("3. Search Books");
        Console.WriteLine("4. Update Books");
        Console.WriteLine("5. Delete Books");
        Console.WriteLine("6. Borrow Books");
        Console.WriteLine("7. Return Books");
        Console.WriteLine("8. View Borrowing History");
        Console.WriteLine("9. Exit");
    }

}