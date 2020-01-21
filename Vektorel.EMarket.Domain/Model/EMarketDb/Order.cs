using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Order : BaseEntity
    {

        public Order()
        {
            PaymentCurrency = "TL";
            PaymentType = PaymentType.CreditCard;
            Status = OrderStatus.Waiting;
        }

        public string OrderNumber { get; set; }

        public decimal OrderTotal { get; set; }

        public OrderStatus Status { get; set; }

        public string PaymentCode { get; set; }

        //Kredi Kartı, Bitcoin, diğer online yöntemler
        public PaymentType PaymentType { get; set; }

        //Banka Adı, Ödeme arcısı
        public string Agent { get; set; }

        public string PaymentCurrency { get; set; }




        public Guid CustomerKey { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
