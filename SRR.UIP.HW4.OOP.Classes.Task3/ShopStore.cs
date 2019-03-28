namespace SRR.UIP.HW4.OOP.Classes.Task3
{
    public class ShopStore
    {
        public string StoreAddress { get; private set; }
        public int StoreCapacity { get; private set; }
        public Smartphone[] Smartphones { get; private set; }
        public bool IsFull
        {
            get
            {
                bool isFull = true;
                foreach (var smartphone in this.Smartphones)
                {
                    if (smartphone == null)
                    {
                        isFull = false;
                    }
                }
                return isFull;
            }
        }
        

        public ShopStore(string address, int capacity)
        {
            this.StoreAddress = address;
            this.StoreCapacity = capacity;
            this.Smartphones = new Smartphone[capacity];
        }

        public void PlaceSmartphone(Smartphone acceptedSmartphone)
        {
            if (!this.IsFull)
            {
                for (int i = 0; i < this.Smartphones.Length; i++)
                {
                    if (this.Smartphones[i] == null)
                    {
                        this.Smartphones[i] = acceptedSmartphone;
                        break;
                    }
                }
            }
        }
        public void ShowAllPlaces()
        {
            for (int i = 0; i < this.Smartphones.Length; i++)
            {
                System.Console.WriteLine($"\t[{i}] - {this.Smartphones[i]?.GetInfoString()?? "phone cell is empty"}");
            }
        }

    }
}