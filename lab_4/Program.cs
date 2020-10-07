using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AnonymousMethods
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            SinyakList q = new SinyakList(5);
            Console.WriteLine("First init -> ");
            for (int i = 0; i < q.listSize; i++)
            {
                q[i] = Console.ReadLine();
            }

            q = q + "xxx";

            Console.WriteLine("------------------------------");

            for (int i = 0; i < q.listSize; i++)
            {
                Console.WriteLine(q[i]);
            }

            Console.WriteLine("------------------------------");

            --q;

            for (int i = 0; i < q.listSize; i++)
            {
                Console.WriteLine(q[i]);
            }

            SinyakList w = new SinyakList(6);

            Console.WriteLine("Second init -> ");

            for (int i = 0; i < w.listSize; i++)
            {
                w[i] = Console.ReadLine();
            }

            Console.WriteLine("------------------------------");

            if (w != q)
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }

            Console.WriteLine("------------------------------");

            q = q * w;

            for (int i = 0; i < q.listSize; i++)
            {
                Console.WriteLine(q[i]);
            }

            Console.WriteLine("------------------------------");

            SinyakList.Date dateOfCreate = new SinyakList.Date();
            SinyakList.Owner owner = new SinyakList.Owner();

            dateOfCreate.GetDate();
            owner.GetAuthorName();

            string  testStr = "qWWWWWWWW";
            int a = testStr.UpperCount();
            Console.WriteLine("----------------------------");
            Console.WriteLine(a);
            Console.WriteLine("----------------------------");

            if (q.CheckTwins())
            {
                Console.WriteLine("list consist same elements");
            }
            else
            {
                Console.WriteLine("no same elements");
            }
        }
    }

    class SinyakList
    {
        string[] ownList;
        public int listSize;

        public SinyakList(int size)
        {
            ownList = new string[size];
            listSize = size;
        }

        public string this[int index]
        {
            get
            {
                return ownList[index];
            }
            set
            {
                ownList[index] = value;
            }
        }


        public class Owner
        {
            string name;
            string surname;

            public Owner(string name = "Kirill", string surname = "Sinkevich")
            {
                this.name = name;
                this.surname = surname;
            }

            public string Name
            {
                get
                {
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    return surname;
                }
            }

            public void GetAuthorName() => Console.WriteLine($"Prod. by {name} {surname}");
        }

        public class Date
        {
            int day;
            int month;
            int year;

            public Date(int day = 6, int month = 10, int year = 2020)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public int Day
            {
                get
                {
                    return day;
                }
                set
                {
                    if (value >= 1 && value <= 31)
                    {
                        day = value;
                    }
                    else
                    {
                        day = 6; //день когла писал лабу
                    }
                }
            }

            public int Month
            {
                get
                {
                    return month;
                }
                set
                {
                    if (value >= 1 && value <= 12)
                    {
                        month = value;
                    }
                    else
                    {
                        month = 10; //месяц когда писал лабу
                    }
                }
            }

            public int Year
            {
                get
                {
                    return year;
                }
                set
                {
                    year = value;
                }
            }

            public void GetDate() => Console.WriteLine($"{day}.{month}.{year}");
        }

        public static SinyakList operator +(SinyakList list, string value)
        {
            AddElement(ref list.ownList, value);
            list.listSize++;
            return list;
        }

        public static SinyakList operator --(SinyakList list)
        {
            RemoveElement(ref list.ownList);
            list.listSize--;
            return list;
        }

        public static bool operator !=(SinyakList list1, SinyakList list2)
        {
            bool isEqual = false;

            if (list1.listSize != list2.listSize) return false;

            for (int i = 0; i < list1.listSize; i++)
            {
                if (list1.ownList[i] != list2.ownList[i]) isEqual = true;
                else return false;
            }
            return isEqual;
        }

        public static bool operator ==(SinyakList list1, SinyakList list2)
        {
            bool isEqual = false;

            if (list1.listSize != list2.listSize) return false;

            for (int i = 0; i < list1.listSize; i++)
            {
                if (list1.ownList[i] == list2.ownList[i]) isEqual = true;
                else return false;
            }

            return isEqual;
        }
        public static SinyakList operator *(SinyakList list1, SinyakList list2)
        {
            UniteList(ref list1.ownList, list2.ownList);
            list1.listSize += list2.listSize;
            return list1;
        }

        private static void UniteList(ref string[] l1, string[] l2)
        {
            string[] newData = new string[l1.Length + l2.Length];

            for (int i = 0; i < l1.Length; i++)
            {
                newData[i] = l1[i];
            }
            for (int i = l1.Length - 1, j = 0; j < l2.Length; j++, i++)
            {
                newData[i] = l2[j];
            }

            l1 = newData;
        }

        private static void AddElement(ref string[] taskArray, string value)
        {
            string[] newData = new string[taskArray.Length + 1];

            for (int i = 0; i < newData.Length; i++)
            {
                if (i != newData.Length - 1)
                {
                    newData[i] = taskArray[i];
                }
                else
                {
                    newData[i] = value;
                }
            }
            taskArray = newData;
        }

        private static void RemoveElement(ref string[] taskArray)
        {
            string[] newData = new string[taskArray.Length - 1];

            for (int i = 1; i < taskArray.Length; i++)
            {
                newData[i - 1] = taskArray[i];
            }

            taskArray = newData;
        }
    }

    static class StatisticOperation
    {
        public static int GetSumAndCount(SinyakList list)
        {
            return list.listSize;
        }

        public static int MinMaxDifference(SinyakList b)
        {
            int min = b[0].Length, max = 0;

            for (int i = 0; i < b.listSize; i++)
            {
                if (b[i].Length > max)
                {
                    max = b[i].Length;
                }
                if (b[i].Length < min)
                {
                    min = b[i].Length;
                }
            }

            return max - min;
        }

        public static int UpperCount(this string str)
        {
            int upperCounter = 0;

            for (int i = 0; i < str.Length; i++)
            {
                upperCounter = (str[i] > 65 && str[i] < 90) ? upperCounter + 1 : upperCounter;
            }

            return upperCounter;
        }

        public static bool CheckTwins(this SinyakList list)
        {
            bool isHere = true;

            for (int i = 0; i < list.listSize; i++)
            {
                for (int j = i; j < list.listSize - 1; j++)
                {
                    if (list[i] == list[j + 1]) return true;
                    else isHere = false;
                }
            }

            return isHere;
        }
    }
}