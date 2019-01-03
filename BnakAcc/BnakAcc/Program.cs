using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcc
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.OwnerFullName = "Petya Petrov pPetrovich";
            account.AddMoney(1000);

            account.RegisterMesageServiceDelegate(new MessageServiceDelegate(Console.WriteLine));
            account.AddMoney(9999);
            account.WithdrawMoney(5550);

            Console.Read();
            
        }
    }
}