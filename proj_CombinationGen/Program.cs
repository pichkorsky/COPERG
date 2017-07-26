using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                dowork();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           
        }

        static void dowork()
        {            


            string[] tstInput =
                {
                "A",
                "B",
                "C",
                "D"
            };

            Permutations.generate_Permutations(tstInput);


            Console.WriteLine(Permutations.Counter);
        }        
    }
}
