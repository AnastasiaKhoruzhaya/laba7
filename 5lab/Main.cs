/*1) Определить иерархию и композицию классов (в соответствии с вариантом),
реализовать классы. Если необходимо расширьте по своему усмотрению
иерархию для выполнения всех пунктов л.р.
Каждый класс должен иметь отражающее смысл название и
информативный состав. При кодировании должны быть использованы
соглашения об оформлении кода code convention.
В одном из классов переопределите все методы, унаследованные от
Object.
2) В проекте должны быть интерфейсы и абстрактный класс(ы).
Использовать виртуальные методы и переопределение.
3) Сделайте один из классов герметизированным (бесплодным).
4) Добавьте в интерфейсы (интерфейс) и абстрактный класс одноименные
методы.
Дайте в наследуемом классе им разную реализацию и вызовите эти методы.
5) Написать демонстрационную программу, в которой создаются объекты
различных классов. Поработать с объектами через ссылки на абстрактные
классы и интерфейсы. В этом случае для идентификации типов объектов
использовать операторы is или as.
6) Во всех классах (иерархии) переопределить метод ToString(), который
выводит информацию о типе объекта и его текущих значениях.
7) Создайте дополнительный класс Printer c полиморфным методом
IAmPrinting( SomeAbstractClassorInterface someobj). Формальным
параметром метода должна быть ссылка на абстрактный класс или наиболее
общий интерфейс в вашей иерархии классов. В методе iIAmPrinting
определите тип объекта и вызовите ToString(). В демонстрационной
программе создайте массив, содержащий ссылки на разнотипные объекты
ваших классов по иерархии, а также объект класса Printer и последовательно
вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов.*/
using System;
using System.Collections.Generic;
using System.Text;

namespace _6lab
{/*Собрать Бухгалтерию.
Найти суммарную стоимость продукции заданного
наименования по всем накладным, количество чеков.
Вывести две накладные за указанный период времени*/
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
            Days days;
            days = Days.Monday;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(days);
                days++;
            }
            Person ann;
            ann.name = "Ann";
            ann.age = 19;
            ann.DisplayInfo();

            Product apple = new Product("apple", 30);
            Product pen = new Product("pen", 10);
            Product cat = new Product("cat", 1000);
            Waybill waybill1 = new Waybill();
            Waybill waybill2 = new Waybill();
            Check check1 = new Check(1999, 123);
            Check check2 = new Check(2003, 321);
            Bookkeeping bookkeeping = new Bookkeeping();
            bookkeeping.Add(waybill1, check1);
            bookkeeping.Add(waybill2, check2);
            waybill1.products.Add(apple); waybill1.products.Add(apple); waybill1.products.Add(pen);
            waybill2.products.Add(pen); waybill2.products.Add(cat);
            bookkeeping.Output();
            Controller controller = new Controller();
            Console.WriteLine("\nCost of a product: " + controller.FindsProduct(bookkeeping, "cat"));
            Console.WriteLine("Quantity of checks: " + controller.CheckNumber(bookkeeping));
            controller.FindDate(bookkeeping);
            bookkeeping.Remove(1);
            bookkeeping.Output();
        }
    }
}
