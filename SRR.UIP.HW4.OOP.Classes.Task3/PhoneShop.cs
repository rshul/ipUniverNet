using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task3
{
    class PhoneShop
    {
        public string  ShopName { get; private set; }
        public ShopStore[] OwnStores { get; private set; }
        public int NumberOfStores { get; private set; } = 5;
        public bool IsAnyStore
        {
            get
            {
                bool isAnyStore = false;
                foreach (var store in this.OwnStores)
                {
                    if (store != null)
                    {
                        isAnyStore = true;
                        break;
                    }
                }
                return isAnyStore;
            }
        }
        public int NumberOfBusyStores
        {
            get
            {
                int counter = 0;
                foreach (var store in this.OwnStores)
                {
                    if (store != null)
                    {
                        counter++;
                    }
                }
                return counter;
            }
        }

        public PhoneShop(string shopName)
        {
            this.ShopName = shopName;
            this.OwnStores = new ShopStore[this.NumberOfStores];
        }

        public void AddStore(ShopStore newShopStore)
        {
            for (int i = 0; i < this.OwnStores.Length; i++)
            {
                if (this.OwnStores[i] == null)
                {
                    this.OwnStores[i] = newShopStore;
                    break;
                }
            }
            
        }
        public void ShowAllStores(bool isPhonesIncluded = false)
        {
            for (int i = 0; i < this.OwnStores.Length; i++)
            {
                
                Console.WriteLine($"[{i}] store addres: {this.OwnStores[i]?.StoreAddress??"empty store"}");
                if (isPhonesIncluded && this.OwnStores[i] != null)
                {
                    this.OwnStores[i].ShowAllPlaces();
                }
            }
        }
        public void ShowOnlyAvailableStores()
        {
            for (int i = 0; i < this.OwnStores.Length; i++)
            {
                if (this.OwnStores[i] == null)
                {
                    break;
                }
                Console.WriteLine($"[{i}] store addres: {this.OwnStores[i]?.StoreAddress ?? "empty store"}");
            }
        }
        
    }
}
