/* 
Christine Lee COP 2360
Student ID 2509320
02 22 2025

Description: Create a program that initializes a list and uses
horticulture_terms.txt to assign each line as a value to elements in the list.
Once the list is created, the program will prompt the user for input to search.
Binary search algorithm will be used to search the items on the list. If the term
is in the list, the index will be returned. If not, it will return that the value
was not found in the list.

Collaboration Statement: worked alone using provided links and materials
dotnet microsoft documents, dotnet youtube video, and experience from Java class
*/

using System.IO; // from Text Processing document for StreamReader class
namespace Assignment8;

class Program
{
    static void Main(string[] args)
    {
        // Text Processing document, reading from text file, set filepath to path
        string path = @"E:\Libraries\ExamplesWeek1\Assignment8\horticulture_terms.txt";

        // initialize an empty list to assign values from horticulture_terms
        // https://www.youtube.com/watch?v=7PDNqmBdtrE&list=PLdo4fOcmZ0oULFjxrOagaERVAMbmG20Xe&index=14
        var horticultureTerms = new List<string> { };

        // use using, so you don't have to manually close the streamreader
        // used quickfix which changed it to new(path) instead of new StreamReader path
        using (StreamReader reader = new(path))
        {
            string line; // initialize a line entry as string line
            // while the next ReadLine is NOT empty, add line to the list
            while ((line = reader.ReadLine()) != null)
            {
                //////////////// Console.WriteLine(line);
                // append the entry to the horticultureTerms list using Add
                horticultureTerms.Add(line);
                //////////////// System.Console.WriteLine($"This line is {line}");
            }
        }

        // now that horticultureTerms is filled, sort the list for binary search
        horticultureTerms.Sort(); /////// below is print testing for sort
        // foreach (string term in horticultureTerms)
        // {
        //     // print element and it's value
        //     Console.WriteLine($"The sorted term is {term}.");
        // }

        // prompt user for string input to search, as input
        System.Console.Write("Enter a horticulture term to search: ");
        string input = Console.ReadLine();

        // set result to the index of binary searching the string input
        int result = horticultureTerms.BinarySearch(input);
        // BinarySearch will return the index of the value. If there is NO MATCH,
        // it will return by default -1 or any other negative number.

        // create if else statement for positive (found) and negative (not found)
        if (result > 0)
        { // input match was found, and will return index
            System.Console.WriteLine($"Input \"{input}\" is in the list and was found" +
            $" at element number: {result}.");
        }
        else
        { // input match was NOT found, and returned negative
            System.Console.WriteLine($"Input \"{input}\" was not found in the list.");
        }
    }
}
