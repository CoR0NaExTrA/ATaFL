using System;

class GCDProgram
{
    static int GCD( int a, int b )
    {
        while ( b != 0 )
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int a = int.Parse( input[ 0 ] );
        int b = int.Parse( input[ 1 ] );
        Console.WriteLine( GCD( a, b ) );
    }
}