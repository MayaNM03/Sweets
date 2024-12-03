using System;

namespace SweetShop
{
    public class Order 
    {
        public string ID_Order { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string ID_Assort { get; set; }
        public bool Addons { get; set; }
        public double PricePerSweet { get; set; }
        public int AmountOfSweets { get; set; }
    }
}
