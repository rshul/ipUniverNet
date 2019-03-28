namespace SRR.UIP.HW4.OOP.Classes.Task3
{
    public class Smartphone
    {
        public string PhoneModel { get; private set; }
        public int PhonePrice { get; private set; }

        public Smartphone(string model, int price)
        {
            this.PhoneModel = model;
            this.PhonePrice = price;
        }

        public string GetInfoString()
        {
            return $"model name {this.PhoneModel} and price {this.PhonePrice}";
        }
    }
}