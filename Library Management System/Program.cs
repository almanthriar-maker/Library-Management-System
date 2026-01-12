using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Transactions;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
        //Phase1: system storage

            string[] title = new string[100]; //title
            string[] ISBN = new string[100];      //ISBN
            bool[] bookAvailability = new bool[100]; // true = available, false = borrowed
            string[] borrowerName = new string[100];   //
            string[] author = new string[100];     //
            int LastBookIndex = -1; // 



            //seed data
            title[0] = "Harry potter";
            ISBN[0] = "1408";
            bookAvailability[0] = true;
            borrowerName[0] = "Mayar";
            author[0] = "Mary Norton";
            LastBookIndex++;

            title[1] = "Home Alone";
            ISBN[1] = "9781";
            bookAvailability[1] = true;
            borrowerName[1] = "Reema";
            author[1] = "John Hughes";
            LastBookIndex++;



            //permenant stroage : database, file system


            bool exit = false;
            bool isAvailable = true;

            while (true)
            {
                Console.WriteLine("Welcome t0 Library_Management_System");
                Console.WriteLine("1. Create New Book ");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List All Available Books");
                Console.WriteLine("6. Transfer Book");
                Console.WriteLine("7. Exit");
                Console.Write("Please select an option: ");

                int option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 1: //done
                        //Phase2: input &  //Phase3: processing
                        Console.Write("Enter book title:  ");
                        title[LastBookIndex + 1] = Console.ReadLine();
                        Console.Write("Enter book ISBN: ");
                        ISBN[LastBookIndex + 1] = Console.ReadLine();
                        bookAvailability[LastBookIndex + 1] = true; // new book is available
                        Console.Write("Enter book borrower name: ");
                        borrowerName[LastBookIndex + 1] = Console.ReadLine();
                        Console.Write("Enter book author name: ");
                        author[LastBookIndex + 1] = Console.ReadLine();
                        LastBookIndex++;
                        Console.WriteLine("Book added successfully!");
                        break;


                    case 2:

                        //done

                            Console.WriteLine("Enter ISBN or Title:");
                            string input = Console.ReadLine();

                        isAvailable = false;

                        for (int i = 0; i <= LastBookIndex; i++)
                            {
                                if ((ISBN[i] == input || title[i] == input) && bookAvailability[i] == true)
                                {
                                    Console.Write("Enter your name: ");
                                    borrowerName[i] = Console.ReadLine();
                                    bookAvailability[i] = false;
                                    Console.WriteLine("You have successfully borrowed the book.");
                                    isAvailable = true;
                                    break;
                                }
                            }
                            if (isAvailable == false)
                            {
                                Console.WriteLine("Book is not available");
                            }
                                       

                        break;


                    case 3: // Return Book  

                        Console.Write("Enter ISBN: ");
                        string returnISBN = Console.ReadLine();
                        bool foundReturn = false;
                        for (int i = 0; i <= LastBookIndex; i++)
                        {
                            if (ISBN[i] == returnISBN)
                            {
                                bookAvailability[i] = true;
                                borrowerName[i] = "";
                                Console.WriteLine("Book returned successfully!");
                                foundReturn = true;
                                break;
                            }
                        }

                        break;
                

                        case 4: // Search Book
                        Console.Write("Enter book title or ISBN to search: ");
                        string searchInput = Console.ReadLine();
                        bool foundSearch = false;
                        for (int i = 0; i <= LastBookIndex; i++)
                        {
                            if (title[i] == searchInput || ISBN[i] == searchInput)
                            {
                                Console.WriteLine($"Title: {title[i]}, ISBN: {ISBN[i]}, Author: {author[i]}, Available: {bookAvailability[i]}");
                                foundSearch = true;
                                break;
                            }
                        }
                        if (!foundSearch)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;

                        case 5: // List All Available Books
                            Console.WriteLine("Available Books:");
                            for (int i = 0; i <= LastBookIndex; i++)
                            {
                                if (bookAvailability[i] == true)
                                {
                                    Console.WriteLine($"Title: {title[i]}, ISBN: {ISBN[i]}, Author: {author[i]}");
                                }
                        }
                            break;



                    case 6: // Transfer Book
                        Console.Write("Enter book ISBN to transfer: ");
                        string transferISBN = Console.ReadLine();
                        bool foundTransfer = false;
                        for (int i = 0; i <= LastBookIndex; i++)
                        {
                            if (ISBN[i] == transferISBN)
                            {
                                Console.Write("Enter new borrower name: ");
                                borrowerName[i] = Console.ReadLine();
                                bookAvailability[i] = false;
                                Console.WriteLine("Book transferred successfully!");
                                foundTransfer = true;
                                break;
                            }
                        }
                        if (!foundTransfer)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;


                        case 7:
                        exit = true;
                        break;
                        default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (exit == true)
                {
                    break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
// End of File















