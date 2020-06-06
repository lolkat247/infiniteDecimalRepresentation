using System;
using infiniteDecimalRepresentation;


namespace infiniteDecimalRepresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // int Test section //

            //test 0
            infFloat cur = 0;
            Console.WriteLine(cur);

            //test exponent
            infFloat cur2 = 100;
            Console.WriteLine(cur2);

            //test mantissa
            infFloat cur3 = 123456789L;
            Console.WriteLine(cur3);

            //test negative
            infFloat cur4 = -123;

            //test all
            infFloat cur5 = -5202000000L;
            Console.WriteLine(cur5);

        }
    }
}
