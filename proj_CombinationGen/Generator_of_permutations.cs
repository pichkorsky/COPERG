using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    static public partial class Permutations
    {
        static private void permutation_algorithm(string[] s, int i, int n, Permutations_Vault vault)
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
    }
}
