using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Console;

namespace Permutations
{
     static public partial class Permutations       
    {
        static public long Counter = 0;


        static public void generate_Permutations(string[] source)
        //TODO: disconnect proccess of generating combinations from calls to permutation algorithm to enable farther work distribution between threeds + feature(ignore part of combinations)
        {

            CheckParams(source);
            

            string path = $@"CombinationList_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt";
                        
            Permutations_Vault p_vault = new Permutations_Vault(path);

            permutation_algorithm(source, 0, source.Length - 1, p_vault);
            

            for (int k = 1; k <= source.Length - 1; k++)
            {
                for (int i = 0; i <= source.Length-1; i++)
                {
                    string[] particularCombination;
                    prepCombination(out particularCombination, source, k, i);                   
                    
                    permutation_algorithm(particularCombination, 0, particularCombination.Length - 1, p_vault);
                    p_vault.dumpIfNecessary();
                    
                }
            }
        }

        static private void CheckParams(string[] source)
        {
            if (source == null || source.Length == 0)
            {
                string errorMsg = "Permutation generator exited. Null or zero length argument was passed.";
                throw new ArgumentException(errorMsg);
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
        
            
    }
}
