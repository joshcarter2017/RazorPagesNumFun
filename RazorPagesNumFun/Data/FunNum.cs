using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesNumFun.Data
{
    public static class FunNum
    {
        public static bool IsPrime(int i)
        {
            if (PrimeFactors(i).Count > 1)
                return false;
            return true;
        }
        public static bool IsPerfect(int i)
        {
            int sum = 1;
            for (int k = 0; k < PrimeFactors(i).Count; k++)
                sum += PrimeFactors(i)[k];
            if (sum == i)
                return true;
            return false;
        }
        public static bool IsSquareful(int i)
        {
            bool rep = false;
            for (int k = 1; k < PrimeFactors(i).Count; k++)
            {
                if (PrimeFactors(i)[k] == PrimeFactors(i)[k - 1])
                    rep = true;
            }
            if (rep)
                return true;
            return false;
        }
        public static bool IsSquarefull(int i)
        {
            if (!IsSquareful(i))
                return false;
            bool rep = true;
            if (PrimeFactors(i).Count > 2)
            {
                for (int k = 1; k < PrimeFactors(i).Count - 1; k++)
                {
                    if (PrimeFactors(i)[k] != PrimeFactors(i)[k - 1] && PrimeFactors(i)[k] != PrimeFactors(i)[k + 1])
                        rep = false;
                }
                if (PrimeFactors(i).Count - 1 != PrimeFactors(i).Count - 2)
                    rep = false;
            }
            else
            {
                if (PrimeFactors(i)[0] != PrimeFactors(i)[1])
                    rep = false;
            }
            if (rep)
                return true;
            return false;
        }
        public static bool IsPalindromic(int i)
        {
            bool pal = true;
            if (i < 0)
                i *= -1;
            char[] PalInts = i.ToString().ToCharArray();
            for (int k = 0; k < PalInts.Length / 2; k++)
            {
                if (PalInts[k] != PalInts[(PalInts.Length - 1) - k])
                    pal = false;
            }
            
            if (pal)
                return true;
            return false;
        }

        public static List<int> PrimeFactors(int i)
        {
            /* Basic Algorithm found here:
             *      https://www.geeksforgeeks.org/print-all-prime-factors-of-a-given-number/
             * pretty much just add to a list instead of printing
             * you know, code reuse and all that */

            List<int> PFacs = new List<int>();

            //get all 2s
            while (i % 2 == 0)
            {
                PFacs.Add(2);
                i /= 2;
            }

            //get all others
            for (int k = 3; k<= Math.Sqrt(i); k++)
            {
                while (i % k == 0)
                {
                    PFacs.Add(k);
                    i /= k;
                }
            }

            //if n is prime and > 2
            if (i > 2)
                PFacs.Add(i);

            //return
            return PFacs;
        }
        public static String PrimeFactorsString(int i)
        {
            String Primes = "[ ";
            for (int k = 0; k < FunNum.PrimeFactors(i).Count - 1; k++)
            {
                Primes += (FunNum.PrimeFactors(i)[k] + ", ");
            }
            Primes += (FunNum.PrimeFactors(i)[FunNum.PrimeFactors(i).Count - 1] + " ]");
            return Primes;
        }

    }
}
