using System;

class FizzBuzzProgram
{
    static void Main()
    {
        string line;
        while ( ( line = Console.ReadLine() ) != null )
        {
            if ( int.TryParse( line, out int n ) )
            {
                if ( n % 3 == 0 && n % 5 == 0 )
                    Console.WriteLine( "FizzBuzz" );
                else if ( n % 3 == 0 )
                    Console.WriteLine( "Fizz" );
                else if ( n % 5 == 0 )
                    Console.WriteLine( "Buzz" );
                else
                    Console.WriteLine( n );
            }
        }
    }
}