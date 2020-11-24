using System;
using System.Collections.Generic;
using System.Text;

namespace _6lab
{
    interface IOperationSet
    {
        string[] Operations();
    }

    class Printer
    {
        public string IAmPrinting(IOperationSet set)
        {
            if (set is Document)
            {
                return string.Format("{0} is a document. In another words it is a {1}.",
                    set.ToString(),
                    string.Join(", ", set.Operations())) + "\n";

            }
            else
            {
                return "This class is not from your hierarchy\n";
            }
        }
    }
}
