using System;
using System.Text;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Task 1 */
            bool isHas = false;
            byte bit1 = 1;
            sbyte bit2 = -128;
            short n1 = 1;
            ushort n2 = 102;
            int a = -1032334;
            uint b = 2314124525;
            long c = 3214124214;
            ulong d = 21312312;
            double dNum = 23.4;
            float F = 3.123f;
            decimal dNum1 = 23.1123m;
            char symbol = 'a';
            string words = "abcdefg";
            object oobj1 = "example";
            object oobj2 = 3.14;

            byte exp1 = 2;
            uint expf1 = exp1;
            int exp2 = 4;
            float expf2 = exp2;
            float exp3 = 89;
            double expf3 = exp3;
            ulong exp4 = 3239;
            float expf4 = exp4;
            char exp5 = 'b';
            decimal expf5 = exp5;

            double exp6 = 4.9;
            decimal expf6 = (decimal)exp6;
            float exp7 = 1.34f;
            double expf7 = (double)exp7;
            int exp8 = -4;
            sbyte expf8 = (sbyte)exp8;
            int exp9 = 23;
            short expf9 = (short)exp9;
            char exp0 = 'v';
            decimal expf0 = (decimal)exp0;

            int id = 123;
            object o = id;

            int l = (int)o;

            var ig = 12;     // переменная ig инициализируется целочисленным литералом
            var dg = 12.3;   // переменная dg инициализируется литералом с плавающей точкой,
                            // имеющему тип double
            var f = 0.34F;  // переменная f теперь имеет тип float

            int? x1 = null;
            Nullable<int> x2 = null;

            /* Task 2 */

            string firstWord = "firstTest";
            string secondWord = "secondTest";
            int n = string.Compare(secondWord, firstWord);
            /*Console.WriteLine(n);*/


            string fWord = "fWord";
            string sWord = "sWord";
            string tWord = "tWord";
            string concatStr = String.Concat(fWord, sWord, tWord);
            Console.WriteLine(concatStr);

            string copyStr = String.Copy(concatStr);
            Console.WriteLine(copyStr);

            int startIndex = 3;
            string subStr = copyStr.Substring(startIndex);
            Console.WriteLine(subStr);

            string testStr = "Programming is so";
            Console.WriteLine("Before " + testStr);
            string[] testWords = testStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("After");
            foreach (string s in testWords)
            {
                Console.WriteLine(s);
            }

            string text = " amazing";
            text = testStr.Insert(17, text);
            Console.WriteLine(text);

            Console.WriteLine("Введите подстроку: ");
            string rmSubstr = Console.ReadLine();
            int indexRm = text.IndexOf(rmSubstr);
            string rmStr = text.Remove(indexRm, rmSubstr.Length);
            Console.WriteLine(rmStr);

            string emptyStr = String.Empty;
            string nullStr = null;
            int ind = emptyStr.Length;
            string en = emptyStr + nullStr;
            Console.WriteLine(en);

            /*Удаленние позиции*/
            StringBuilder buildStr = new StringBuilder("Hello, World");
            buildStr = buildStr.Remove(4, 1);
            /*Вставка в начало и в конец*/
            buildStr.Append("x");
            buildStr.Insert(0, "x");
            Console.WriteLine(buildStr);


            /*Task 3*/
            int[,] numsArr = new int[2, 3];
            Random random = new Random();
            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    numsArr[i, j] = random.Next(10);
                    Console.Write(numsArr[i, j] + " ");
                }
                Console.WriteLine();
            }
            string[] daysOfWeek = { "Sunday", "Monday", "Tuersday","Wednesday", "Thirsday", "Friday", "Saturday" };
            int length = daysOfWeek.Length;
            Console.WriteLine(length);
            for(int i = 0; i < length; i++)
            {
                Console.Write(daysOfWeek[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Введите заменяемый элемент: ");
            string removeWord = Console.ReadLine();
            Console.WriteLine("Введите позицию: ");
            int pos = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                if (i == pos)
                {
                    daysOfWeek[i] = removeWord;
                }
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write(daysOfWeek[i] + " ");
            }
            Console.WriteLine();

            int[][] newArr = new int[3][];
            newArr[0] = new int[2];
            newArr[1] = new int[3];
            newArr[2] = new int[4];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < newArr[i].Length; j++)
                {
                    Console.WriteLine("Введите элемент: ");
                    newArr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < newArr[i].Length; j++)
                {
                    Console.Write(newArr[i][j] + " ");
                }
                Console.WriteLine();
            }

            var ads = new[] { 0, 1, 2 };
            var strGang = new[] { "abc", "dcef" };

            /*Task 4*/
            int elm1 = 12;
            string elm2 = "Gang";
            char elm3 = 'G';
            string elm4 = "Gangsta";
            ulong elm5 = 23;

            var tuple = Tuple.Create<int, string, char, string, ulong>(elm1, elm2, elm3, elm4, elm5);
            var tupleTest = Tuple.Create<int, string, char, string, ulong>(elm1, elm2, elm3, elm4, elm5);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);
            Console.WriteLine(tuple.Item1 + tuple.Item2 + tuple.Item3 + tuple.Item4 + tuple.Item5);

            int em1 = (int)tuple.Item1;
            string em2 = (string)tuple.Item2;
            char em3 = (char)tuple.Item3;
            string em4 = (string)tuple.Item4;
            ulong em5 = (ulong)tuple.Item5;

            if (tuple == tupleTest)
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not equals");
            }

            int[] arrFoo = { 2, 13, 52, 12, 9, 1 };
            Console.WriteLine(foo(arrFoo, elm2));

            static Tuple<int, int, int, char> foo(int[] a,string b)
            {
                int max = 0, min = 99, sum = 0;
                char s;
                foreach(int k in a)
                {
                    if( k > max )
                    {
                        max = k;
                    }
                    if( k < min )
                    {
                        min = k;
                    }
                    sum += k;
                }
                s = b[0];
                var tuples = Tuple.Create<int, int, int, char>(min, max, sum, s);
                return tuples;
            }
        }
    }
}
