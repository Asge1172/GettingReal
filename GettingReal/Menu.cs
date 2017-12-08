using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    class Menu
    {
        Controller controller = new Controller();

        public void HovedMenu()
        {
            Console.WriteLine("Menu for GettingReal");
            Console.WriteLine("Punkter man skal vælge mellem");
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
        private void MedarbejderMenu()
        {
            Console.WriteLine("HEJ");

        }
        private void AdminMenu()
        {
            Console.WriteLine("Features");
            Console.WriteLine("Tryk 1 for Overblik over K nummer i brug");

            int adminMenu = Convert.ToInt32(Console.ReadLine());

            switch (adminMenu)
            {
                case 1:
                    controller.ShowKnumberList();
                        break;

                
            }

        }

    }
}
