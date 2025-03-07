/* 
Christine Lee COP 2360
Student ID 2509320
03 07 2025

Description: Create a phone book application that will allow users to
add new contacts and view all saved contacts in a phone book. User will 
be ask a menu of choices to add or view names or to exit the app. A
struct will contain a string for name, phone number, and enum for 
contact type of (personal, business, home). The contents are read
and saved in an array of type PhoneBookEntry.

Collaboration Statement: worked using provided links and materials
dotnet microsoft documents, textbook chapter 12 ,this youtube video for 
converting strings to enum https://www.youtube.com/watch?v=E_J1Vm7rg6k,
this video for object oriented programming
https://www.youtube.com/watch?v=Vp0vVzJgJ5g, this video for using LINQ
https://www.youtube.com/watch?v=jAPcP-QbCGA
*/

using System.Formats.Asn1;

namespace Assignment9;
class Program
{
    // structs are copies of the objects that are passed
    public struct PhoneBookEntry
    {
        public string Name; // string name and phone
        public string PhoneNumber;
        public ContactType Type; // is of ContactType enum, as Type
    }

    // enum that will hold the contact type as integers and uses meaningful
    // names instead of numbers
    public enum ContactType
    {
        Personal = 1, // as 1
        Business = 2, // as 2
        Home = 3 // as 3
    }

    // denote string for path to write and read OUTSIDE of main method and mark
    // as public static so every method can access the path
    public static string path = @"E:\Libraries\ExamplesWeek1\Assignment9\Phonebook.txt";

    // MAIN METHOD
    static void Main(string[] args)
    {
        // invoke an array of list of objects PhoneBookEntry as phonebook to store
        List<PhoneBookEntry> phoneBook = new();

        // check if a file exists
        if (File.Exists(path))
        {
            // from assignment8 use using, so you don't have to manually close the streamreader
            using StreamReader textIn = new(path);
            string line; // initialize a line entry as string line
                         // while the next readline is NOT empty
            while ((line = textIn.ReadLine()) != null)
            {
                // denote what line equals what from the comma separation in the
                // phonebookentry object using String.Split
                // https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
                // initialize array called fields to split the line using comma
                string[] fields = line.Split(',');

                // since the txt file might be empty, check if the line has 3 entries
                // for an actual phonebook entry
                if (fields.Length == 3)
                {
                    // denote what part of fields is equal to the fields in PhoneBookEntry
                    PhoneBookEntry entry = new()
                    {
                        Name = fields[0],
                        PhoneNumber = fields[1],
                        // since the fields is type STRING, it needs to be converted to the
                        // ContactType enum using enum.parse method and casting to ContactType
                        // https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=net-9.0
                        // https://www.youtube.com/watch?v=E_J1Vm7rg6k
                        Type = (ContactType)Enum.Parse(typeof(ContactType), fields[2])
                    };
                }
            }
        }

        // Print purpose of app and display menu with options
        Console.WriteLine($"This application allows users to add " +
        $"new contacts and view saved contacts.");
        Console.WriteLine($"=============== PHONE BOOK MENU ===============");
        Console.WriteLine($"Enter the menu number to perform the action.");
        Console.WriteLine($"[1] Add a Name");
        Console.WriteLine($"[2] View Contacts");
        Console.WriteLine($"[3] Search Contacts");
        Console.WriteLine($"[4] Delete Contacts");
        Console.WriteLine($"[5] Save Contacts");
        Console.WriteLine($"[-1] Exit Application");

        // get user's choice as menuChoice and convert to int to use
        int menuChoice = Convert.ToInt32(Console.ReadLine());

        // create endless while loop of choice 1-5, with each choice breaking out
        // into their specific method
        while ((menuChoice == 1) || (menuChoice == 2) || (menuChoice == 3) || (menuChoice == 4) || (menuChoice == 5))
        {   // Create a switch statement for menuChoice
            switch (menuChoice)
            {
                case 1: // choice for adding a name to phonebook ask user for a name
                    // invoke AddContact and pass phoneBook
                    System.Console.WriteLine("Selected option to add contact...");
                    AddContact(phoneBook);
                    break; // always remember to add break or app wont run :)

                case 2: // choice for viewing contacts
                    // invoke ViewContact and pass phoneBook
                    System.Console.WriteLine("Selected option to view contact...");
                    ViewContacts(phoneBook);
                    break;

                case 3: // choice for searching contacts
                    SearchContacts(phoneBook);
                    break;

                case 4: // choice for deleting contacts
                    DeleteContacts(phoneBook);
                    break;

                case 5: // choice for saving contacts
                    Save(phoneBook);
                    break;

            }
            // when switch case is done, ask user for the next menuChoice
            Console.WriteLine($"\n=============== PHONE BOOK MENU ===============");
            Console.WriteLine($"Enter the menu number to perform the action.");
            Console.WriteLine($"[1] Add a Name");
            Console.WriteLine($"[2] View Contacts");
            Console.WriteLine($"[3] Search Contacts");
            Console.WriteLine($"[4] Delete Contacts");
            Console.WriteLine($"[5] Save Contacts");
            Console.WriteLine($"[-1] Exit Application");
            menuChoice = Convert.ToInt32(Console.ReadLine());
        }
        // outside of while loop means the program will exit, print it will close
        Console.WriteLine($"Invalid input or selected Exit Application. " +
        $"Application will now close.");
    }

    // breaking out each option 1-5 into their specific methods

    // method addContact will add a contact name, phone, and contact type using
    // the PhoneBookEntry struct and add to the list phoneBook
    static void AddContact(List<PhoneBookEntry> phoneBook)
    {
        Console.Write($"Enter the name to add: ");
        string addName = Console.ReadLine();
        Console.WriteLine(addName); /////// checking to make sure

        // ask user for a phone number
        Console.WriteLine($"Enter {addName}'s phone number: ");
        string addPhone = Console.ReadLine();
        Console.WriteLine(addPhone); ////// checking to make sure

        // ask user for a contact type and convert to int
        Console.WriteLine($"Enter {addName}'s contact type: ");
        Console.WriteLine($"[1] Personal");
        Console.WriteLine($"[2] Business");
        Console.WriteLine($"[3] Home");
        // convert the entry to an integer
        int ContactTypeChoice = Convert.ToInt32(Console.ReadLine());

        // initialize the enum as addContactType with Personal, choice 1
        ContactType addContactType = ContactType.Personal;
        // if else statement to determine the addContactType based on
        // the integer in addContactTypeChoice
        if (ContactTypeChoice == 2) // for business option
        {
            addContactType = ContactType.Business;
        }
        else if (ContactTypeChoice == 3) // for home option
        {
            addContactType = ContactType.Home;
        }

        // initialize PhoneBookEntry struct to store entries as entry and
        // denote WHAT equals the appropriate field in PhoneBookEntry enum
        PhoneBookEntry entry = new()
        {
            Name = addName,
            PhoneNumber = addPhone,
            Type = addContactType
        };

        // use list add and pass entry as parameter
        phoneBook.Add(entry);

        // test print of entry added
        System.Console.WriteLine($"To add that entry was added");

    }


    // method viewContact will view entries in phoneBook
    static void ViewContacts(List<PhoneBookEntry> phoneBook)
    {
        // since phonebook is open, can iterate over list using foreach loop
        // https://www.youtube.com/watch?v=Vp0vVzJgJ5g
        Console.WriteLine("\n============ CONTACTS =============");
        foreach (var entry in phoneBook)
        {
            // print out the name, phone, and type
            System.Console.WriteLine($"Name: {entry.Name}");
            System.Console.WriteLine($"Phone Number: {entry.PhoneNumber}");
            System.Console.WriteLine($"Contact Type: {entry.Type}");
        }
    }

    // method SearchContact will search contact name for a match and return it
    static void SearchContacts(List<PhoneBookEntry> phoneBook)
    {
        // ask user to enter name to search and set as input
        System.Console.Write("Enter the name to search the phonebook: ");
        string input = Console.ReadLine();

        // store result using LINQ enumeration from this video for using the
        // Where keyword https://www.youtube.com/watch?v=jAPcP-QbCGA
        // and StringComparison from documentation
        // https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison?view=net-9.0
        var result = phoneBook.Where
        (s => s.Name.Contains(input, StringComparison.CurrentCultureIgnoreCase));

        // if result doesn't have anything, say that no one was found
        if (result == null)
        {
            System.Console.WriteLine("No entry matches that name.");
            return; // return on separate because of void
        }

        // otherwise, there IS a match so print it with foreach loop in view method
        Console.WriteLine($"============ CONTACTS =============");
        foreach (var entry in result)
        {
            System.Console.WriteLine($"Name: {entry.Name}");
            System.Console.WriteLine($"Phone Number: {entry.PhoneNumber}");
            System.Console.WriteLine($"Contact Type: {entry.Type}");
        }

    }


    // method DeleteContact will search contact name for a match and delete it
    static void DeleteContacts(List<PhoneBookEntry> phoneBook)
    {
        // ask user to enter name to delete and set as input
        System.Console.Write("Enter the name to delete in the phonebook: ");
        string nameToDelete = Console.ReadLine();

        // same as search, use LINQ enumeration to use the Equals method to
        // compare the entry nameToDelete to a name in phonebook, using the
        // FirstOrDefault overload on phonebook
        // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault?view=net-9.0
        var resultToDelete = phoneBook.FirstOrDefault
        (s => s.Name.Equals(nameToDelete, StringComparison.CurrentCultureIgnoreCase));

        // if result.Name doesn't have anything, say that no one was found
        if (resultToDelete.Name == null)
        {
            System.Console.WriteLine("A matching contact was not found");
            return; // return on separate because of void
        }

        // otherwise, there IS a match so delete the entry by passing the
        // resultToDelete to the list Remove method
        phoneBook.Remove(resultToDelete);
        // test print of entry added
        System.Console.WriteLine($"To add that entry was deleted");
    }


    // method Save will save the phonebook to the file path, separated by
    // commas on a single line
    static void Save(List<PhoneBookEntry> phoneBook)
    {
        // same using so it will autoclose
        using (StreamWriter textOut = new StreamWriter(path))
        {
            // iterate over each entry and write it in
            foreach (var entry in phoneBook)
            {
                textOut.WriteLine($"{entry.Name}, {entry.PhoneNumber}, {entry.Type}");
            }
        }
    }

}