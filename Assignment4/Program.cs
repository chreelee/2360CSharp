/* 
Christine Lee COP 2360
Student ID 2509320
02 04 2025

Description: Create a phone book application that will allow users to
add new contacts and view all saved contacts in a phone book. User will 
be ask a menu of choices to add or view names or to exit the app.

Collaboration Statement: worked alone using provided links and materials
dotnet microsoft documents and the textbook chapter 17 input/output
*/

namespace Assignment4;
class Program
{
    static void Main(string[] args)
    {
        // denote string for path to write and read OUTSIDE of switch
        string path = @"E:\Libraries\ExamplesWeek1\Assignment4\Phonebook.txt";

        // Print purpose of app and display menu with options
        Console.WriteLine($"This application allows users to add " +
        $"new contacts and view saved contacts.");
        Console.WriteLine($"=============== PHONE BOOK MENU ===============");
        Console.WriteLine($"Enter the menu number to perform the action.");
        Console.WriteLine($"[1] Add a Name");
        Console.WriteLine($"[2] View Contacts");
        Console.WriteLine($"[-1] Exit Application");

        // get user's choice as menuChoice and convert to int to use
        int menuChoice = Convert.ToInt32(Console.ReadLine());

        // create endless while loop of choice 1 or 2
        while ((menuChoice == 1) || (menuChoice == 2))
        {   // Create a switch statement for menuChoice
            switch (menuChoice)
            {
                case 1: // choice for adding a name to phonebook ask user for a name
                    Console.Write($"Enter the name to add: ");
                    string addName = Console.ReadLine();
                    Console.WriteLine(addName); /////// checking to make sure

                    // ask user for a phone number
                    Console.WriteLine($"Enter {addName}'s phone number: ");
                    string addPhone = Console.ReadLine();
                    Console.WriteLine(addPhone); ////// checking to make sure

                    // code for writing name and phone number to file with \t
                    // new streamwriter that will open or create the path
                    StreamWriter textOut = new(new
                    FileStream(path, FileMode.Append));
                    textOut.Write($"Name: " + addName + "\t");
                    textOut.WriteLine($"Phone Number: " + addPhone);
                    textOut.Close(); // close FileStream

                    break; // always remember to add break or app wont run :)

                case 2: // choice for viewing contacts
                        // new streamreader that will read path
                        // https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-9.0
                    StreamReader textIn = new(new
                    FileStream(path, FileMode.Open, FileAccess.Read));

                    // check if there is at least 1 character
                    while (textIn.Peek() != -1)
                    {
                        // initialize a line entry as string line
                        string line;
                        // print Contacts header
                        Console.WriteLine($"============ CONTACTS =============");

                        // read and display lines from file until the end is reached
                        // while the next readLine is NOT empty,
                        while ((line = textIn.ReadLine()) != null)
                        {   // print the line
                            Console.WriteLine(line);
                        }

                    }
                    textIn.Close(); // close textIn filestream

                    break;
            }
            // when switch case is done, ask user for the next menuChoice
            Console.WriteLine($"\n=============== PHONE BOOK MENU ===============");
            Console.WriteLine($"Enter the menu number to perform the action.");
            Console.WriteLine($"[1] Add a Name");
            Console.WriteLine($"[2] View Contacts");
            Console.WriteLine($"[-1] Exit Application");
            menuChoice = Convert.ToInt32(Console.ReadLine());
        }
        // outside of while loop means the program will exit, print it will close
        Console.WriteLine($"Invalid input or selected Exit Application. " +
        $"Application will now close.");
    }
}