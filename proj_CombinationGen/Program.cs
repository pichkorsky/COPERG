using System;
using static System.Console;
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
                //dowork();

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
                "D",
            };
            
            Generator_of_combinations combGen = new Generator_of_combinations(tstInput);
            string[][] arr = combGen.getResult();

            for (int currInd = 0; currInd < combGen.getCntr(); currInd++)
            {            
                WriteLine(String.Join(" ", arr[currInd]));
            }

            WriteLine(combGen.getCntr());









            /*
            Permutations.generate_Permutations(tstInput);


            Console.WriteLine(Permutations.Counter);*/
        }        
    }
}
