using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagType
{
    class Menu
    {
        private Bag bag;
        public Menu() { bag = new Bag(); }
        private static int GetMenuInput()
        {
            int n;
            Console.WriteLine("\n**************************************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add element");
            Console.WriteLine("2. Remove element");
            Console.WriteLine("3. Frequency of the element");
            Console.WriteLine("4. Number of elements that occur only once");
            Console.WriteLine("5. Print");
            Console.WriteLine("****************************************");

            while(true)
            {
                string str = Console.ReadLine();
                if(int.TryParse(str,out n)) return n;
                Console.WriteLine("Entered number is not an integer! Please enter integer");
            }
        }
        public void Run()
        {
            int n;
            do
            {
                n = GetMenuInput();
                switch (n)
                {
                    case 0:
                        Console.WriteLine("\nBye!");
                        break;
                    case 1:
                        PutIn();
                        break;
                    case 2:
                        TakeOut();
                        break;
                    case 3:
                        GetFreq();
                        break;
                    case 4:
                        GetSEC();
                        break;
                    case 5:
                        Write();
                        break;
                    default:
                        Console.WriteLine("\nInvalid option");
                        break;

                }
            } while (n != 0);

        }
        private void PutIn()
        {
            try
            {
                Console.WriteLine("Give integer to add:");
                int elem = int.Parse(Console.ReadLine());
                bag.putin(elem);
                Console.WriteLine("Element added {0}", elem);
            }catch (System.FormatException) { Console.WriteLine("Input has to be integer!"); }
        }
        private void TakeOut()
        {            
            try
            {
                Console.WriteLine("Give integer to remove:");
                int elem = int.Parse(Console.ReadLine());
                bag.takeout(elem);
                Console.WriteLine("Element removed {0}",elem);
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine("Bag is empty!");
            }
            catch (Bag.NotElementException) 
            {
                Console.WriteLine("Element does not exist in the bag!");
            }
            catch (System.FormatException) { Console.WriteLine("Input has to be integer!"); }
        }
        private void GetFreq()
        {
            try
            {
                Console.WriteLine("Give integer to count:");
                int elem = int.Parse(Console.ReadLine());

                int count = bag.countE(elem);
                Console.WriteLine($"Element is in the bag {count} times!");
            }
            catch(Bag.EmptyBagException)
            {
                Console.WriteLine("Bag is empty!");
            }
            catch (Bag.NotElementException)
            {
                Console.WriteLine("Element does not exist in the bag!");
            }
            catch (System.FormatException) { Console.WriteLine("Input has to be integer!"); }
        }
        private void GetSEC()
        {
            try
            {
                Console.WriteLine("Number of elements occuring only once: {0}",bag.getSingleECount());
            }
            catch(Bag.EmptyBagException) { Console.WriteLine("Bag is empty!"); }
        }
        private void Write() //print
        {
            bag.print();
        }
    }
}
