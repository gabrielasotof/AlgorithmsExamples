using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsExamples
{
    class Program
    {
        static int MAX_CHAR = 256;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // string str1 = Console.ReadLine();
            //Console.WriteLine("result " + solution(1041));

            //Console.WriteLine("complement " + FindNumberSum(str1));
            //while (true) {
            //    int  str = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("result " + BinaryGap(str));
            //    //string str = Console.ReadLine();
            //    //Console.WriteLine(uniqueCharacters(str));

            //}
            int[] A = {1,2,4};
            int N = 5;
            Console.WriteLine(solution(N));

            string wait = Console.ReadLine();
        }

        public static int[] solution(int N ) {
            int[] A = new int[N];

            int l = N - 1;
            for (int i = l; i >= 0 ; i--)
            {
                Console.WriteLine(i);
                A[i] = N - i;
            }
         //   A.ToList().ForEach(i => Console.WriteLine(i.ToString()));
            return A;
        }


        public static int[] RotateArray(int[] A, int K) {
                
            int[] array1 = new int[K];
            int[] array2 = new int[A.Length - K ]; 
      
            Array.Copy(A, A.Length - K, array1, 0, K);
            Array.Copy(A, 0, array2, 0, A.Length - K );

            var r = new int[array1.Length + array2.Length];
            array1.CopyTo(r, 0);
            array2.CopyTo(r, array1.Length);

            return r;
        }

        public static int[] rotate(int[] A, int K) {
            int size = A.Length;
            int[] cyclic = new int[size];
            K %= size; // thanks to @Josiah for pointing on the case K>sze
            Console.WriteLine(K);
            for (int i = 0; i < size - K; ++i)
            {
                cyclic[K + i] = A[i];
            }

            for (int i = 0; i < K; ++i)
            {
                cyclic[i] = A[size - K + i];
            }
            return cyclic;
        }

        public static int FindNumberSum(string str)
        {
            int num = 0;
            //int[] a = { 1721, 979, 366, 299, 675, 1456 };
            IList<int> a = new List<int>(); 
            a = str.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
            IDictionary<int, bool> numbers = new Dictionary<int, bool>();

            foreach(int i in a){
                numbers.Add(i, true);

                int comp = 2020 - i;
                bool r = false;
                numbers.TryGetValue(comp, out r);
                if (r) {
                    return comp * i;
                }
            }
            return num;
        }

        public static int BinaryGap(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            char[] bi = Convert.ToString(N, 2).ToCharArray();
            Console.WriteLine("bi " + Convert.ToString(N, 2));
            int c = 0, total = 0;
            bool isOpen = false;
            bool isClose = true;
            for (int i = 0; i < bi.Length ; i++)
            {
                Console.WriteLine("bi " + Convert.ToString(bi[i]));
                Console.WriteLine("i " + Convert.ToString(i));
                if (bi[i] == '0')
                    c++;
                else
                {
                    isOpen = !isOpen;
                    Console.WriteLine("isOpen " + Convert.ToString(isOpen));
                    if (!isOpen && c > total)
                    {
                        isClose = !isClose;
                        total = c;
                        Console.WriteLine("Total " + Convert.ToString(total));
                    }
                       
                    c = 0;
                }
            }

            if (isOpen && !isClose && total == 0)
                return 1;

            return total;
        }

        private static bool uniqueCharacters(string str)
    {
        //// If length is greater than 256,
        //// some characters must have been repeated
        //if (str.Length > MAX_CHAR)
        //    return false;

        //bool[] chars = new bool[MAX_CHAR];
        //for (int i = 0; i < MAX_CHAR; i++)
        //{
        //    chars[i] = false;
        //}
        //for (int i = 0; i < str.Length; i++)
        //{
        //    Console.WriteLine("-");
        //    Console.WriteLine((int)str[i]);
        //    int index = (int)str[i];
        //    Console.WriteLine("-");

        //    /* If the value is already true, string
        //    has duplicate characters, return false */
        //    if (chars[index] == true)
        //        return false;

        //    chars[index] = true;
        //}

        ///* No duplicates encountered, return true */
        //return true;
        int checker = 0;

        for (int i = 0; i < str.Length; ++i)
        {
            int val = (str[i] - 'a');

            // If bit corresponding to current 
            // character is already set 
            Console.WriteLine("checker");
            Console.WriteLine(checker);
            Console.WriteLine("val");
            Console.WriteLine(val);
            Console.WriteLine("op");
            Console.WriteLine(1 << val);
            if ((checker & (1 << val)) > 0)
                return false;

            // set bit in checker 
            checker |= (1 << val);
        }

        return true;

    }

        private static int lastOdd(int[] A) 
        {
            int l = 0;
            IDictionary<int, int> n = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                var val = A[i];
                if (n.ContainsKey(val))
                {
                    int count = n[val];
                    count = count + 1;
                    if (count % 2 > 0)
                    {
                        l = val;
                    }
                }
                else
                {

                    n.Add(val, 1);
                    l = val;
                }
            }

            return l;
        }

        public static int findMissing(int[] A)
        {
            int N = A.Length;
            int higherValue = 1;
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum = sum + A[i];
                if (A[i] > higherValue)
                    higherValue = A[i];
            }
            return ((higherValue * (higherValue + 1) / 2) - sum);
        }

    }
}
