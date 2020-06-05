using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Xml;

namespace infiniteDecimalRepresentation
{
    class infFloat
    {
        // Represent numbers backwards ex. 1995 = [5,9,9,1,0,...]
        private List<byte> mantissa = new List<byte>();
        private List<byte> exponent = new List<byte>(); // only used to show where decimal is
        private bool negative = false;

        //convert to string for output
        /*public static implicit operator string(infFloat in1)
        {
            string buffer;
            foreach (var x in in1.mantissa)
            {
                buffer 
            }
        }*/

        //convert unsigned long int literal to infFloat
        public static implicit operator infFloat(UInt64 in1)
        {
            bool fuse = true;
            byte count = 0;
            infFloat current = new infFloat();
            while (in1 != 0)
            {
                //removes inital 0's ex. 1000 -> 1.0*10^3
                if (fuse == true & in1 % 10 == 0)
                {
                    try
                    {
                        current.exponent[0] += 1;
                    } 
                    catch (ArgumentOutOfRangeException)
                    {
                        current.exponent.Add(1);
                    }

                    for (int x = 0; x < current.exponent.Count; x++)
                    {
                        if (current.exponent[x] == 10)
                        {
                            current.exponent[x] = 0;
                            try
                            {
                                current.exponent[x + 1] += 1;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                current.exponent.Add(1);
                            }

                        }
                    }
                }
                else
                {
                    fuse = false;

                    //add the actual body
                    current.mantissa.Add((byte)(in1 % 10));
                }
                in1 /= 10;
            }
            

            // DEBUG
            String debug = "";
            foreach (var x in current.exponent)
            {
                debug = x + debug;
            }
            debug = "*10^" + debug;
            foreach (var x in current.mantissa)
            {
                debug = x + debug;
            }
            Console.WriteLine(debug);


            return current;
        }
        //public static infFloat operator +(infFloat in1, infFloat in2)
        //{

        //}
    }
}
