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
        private bool negExp = false;

        //convert to string for output
        /*public static implicit operator string(infFloat in1)
        {
            string buffer;
            foreach (var x in in1.mantissa)
            {
                buffer 
            }
        }*/

        //convert long int literal to infFloat
        public static implicit operator infFloat(Int64 in1)
        {
            bool fuse = true;
            byte count = 0;
            infFloat current = new infFloat();

            //check for negative 
            if (in1 < 0)
            {
                current.negative = true;
                in1 *= -1;
            }

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

            return current;
        }

        //convert infFloat to string for output
        public static implicit operator string(infFloat in1)
        {
            string[] buffer = new string[2];

            foreach (var x in in1.mantissa)
            {
                buffer[0] = x + buffer[0];
            }
            if (buffer[0] == null)
            {
                buffer[0] = "0";
            }
            else {
                if (in1.negative)
                {
                    buffer[0] = "-" + buffer[0];
                } 
            }

            foreach (var x in in1.exponent)
            {
                buffer[1] = x + buffer[1];
            }
            if (buffer[1] == null)
            {
                buffer[1] = "0";
            }
            else
            {
                if (in1.negExp)
                {
                    buffer[1] = "-" + buffer[1];
                }
            }


            return buffer[0] + "*10^" + buffer[1];
        }

        //addition override
        /*public static infFloat operator +(infFloat in1, infFloat in2)
        {

        }*/

        //convert infFloat to string for output
        // TODO finish 
        /*public static string ToDecimalStrLossy(infFloat in1)
        {
            string buffer = "";
            
            foreach (var x in in1.mantissa)
            {
                buffer = x + buffer;
            }

            for (long i = 0; i < in1.exponent.Count; i++)
            {
                
            }

            return buffer;
        }*/
    }
}
