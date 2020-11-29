/*Дополнить предыдущую лабораторную работу № 6.
Создать иерархию классов исключений (собственных) – 3 типа и более.
Сделать наследование пользовательских типов исключений от стандартных
классов .Net (например, Exception, IndexOutofRange).
Сгенерировать и обработать как минимум пять различных исключительных
ситуаций на основе своих и стандартных исключений. Например, не позволять при
инициализации объектов передавать неверные данные, обрабатывать ошибки при
работе с памятью и ошибки работы с файлами, деление на ноль, неверный индекс,
нулевой указатель и т. д.
В конце поставить универсальный обработчик catch.
Обработку исключений вынести в main. При обработке выводить
специфическую информацию о месте, диагностику и причине исключения.
Последним должен быть блок, который отлавливает все исключения (finally).
Добавьте код в одной из функций макрос Assert. Объясните что он проверяет, как
будет выполняться программа в случае не выполнения условия. Объясните
назначение Assert. */
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace _7lab
{
    class Controller
    {
        public int FindsProduct(Bookkeeping bookkeeping, string name)
        {
            int sum = 0;
            for (int i = 0; i < bookkeeping.waybill.Count; i++)
            {
                for (int j = 0; j < bookkeeping.waybill[i].products.Count; j++)
                {
                    if (bookkeeping.waybill[i].products[j].name.Contains(name))
                    {
                        sum += bookkeeping.waybill[i].products[j].cost;
                    }
                }
            }
            return sum;
        }
        public int CheckNumber(Bookkeeping bookkeeping)
        {
            return bookkeeping.checks.Count;
        }
        public void FindDate(Bookkeeping bookkeeping)
        {
            for (int i = 0; i < bookkeeping.checks.Count; i++)
            {
                if (bookkeeping.checks[i].year > 2000 && bookkeeping.checks[i].year < 2005)
                {
                    Console.WriteLine("Number: " + bookkeeping.checks[i].number);
                }
            }
        }
    }
    
    class Bookkeeping
    {
        public List<Waybill> waybill;
        public List<Check> checks;

        public Bookkeeping()
        {
            waybill = new List<Waybill>();
            checks = new List<Check>();
        }
        public Waybill this[int index]
        {
            get
            {
                return waybill[index];
            }
            set
            {
                waybill[index] = value;
            }
        }
        public void Add(Waybill wb, Check ch)
        {
            waybill.Add(wb);
            checks.Add(ch);
        }
        public void Remove(int index)
        {
            waybill.Remove(waybill[index]);
            checks.Remove(checks[index]);
        }
        public void Output()
        {
            for (int i = 0; i < waybill.Count; i++)
            {
                Console.Write("\n" + (i + 1) + " Waybill products: ");
                for (int j = 0; j < waybill[i].products.Count; j++)
                {
                    Console.Write(waybill[i].products[j].name + " ");
                }
            }
        }
    }
    enum Days//перечисление
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    struct Person//структура
    {
        public string name;
        public int age;

        public void DisplayInfo()
        {
            Console.WriteLine( $"Name: {name} Age: {age}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = 10;
                int result = number / 0;
            }
            catch (DivideByZeroException) 
            { 
                Console.WriteLine("EXCEPTION! You can not divide by zero"); 
            }

            try
            {
                int[] numbers = new int[3];
                int index = numbers[10];
            }
            catch (IndexOutOfRangeException) 
            { 
                Console.WriteLine("EXCEPTION! Wrong index"); 
            }
            //receipt
            try
            {
                Receipt person = new Receipt();
                Console.Write("Enter youur age: ");
                person.Age = Convert.ToInt32(Console.ReadLine());
                Debug.Assert(person.Age <= 80);
            }
            catch (ReceiptExceptions ex)
            {
                Console.WriteLine("Exception: " + ex.message);
                Console.WriteLine("The place of exeption: " + ex.GetType().FullName);
                Console.WriteLine("Diagnostics, how to avoid: " + ex.message2);
            }
            Console.WriteLine();
            try
            {
                Check person = new Check(1999, 123);
                Console.Write("Enter youur age: ");
                person.Age = Convert.ToInt32(Console.ReadLine());
            }
            catch (CheckExceptions ex)
            {
                Console.WriteLine("Exception: " + ex.message);
                Console.WriteLine("The place of exeption: " + ex.GetType().FullName);
                Console.WriteLine("Diagnostics, how to avoid: " + ex.message2);
            }

            finally
            {
                Console.WriteLine("Block finally");
            }
            Console.WriteLine();



            //Days days;
            //days = Days.Monday;
            //for (int i = 0; i < 6; i++)
            //{
            //    Console.WriteLine(days);
            //    days++;
            //}
            //Person ann;
            //ann.name = "Ann";
            //ann.age = 19;
            //ann.DisplayInfo();

            //Product apple = new Product("apple", 30);
            //Product pen = new Product("pen", 10);
            //Product cat = new Product("cat", 1000);
            //Waybill waybill1 = new Waybill();
            //Waybill waybill2 = new Waybill();
            //Check check1 = new Check(1999, 123);
            //Check check2 = new Check(2003, 321);
            //Bookkeeping bookkeeping = new Bookkeeping();
            //bookkeeping.Add(waybill1, check1);
            //bookkeeping.Add(waybill2, check2);
            //waybill1.products.Add(apple); waybill1.products.Add(apple); waybill1.products.Add(pen);
            //waybill2.products.Add(pen); waybill2.products.Add(cat);
            //bookkeeping.Output();
            //Controller controller = new Controller();
            //Console.WriteLine("\nCost of a product: " + controller.FindsProduct(bookkeeping, "cat"));
            //Console.WriteLine("Quantity of checks: " + controller.CheckNumber(bookkeeping));
            //controller.FindDate(bookkeeping);
            //bookkeeping.Remove(1);
            //bookkeeping.Output();
        }
    }
}
