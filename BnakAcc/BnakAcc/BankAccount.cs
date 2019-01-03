using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcc
{
    //void возвращаемый тип методов на которые может указывать делегат
    //параметр string - параметр методов, на котором может указывать делегат
    public delegate void MessageServiceDelegate(string text);

    public class BankAccount
    {
        private MessageServiceDelegate messageServiceDelegate;
        public string OwnerFullName { get; set; }
        public int Sum { get; private set; }

        public void RegisterMesageServiceDelegate(MessageServiceDelegate service)
        {
            messageServiceDelegate += service;
        }
        public void UnegisterMesageServiceDelegate(MessageServiceDelegate service)
        {
            messageServiceDelegate -= service;
        }

        public void AddMoney(int sum)
        {
            if (messageServiceDelegate != null)
            {
                Sum += sum;
                messageServiceDelegate.Invoke($"Вы положили на счет {sum}. На вашем счету {Sum}.");
            }
        }

        public void WithdrawMoney(int sum)
        {
            if (sum < Sum)
            {
                if (messageServiceDelegate != null)
                {
                    Sum -= sum;
                    messageServiceDelegate.Invoke($"Вы сняли {sum}. На вашем счету {Sum}.");
                }
            }
            else
            {
                if (messageServiceDelegate != null)
                    messageServiceDelegate.Invoke($"Вы не можете снять {sum}. На вашем счету {Sum}.");
                return;
            }
        }
    }
}