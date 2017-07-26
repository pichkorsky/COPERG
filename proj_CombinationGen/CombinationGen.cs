using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Console;

namespace Permutations
{
    static public class Permutations       
    {
        static public long Counter = 0;        


        static public void generate_Permutations(string[] source)
        //TODO: disconnect proccess of generating combinations from calls to permutation algorithm to enable farther work distribution between threeds + feature(ignore part of combinations)
        {
            if (source == null || source.Length == 0)
            {
                throw new ArgumentNullException("nothing to work with");
            }

            string path = $@"CombinationList_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt";

            string resultString = "";
            Vault vault1 = new Vault(path);

            permutation_algorithm(source, 0, source.Length - 1, vault1);
            

            for (int k = 1; k <= source.Length - 1; k++)
            {
                for (int i = 0; i <= source.Length-1; i++)
                {
                    string[] particularCombination;
                    prepCombination(out particularCombination, source, k, i);                   
                    
                    permutation_algorithm(particularCombination, 0, particularCombination.Length - 1, vault1);
                    vault1.dumpIfNecessary();
                    
                }

                File.AppendAllText(path, resultString);
                resultString = "";
            }
        }

        static private void prepCombination(out string[] modArr, string[] s, int howManyRemove, int indToStartRemovingFrom)
        {
            modArr = new string[s.Length-howManyRemove];
            int modArrIndex = 0;
            
            for (int i = 0; i <= s.Length-1; i++)
            {
                if ((indToStartRemovingFrom + howManyRemove -1) > s.Length -1) //checks for removing index ofverflow
                {
                    if (i < indToStartRemovingFrom && i > (indToStartRemovingFrom + howManyRemove -1 - s.Length))
                    {
                        modArr[modArrIndex] = s[i];
                        modArrIndex++;
                    }
                }
                else
                {
                    if (i < indToStartRemovingFrom || i > (indToStartRemovingFrom + howManyRemove - 1))
                    {
                        modArr[modArrIndex] = s[i];
                        modArrIndex++;
                    }
                        
                }
                    
            }
        
        }

        static private void permutation_algorithm(string[] s, int i, int n, Vault vault)
        {
            if (i == n)
            {
                vault.store_result(s);
                Counter++;
            }
            else
            {
                for (int j = i; j <= n; j++)
                {
                    string tmp = s[j];
                    s[j] = s[i];
                    s[i] = tmp;

                    permutation_algorithm(s, i + 1, n, vault);

                    tmp = s[j];
                    s[j] = s[i];
                    s[i] = tmp;

                }
            }

        }

        private class Vault
        {
            ushort counter;
            readonly string path;
            string[] resultsArr;

            public Vault(string path)
            {
                counter = 0;
                resultsArr = new string[ushort.MaxValue];
                this.path = path;
            }

            public void store_result(string[] incomingResultArr)
            {
                resultsArr[counter] = string.Join("",incomingResultArr) + Environment.NewLine;

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
            
    }
}
