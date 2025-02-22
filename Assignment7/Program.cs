/* 
Christine Lee COP 2360
Student ID 2509320
02 22 2025

Description: Create program that initializes an array and assigns 10 random
integers between 1 and 100 to the array. A loop will go through each element
in the array and print out the index of the element, it's value, and the 
cumulative total.

Collaboration Statement: worked alone using provided links and materials
dotnet microsoft documents
*/
namespace Assignment7;

class Program
{
    static void Main(string[] args)
    {
        // describe program
        Console.WriteLine("This program will initialize an array of 10 integers" +
        " and fill it with random numbers. \nIt will print the element, it's value," +
        " and the cumulative total for all values.");
        // create random object
        // https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-9.0
        var rand = new Random();
        // declare an array to hold 10 random integers
        int[] numbers = new int[10];

        // declare total to hold total
        int total = 0;

        // create for loop for the 10 random integers
        for (int i = 0; i < numbers.Length; i++)
        {
            // generate a random number from 1-100 using rand, and set it to the index
            // print element and it's value
            numbers[i] = rand.Next(100);
            Console.Write($"Printing element {i} with value of {numbers[i]}. ");

            // add value to total and print total on same line, with new line at end
            total += numbers[i];
            Console.Write($"Running total: {total}\n");
        }
        
    }
}
