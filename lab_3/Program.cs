using System;

namespace MyProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = 3;
            int aCount = 0;
            int bUni = 0;
            int a = 13;
            int b = 14;
            Product Milk = new Product(3);
            Product Joy = new Product(2);
            Product Grey = new Product(7);
            Product Shark = new Product { Name = "Akula"};

            Console.WriteLine("Хеш-код объекта ----- " + Milk.GetHashCode());
            Console.WriteLine("Хеш-код объекта ----- " + Joy.GetHashCode());
            Console.WriteLine("Строковое представление объекта ----- " + Shark.ToString());

            Console.WriteLine("Тип объекта ----- " + Milk.GetType());

            Console.WriteLine("Сравнение двух объектов ----- " + Grey.Equals(Shark));

            Milk.outInfo();
            
            Joy.outInfo();
            Console.WriteLine(Milk.countMan(2, ref aCount));
            
            Milk.uniCode(23, 312, out bUni);
            Product.outInfoOfElm();

            Product[] arrayOfObject = new Product[]
            {
                new Product(3),
                new Product(6),
                new Product(9),
                new Product(2),
                new Product(7),
                new Product(8),
                new Product(5),
            };
            Product.outInfoOfarr(arrayOfObject);
            Product.InfoWithCondition(arrayOfObject);

            Console.WriteLine("Анонимный тип - " + test.GetType());
            
            Milk.sumCost(ref a, ref b);
        }
    }
    partial class Product
    {
        Random random = new Random();

        public readonly double Key = 123;
        int _id;    //Id
        string _name ;    // Наименование
        long _UPC;     // UPC
        int _cost;     // Cost
        string _manufacturer;   //Производитель
        int _shelfLife;    //Срок годности
        int _count;      //Количество
        static int Hash; // Hash 
        public static int countElements;
        
        
        public const short maxCountOfProducts = 255;
        public static string[] countOfConstructors;
        public static string[] arrOfName;

        //Constructors
        static Product()
        {
            int ID_SEED = 12324124;
            int Haash = ID_SEED.GetHashCode();
        }
        public Product(int shelfLife) 
        {
            _shelfLife = shelfLife;
            arrOfName = new string[] { "Milk", "Water", "Melon", "Juice", "Patato", "Orange" };
            countOfConstructors = new string[] { "Mils", "Mondelez", "ADM", "Hershey", "KraftHeinz" };
            int indexName = random.Next(0, 5);
            int indexOf = random.Next(0, 4);
            _manufacturer = countOfConstructors[indexOf];
            _name = arrOfName[indexName];
            countElements++;
            _count = random.Next(10, 35);
            _id = random.Next(10);
            _UPC = random.Next(12434);
            _cost = random.Next(0, 500);
        }
        public Product()
        {
            
            _UPC = random.Next(12434);
            countElements++;
        }
        public Product(int shelfTime, int Count) 
        {
            _count = Count;
            _shelfLife = shelfTime;
            countElements++;
        }
        public Product(int shelfTime, int Count, int id)
        {
            _count = Count;
            _shelfLife = shelfTime;
            _id = id;
            _id = random.Next(10);
            countElements++;
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public long UPC
        {
            get { return _UPC; }
            set { _UPC = value; }
        }
        public string Manfc
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        public int shLife
        {
            get { return _shelfLife; }
            set { _shelfLife = value; }
        }
        public int Count
        {
            set { _count = value; }
        }
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        // Methods
        public void outInfo()
        {
            Console.WriteLine($"Имя - {_name}, ID - {_id}, Производитель - {_manufacturer}," +
                $" Количество экземплятор - {countElements}, Количество - {_count}, Срок годности - {_shelfLife}, UPC - {_UPC}, Цена - {_cost}");
        }

        public static void outInfoOfElm()
        {
            Console.WriteLine($"Этот класс состоит из {countElements} элементов ");
        }
        public int countMan(int count, ref int a)
        {
            a += count;
            return a;
        }
        public void uniCode(int _id, int _UPC, out int b)
        {
            Console.WriteLine(b = _id + _UPC);

        }
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Product Milk = (Product)obj;
            return this.Name == Milk.Name;
        }
        public int sumCost(ref int _count, ref int _cost)
        {
            int sum = _count * _cost;
            return sum;
        }
        public static void  outInfoOfarr (Product[] arrayOfObject)
        {
            Console.WriteLine("Введите наименование: ");
            string tmp = Console.ReadLine();
            Console.WriteLine("Без условий | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - |");
            for(int i = 0; i < 7; i++)
            {
                if(tmp == arrayOfObject[i]._name)
                {
                    Console.WriteLine("ID - " + arrayOfObject[i]._id + " | " + "Количество - " + arrayOfObject[i]._count 
                        + " | " + "Наименование - " + arrayOfObject[i]._manufacturer + " | " + "Срок годности - " + arrayOfObject[i]._shelfLife 
                        + " | " + "UPC - " + arrayOfObject[i]._UPC + " | " + "Цена - " + arrayOfObject[i]._cost);
                }
            }    
        }
        public static void InfoWithCondition (Product[] arrayOfObject)
        {
            Console.WriteLine("Введите наименование: ");
            string tmp = Console.ReadLine();
            Console.WriteLine("Введите цену: ");
            int costCon = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("С условием | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - | - |");
            for (int i = 0; i < 7; i++)
            {
                if (tmp == arrayOfObject[i]._name && arrayOfObject[i]._cost * arrayOfObject[i]._count <= costCon)
                {
                    Console.WriteLine("ID - " + arrayOfObject[i]._id + " | " + "Количество - " + arrayOfObject[i]._count
                        + " | " + "Наименование - " + arrayOfObject[i]._manufacturer + " | " + "Срок годности - " + arrayOfObject[i]._shelfLife
                        + " | " + "UPC - " + arrayOfObject[i]._UPC + " | " + "Цена - " + arrayOfObject[i]._cost);
                }
            }
        }
        public class Buyer
        {
            string lastName;
            string firstName;
            int age;

            public string first
            {
                get { return firstName; }
                set { firstName = value; }
            }
            public string last
            {
                set { lastName = value; }
            }
            public int Age
            {
                set
                {
                    if (value < 21)
                    {
                        Console.WriteLine("Возраст должен быть больше 21");
                    }
                    else
                    {
                        age = value;
                    }
                }
                get { return age; }
            }
            Buyer()
            {
                lastName = String.Empty;
                firstName = String.Empty;
            }
            public Buyer(string _firstName = "Ivan", string _lastName = "Ivanov") : this()
            {
                first = _firstName;
                last = _lastName;
            }
        }
    }
}
