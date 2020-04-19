using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickStartRoundB
{



    class Program
    {


        static void solve(int t)
        {



            Console.Write("Case #{0}: ", t + 1);

            string[] s = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long n = long.Parse(s[0]);
            long d = long.Parse(s[1]);

            long[] x = new long[n];

            s = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; i++)
            {
                x[i] = long.Parse(s[i]);
            }


            long left = x[0];
            long right = d - d % x[0];        
            do
            {

                long l = calc(left, x);
                long r = calc(right, x);
                long m = calc((left + right +1) / 2, x);

                if(m>d)
                {
                    right = (left + right + 1) / 2 - 1;
                }
                else if(m<=d)
                {
                    left = (left + right  + 1) / 2 ;
                }

                

                
       
            } while (left<right);

            Console.WriteLine(left);
        }




        static long calc(long current, long []x)
        {
            long sum = 0;
            long cur_cpy = current;
            for (long i = 0; i < x.Length; i++)
            {
                sum += (x[i] - current % x[i]) % x[i];
                if (current % x[i] != 0)
                {
                    current = (current / x[i] + 1) * x[i];
                }
            }

            return cur_cpy + sum;
        }


        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                solve(i);
            }

            //Console.ReadKey();
        }
    }
}

