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

           

            Console.Write("Case #{0}: ", t+1);


            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            string [] s = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(s[i]);
            }
            int count = 0;
            for(int j = 1; j<=arr.Length-2;j++)
            {
                if(arr[j]>arr[j-1]&&arr[j]>arr[j+1])
                {
                    count++;
                }
            }
            Console.WriteLine(count);


            

            



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

