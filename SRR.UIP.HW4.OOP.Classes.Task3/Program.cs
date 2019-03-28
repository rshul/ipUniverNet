using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Please write valid (not empty) name for shop";
            string nameOfShop = GetNotEmptyString(message);
            Console.WriteLine($"=> Greate the name of the shop is '{nameOfShop}'");
            PhoneShop ps = new PhoneShop(nameOfShop);
            ShowMainMenu(ps);
            

            Console.ReadLine();
        }

        private static void ShowMainMenu(PhoneShop currentPhoneShop)
        {
            while (true)
            {
                Console.WriteLine("------- NEW COMMAND ------");
                PrintMenu("quit", "add store to shop", "add phone to store",
                       "show all phones in stores", "clear console");
                switch (MakeChoice(4))
                {
                    case 0:
                        Console.WriteLine("Quiting!");
                        return;
                    case 1:
                        AddStoreToShop(currentPhoneShop);
                        break;
                    case 2:
                        AddPhoneToStore(currentPhoneShop);
                        break;
                    case 3:
                        Console.WriteLine($"=> Store in '{currentPhoneShop.ShopName}'");
                        currentPhoneShop.ShowAllStores(isPhonesIncluded: true);
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    default:
                        break;
                } 
            }

        }

        private static void AddPhoneToStore(PhoneShop currentPhoneShop)
        {
            if (!currentPhoneShop.IsAnyStore)
            {
                Console.WriteLine($"=> in {currentPhoneShop.ShopName} no real stores are available. Please add any real store before add a phone");
                return;
            }
            string messageForMobileStoreIndex = $"Please write index number of MobilePhoneStore from list below. MobilePhoneStores:";
            Console.WriteLine(messageForMobileStoreIndex);
            Console.WriteLine($"=> Store in '{currentPhoneShop.ShopName}'");
            currentPhoneShop.ShowOnlyAvailableStores();
            int indexOfStore = GetNumberFromInput("=> Invalid number\n" + messageForMobileStoreIndex);
            while (indexOfStore < 0 || indexOfStore > currentPhoneShop.NumberOfBusyStores - 1)
            {
                Console.WriteLine("=> Invalid number\n" + messageForMobileStoreIndex);
                indexOfStore = GetNumberFromInput("=> Invalid number\n" + messageForMobileStoreIndex);
            }
            string messageForPhoneModel = $"Please write phone model name (text with length > 10)";
            Console.WriteLine(messageForPhoneModel);
            string phoneModel = GetPhoneModel(10, messageForPhoneModel);
            string messageForPhonePrice = $"Pleas write price (number > 0 && number <= 100000) of phones which could be in store";
            Console.WriteLine(messageForPhonePrice);
            int phonePrice = GetPhonePrice(1, 100000, messageForPhonePrice);
            Smartphone createdSmartPhone = new Smartphone(phoneModel,phonePrice);
            if (!currentPhoneShop.OwnStores[indexOfStore].IsFull)
            {
                currentPhoneShop.OwnStores[indexOfStore].PlaceSmartphone(createdSmartPhone);
                Console.WriteLine($"->Phone with model name '{phoneModel}' and '{phonePrice}' successfully " +
                    $"added to store with address {currentPhoneShop.OwnStores[indexOfStore].StoreAddress} and " +
                    $"capacity {currentPhoneShop.OwnStores[indexOfStore].StoreCapacity}");
            }
            else
            {
                Console.WriteLine($"->Phone with model name '{phoneModel}' and '{phonePrice}' was not " +
                    $"added to store with address {currentPhoneShop.OwnStores[indexOfStore].StoreAddress} and " +
                    $"capacity {currentPhoneShop.OwnStores[indexOfStore].StoreCapacity}");
            }
        }

        private static int GetPhonePrice(int minValue, int maxValue, string message = "Wrong input. Try again")
        {
            int phonePrice;
            bool isInRange;
            do
            {
                phonePrice = GetNumberFromInput();
                isInRange = phonePrice >= minValue && phonePrice <= maxValue;
                if (!isInRange)
                {
                    Console.WriteLine(message);
                }
            } while (!isInRange);
            return phonePrice;
        }

        private static void AddStoreToShop(PhoneShop currentPhoneShop)
        {
            string messageForGettingStoreAddress = "Please write shop address (text with length > 10) of store";
            Console.WriteLine(messageForGettingStoreAddress);
            string shopAddress = GetShopAddress(10, messageForGettingStoreAddress);
            string messageForGettingStoreCapacity = "Please write capacity(number > 0 && number <= 10) of phones which could be in store";
            Console.WriteLine(messageForGettingStoreCapacity);
            int capacityOfStore = GetCapacityOfStore(1, 10, messageForGettingStoreCapacity);
            ShopStore createdStore = new ShopStore(shopAddress, capacityOfStore);
            currentPhoneShop.AddStore(createdStore);
            Console.WriteLine($"=> Store '{shopAddress}' and capacity '{capacityOfStore}' successfully created");
        }

        private static string GetShopAddress(int minStringLength, string message = "Wrong input. Try again")
        {
            string shopAddress;
            bool isLessThanMinLength;
            do
            {
                shopAddress = GetNotEmptyString();
                isLessThanMinLength = shopAddress.Length <= minStringLength;
                if (isLessThanMinLength)
                {
                    Console.WriteLine(message);
                }
            } while (isLessThanMinLength);
            return shopAddress;
        }
        private static string GetPhoneModel(int minStringLength, string message = "Wrong input. Try again")
        {
            string phoneModel;
            bool isLessThanMinLength;
            do
            {
                phoneModel = GetNotEmptyString();
                isLessThanMinLength = phoneModel.Length <= minStringLength;
                if (isLessThanMinLength)
                {
                    Console.WriteLine(message);
                }
            } while (isLessThanMinLength);
            return phoneModel;
        }
        private static int GetCapacityOfStore(int minValue, int maxValue, string message = "Wrong input. Try again")
        {
            int capacityOfStore;
            bool isInRange;
            do
            {
                capacityOfStore = GetNumberFromInput();
                isInRange = capacityOfStore >= minValue && capacityOfStore <= maxValue;
                if (!isInRange)
                {
                    Console.WriteLine(message);
                }
            } while (!isInRange);
            return capacityOfStore;
        }
        private static string GetNotEmptyString(string message = "Wrong input. Try again")
        {
            string inputString;
            bool isEmpty;
            Console.WriteLine(message);
            do
            {
                inputString = Console.ReadLine();
                isEmpty = String.IsNullOrEmpty(inputString) || String.IsNullOrWhiteSpace(inputString);
                if (isEmpty)
                {
                    Console.WriteLine(message);
                }

            } while (isEmpty);
            return inputString;
        }
        private static void PrintMenu(params string[] menuList)
        {
            Console.WriteLine("Please write index of command from list below. Commands:");
            for (int i = 0; i < menuList.Length; i++)
            {
                Console.WriteLine($"[{i}] = {menuList[i]}");
            }
        }
        private static int MakeChoice(int maxValue)
        {
            int madeChoice;
            do
            {
                madeChoice = GetNumberFromInput();
            } while (madeChoice < 0 || madeChoice > maxValue);
            return madeChoice;
        }
        private static int GetNumberFromInput(string message = "Wrong input. Try again")
        {
            string inputLine;
            int numberFromInput;
            bool isParsedNumber;
            do
            {
                inputLine = Console.ReadLine();
                isParsedNumber = Int32.TryParse(inputLine, out numberFromInput);
                if (!isParsedNumber)
                {
                    Console.WriteLine(message);
                }
            } while (!isParsedNumber);
            return numberFromInput;

        }
    }
}
