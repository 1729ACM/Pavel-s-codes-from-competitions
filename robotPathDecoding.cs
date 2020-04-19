using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickStartRoundB
{


    class Tree
    {

        public Tree left = null;
        public Tree right = null;

        public string val;

        public Tree(string val)
        {
            this.val = val;
        }
    }




    class Program
    {
        static void buildTree(ref Tree current, string s)
        {
            current = new Tree(s);

            if (s.Length <= 1)
            {
                return;
            }
            int i = 0;
            char c = s[0];
            for (i = 0; i < s.Length; i++)
            {
                c = s[i];
                if (c >= '2' && c <= '9' || c == '(')
                {
                    break;
                }
            }

            if (i == s.Length)
            {
                return;
            }

            string s1, s2;
            if (c >= '2' && c <= '9' && i == 0)
            {

                long count = 0;
                for (int t = i + 1; t < s.Length; t++)
                {
                    char cc = s[t];

                    if (cc == ')')
                    {
                        count--;
                    }
                    else if (cc == '(')
                    {
                        count++;
                    }
                    if (count == 0)
                    {
                        i = t;
                        break;
                    }
                }
                if (i == s.Length - 1)
                {
                    s1 = s.Substring(0, 1);
                    s2 = s.Substring(1);
                }
                else
                {
                    s1 = s.Substring(0, i + 1);
                    s2 = s.Substring(i + 1);
                }

            }
            else if (c == '(' && i == 0)
            {
                long count = 0;
                for (int t = i; t < s.Length; t++)
                {
                    char cc = s[t];

                    if (cc == ')')
                    {
                        count--;
                    }
                    else if (cc == '(')
                    {
                        count++;
                    }
                    if (count == 0)
                    {
                        i = t;
                        break;
                    }
                }

                s1 = s.Substring(0, i + 1);
                s1 = s1.Substring(0, s1.Length - 1);
                s1 = s1.Substring(1);
                s2 = s.Substring(i + 1);
            }
            else
            {
                s1 = s.Substring(0, i);
                s2 = s.Substring(i);
            }

            buildTree(ref current.left, s1);
            buildTree(ref current.right, s2);
        }

        static long m = 1000000000;

        static long[] calc(Tree root)
        {
            if (root.left == null & root.right == null)
            {
                if (root.val.Length == 1 && root.val[0] >= '2' && root.val[0] <= '9')
                {
                    return new long[] { long.Parse(root.val) };
                }
                else
                {
                    long x = 0;
                    long y = 0;

                    for (int i = 0; i < root.val.Length; i++)
                    {
                        char s = root.val[i];

                        switch (s)
                        {
                            case 'N': y = (y - 1) % m; break;
                            case 'S': y = (y + 1) % m; break;
                            case 'W': x = (x - 1) % m; break;
                            case 'E': x = (x + 1) % m; break;


                        }
                    }

                    return new long[] { x % m, y % m };
                }
            }
            else
            {
                if (root.left != null)
                {
                    long[] l = calc(root.left);

                    if (root.right != null)
                    {
                        long[] r = calc(root.right);

                        if (l.Length == 1)
                        {
                            return new long[] { (l[0] * r[0]) % m, (l[0] * r[1]) % m };
                        }
                        else if (r.Length == 1)
                        {
                            return new long[] { (r[0] * l[0]) % m, (r[0] * l[1]) % m };
                        }
                        else
                        {
                            return new long[] { (r[0] + l[0]) % m, (r[1] + l[1]) % m };
                        }
                    }
                    else
                    {
                        return l;
                    }

                }
                else
                {
                    return calc(root.right);
                }



            }
        }
        static void solve(long t)
        {



            string s = Console.ReadLine();


            Tree root = null;

            buildTree(ref root, s);

            long[] res = calc(root);


            Console.WriteLine("Case #{0}: {1} {2}", t + 1, 1 + (res[0] + m) % m, 1 + (m + res[1]) % m);




        }





        static void Main(string[] args)
        {
            long t = long.Parse(Console.ReadLine());
            for (long i = 0; i < t; i++)
            {
                solve(i);
            }

            Console.ReadKey();
        }
    }
}

