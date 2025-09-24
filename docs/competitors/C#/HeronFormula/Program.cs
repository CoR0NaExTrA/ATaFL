using System;

struct Point2D
{
    public double X, Y;
    public Point2D( double x, double y ) { X = x; Y = y; }
}

class HeronFormulaProgram
{
    static double Distance( Point2D a, Point2D b )
    {
        return Math.Sqrt( ( a.X - b.X ) * ( a.X - b.X ) + ( a.Y - b.Y ) * ( a.Y - b.Y ) );
    }

    static void Main()
    {
        string[] parts = Console.ReadLine().Split();
        Point2D A = new Point2D( double.Parse( parts[ 0 ] ), double.Parse( parts[ 1 ] ) );
        Point2D B = new Point2D( double.Parse( parts[ 2 ] ), double.Parse( parts[ 3 ] ) );
        Point2D C = new Point2D( double.Parse( parts[ 4 ] ), double.Parse( parts[ 5 ] ) );

        double a = Distance( B, C );
        double b = Distance( A, C );
        double c = Distance( A, B );

        double s = ( a + b + c ) / 2.0;
        double area = Math.Sqrt( s * ( s - a ) * ( s - b ) * ( s - c ) );
        Console.WriteLine( area );
    }
}
