using System;
using System.Collections.Generic;


//Квитанция, Накладная, Документ, Чек, Дата, Организация.
namespace _6lab
{
    partial class Organization : IOperationSet//класс partial во втором файле
    {
        public override string ToString()
        {
            return "Organization";
        }
    }
    abstract class Document
    {
        ////переопределение методов Object

        public override string ToString()
        {
            return "Document";
        }

        public string documentNumber { get; set; }
        public override int GetHashCode()
        {
            return documentNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            else return true;
        }
    
    }
    class Receipt : Document, IOperationSet //квитанция
    {
        string[] IOperationSet.Operations()
        {
            return new string[] { "written acknowledgment that something of \n" +
                "value has been transferred from one party to another" };
        }
        public override string ToString()
        {
            return "Receipt";
        }
    }
    class Check : Document, IOperationSet
    {
        public int year;
        public int number;

        public Check(int y, int n)
        {
            year = y;
            number = n;
        }
        string[] IOperationSet.Operations()
        {
            return new string[] { "written, dated, and signed instrument that \n" +
                "directs a bank to pay a specific sum of money to the bearer." };
        }

        public override string ToString()
        {
            return "Check";
        }
    }
    class Product
    {
        public string name;
        public int cost;

        public Product(string n, int c)
        {
            name = n; cost = c;
        }
    }
    class Waybill : Document, IOperationSet //накладная
    {
        public List<Product> products = new List<Product>();
        string[] IOperationSet.Operations()
        {
            return new string[] { " document issued by a carrier giving details \n" +
                "and instructions relating to the shipment of a consignment of goods." };
        }
        public override string ToString()
        {
            return "Waybill";
        }
    }
}
