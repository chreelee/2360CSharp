/* 
Christine Lee COP 2360
Student ID 2509320
02 13 2025

Description: Create a class with a method called ReverseCapitalize.
The ReverseCapitalize method will accept a string and return the string
reversed and capitalized.

Collaboration Statement: worked alone using provided links and materials
dotnet microsoft documents
*/

namespace Assignment5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a phrase to receive the reverse: ");
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings#possible-null-assigned-to-a-nonnullable-reference
        // add null forgiving operator for no error
        String entry = Console.ReadLine()!;

        // invoke the ReverseCapitalize method
        Console.WriteLine(ReverseCapitalize(entry));
    }

    
    // create ReverseCapitalize method
    public static string ReverseCapitalize(string text)
    {
        // will take the String entry, convert the entry toUpper and set to string Upper
        String upper = text.ToUpper();

        // initialize string reversed to hold the reverse of upper
        string reversed = "";
        // create foreach loop, for each character in the string upper
        foreach (char c in upper)
        {
            // append that character to the BEGINNING of reversed to get the reverse
            // appending it to the end just reads the line left to right. we want right to left
            reversed = c + reversed;
        } // end of foreach loop

        return reversed;
    }

}
