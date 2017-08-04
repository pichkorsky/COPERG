using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class Generator_of_combinations
    {
        readonly string[] s;
        readonly Combinations_Vault c_vault;
        private int cntr;

        public Generator_of_combinations(string[] s)
        {
            this.s = s;
            c_vault = new Combinations_Vault();
            cntr = 0;
            generator_of_combinations();
        }

        private void generator_of_combinations()
        {              

            for (int size_m = s.Length; size_m > 1; size_m--)
            {
                comb_alg(s, c_vault, size_m);
            }
            
        }

        private void comb_alg(string[] s, Combinations_Vault v, int size_m)
        {
            int top_index = s.Length;

            int[] combination = new int[size_m];

            for (int i = 0; i < size_m; i++)
            {
                combination[i] = i;
            }

            v.store_Combination(s, combination);
            cntr++;


            for (int i = size_m-1; i >= 0; i--)
            {
                if (i != size_m - 1)
                {
                    for (int currInd = (i+1); currInd <= (size_m -1); currInd++)
                    {
                        combination[currInd] = (combination[currInd - 1] + 1);
                        //TODO: all following elements are set to value of their previous neighbor plus 1 
                    }
                }
                while (combination[i] < (top_index - size_m + i))
                {
                    combination[i]++;
                    v.store_Combination(s, combination);
                    cntr++;
                }
            }
        }

        public int getCntr()
        {
            return cntr;
        }

        public string[][] getResult()
        {
            return c_vault.getCombinations();
        }


    }
    
}
