using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    class Menu
    {


        public void HovedMenu()
        {
            Console.WriteLine("Menu for GettingReal");
            Console.WriteLine("punkter man skal vælge mellem");
            Console.WriteLine("Tryk 1 for medarbejder \nTryk 2 for Admin");
            int Menu = Convert.ToInt32(Console.ReadLine());

            switch (Menu)
            {
                case 1:
                    MedarbejderMenu();
                    break;

                case 2:
                    AdminMenu();
                    break;


            }
        }
        private static void MedarbejderMenu()
        {
            Console.WriteLine("HEJ");

        }
        private static void AdminMenu()
        {
            Console.WriteLine("Hej du");

        }

    }
}
