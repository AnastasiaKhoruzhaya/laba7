using System;
using System.Collections.Generic;
using System.Text;

namespace _6lab
{
    partial class Organization : IOperationSet//класс partial в первом файле
    {
        string[] IOperationSet.Operations()
        {
            return new string[] { "wow, it's a true company class" };
        }
    }
    sealed class Time : IOperationSet//запечатаный класс
    {
        string[] IOperationSet.Operations()
        {
            return new string[] { "wow, it's a true time class" };
        }
        public Time()
        {
            Console.WriteLine(DateTime.Now);
        }
        public override string ToString()
        {
            return "Time";
        }
    }
}
