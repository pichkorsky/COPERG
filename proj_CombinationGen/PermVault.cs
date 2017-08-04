using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class Permutations_Vault
    {
        ushort counter;
        readonly string path;
        string[] resultsArr;

        public Permutations_Vault(string path)
        {
            counter = 0;
            resultsArr = new string[ushort.MaxValue];
            this.path = path;
        }

        public void store_result(string[] incPermArr)
        {
            resultsArr[counter] = string.Join("", incPermArr) + Environment.NewLine;

            if (counter < ushort.MaxValue - 1)
                counter++;
            else
                self_dump();
        }


        private void self_dump()
        {
            var res_string = string.Join($"", resultsArr, 0, counter);
            reset_counter();

            File.AppendAllText(path, res_string);

        }

        public void dumpIfNecessary()
        {
            if (counter != 0)
            {
                self_dump();
            }

        }

        private void reset_counter()
        {
            this.counter = 0;
        }
    }

    class Combinations_Vault
        //TODO: implement retreiving of items
    {
        ushort counter;
        int counter_max = ushort.MaxValue;
                
        string[][] combinationsArr;


        public Combinations_Vault()
        {
            counter = 0;
            combinationsArr = new string[counter_max][];            
        }

        public void store_Combination(string[] s, int[] combPatter)
        {
            string[] combination = new string[combPatter.Length];

            for (int i = 0; i < combPatter.Length; i++)
            {
                combination[i] = s[combPatter[i]];
            }

            combinationsArr[counter] = combination;

            if (counter < counter_max - 1)
                counter++;
            else
                self_dump();
        }

        public string[][] getCombinations()
        {
            return combinationsArr;
        }


        private void self_dump()
        {
            string exceptionErrMsg = "To many combinations - combinations vault is full" +
                Environment.NewLine + "Dump of combinations valuts is not implemented";

            throw new Exception(exceptionErrMsg);
        }


    }
}
