using System;
class OverFlowTest
{

    static short x = 32767;   // Max short value
    static short y = 32767;

    // Using a checked expression 
    static int CheckedMethod()
    {
        int z = 0;
        try
        {
            z = (short)(x + y);
        }
        catch (System.OverflowException e)
        {
            Console.WriteLine(e.ToString());
        }
        return z;
    }

    static void Main()
    {
        Console.WriteLine("Checked output value is: {0}",
                     CheckedMethod());
        Console.ReadKey();
    }
}
/*
    Output:
    System.OverflowException: Arithmetic operation resulted in an overflow.
       at OverFlowTest.CheckedMethod()
    Checked output value is: 0
 */