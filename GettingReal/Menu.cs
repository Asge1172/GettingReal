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
            Console.WriteLine("Tryk 1 for medarbejder");
            Console.WriteLine("Tryk 2 for admin");
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
            Console.WriteLine("Tryk 1 for at få tildelt et K-nummer");
            int medarbejderMenu = Convert.ToInt32(Console.ReadLine());

            switch (medarbejderMenu)
            {
                case 1:
                    controller.GetKNummer();
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

        private void AdminLogin()
        {
            Console.Clear();
            Console.WriteLine("Admin Login");
            Console.WriteLine();
            Console.WriteLine("Skriv venligst dit brugernavn:");
            string adminLogin = (Console.ReadLine());

        }   

        private void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Features");
            Console.WriteLine("Tryk 1 for overblik over K nummer i brug");
            Console.WriteLine("Tryk 2 for at slette medarbejder");
            Console.WriteLine("Tryk 3 for shuffle medarbejdere");

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
