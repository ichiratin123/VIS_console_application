using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DL;

namespace ConsoleGUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            TransactionScript transactionScript = new TransactionScript();
            transactionScript.Run();
        }
    }
}
