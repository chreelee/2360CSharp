/* 
Christine Lee COP 2360
Student ID 2509320
02 15 2025

Description: Create a program that, when given an n-sided regular polygon,
will return the total sum of internal angles in degrees. Will use a method
called SumPolygon that accepts an integer and returns a value based on
the value of n.

Collaboration Statement: worked alone using provided links and materials
dotnet microsoft documents
*/

namespace Assignment6;

class Program
{
    static void Main(string[] args)
    {
       // prompt user to enter the number of sides
       Console.Write("Enter a number of sides in a polygon to receive " +
       "the total sum of it's internal angles: ");
        // set it to int numOfSides, and convert to integer
        int numOfSides = Convert.ToInt32(Console.ReadLine());

        // invoke the SumPolygon method for result and print
        Console.Write($"The total sum of the internal angles of a polygon " +
        $"with {numOfSides} sides is: " + SumPolygon(numOfSides) + " degrees");
    }

    // create SumPolygon method
    public static int SumPolygon(int num)
    {
        // will take the number of sides and set to n
        int n = num;
        // initialize sum
        int sum;

        // get the sum using formula (n-2) * 180
        return sum = (n - 2) * 180;

    }

}
