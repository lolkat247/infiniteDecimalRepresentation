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
            infFloat cur2 = 10;
            Console.WriteLine(cur2);

            //test mantissa
            infFloat cur3 = 123456789L;
            Console.WriteLine(cur3);

            //test both
            infFloat cur4 = 520200000000000000L;
            Console.WriteLine(cur4);

        }
    }
}
