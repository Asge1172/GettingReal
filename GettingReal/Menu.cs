﻿using System;
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
            Console.WriteLine(" __________________________________________________ ");
            Console.WriteLine("|    Menu for GettingReal                          |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|    Vælg medarbejder:                             |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|    Tryk 1 for medarbejder                        |");
            Console.WriteLine("|    Tryk 2 for admin                              |");
            Console.WriteLine("|__________________________________________________|\n"); 
            Console.Write("Dit valg: ");
            int Menu = Convert.ToInt32(Console.ReadLine());

            switch (Menu)
            {
                case 1:
                    MedarbejderMenu();
                    break;

                case 2:
                    AdminLogin(0);
                    break;
            }
        }
        private void MedarbejderMenu()
        {
            Console.Clear();
            Console.WriteLine(" __________________________________________________ ");
            Console.WriteLine("|    Medarbejder menu                              |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|    Tryk 1 for at få tildelt et K-nummer          |");
            Console.WriteLine("|    Tryk 2 for at ønske et K-nummer               |");
            Console.WriteLine("|    Tryk 3 for at frigive dit K-nummer            |");
            Console.WriteLine("|__________________________________________________|\n");
            Console.Write("Dit valg: ");
            int medarbejderMenu = Convert.ToInt32(Console.ReadLine());

            switch (medarbejderMenu)
            {
                case 1:
                    controller.GetKNummer();
                    Console.WriteLine();
                    break;
                case 2:
                    getDesiredKNumber();
                    break;
                case 3:
                    releaseKNumber();
                    break;
                default:
                    break;
            }
        }

        private void releaseKNumber()
        {
            //string kNumberToBeReleased;

            Console.Clear();
            Console.WriteLine("Frigiv K-nummer");
            Console.WriteLine();
            Console.WriteLine("Indtast K-nummer:");
            Console.WriteLine();
            String kNumberToBeReleased = Console.ReadLine();

            kNumberToBeReleased = controller.releaseKNumberInDB(kNumberToBeReleased);

            Console.WriteLine(kNumberToBeReleased);
            Console.ReadKey();
        }

        public void AdminLogin(int loginCase)
        {
            Console.Clear();
            Console.WriteLine("Admin Login");
            Console.WriteLine();
            Console.WriteLine("Skriv dit brugernavn:");
            string userName = (Console.ReadLine());
            Console.WriteLine("Skriv dit password");
            string password = (Console.ReadLine());

            int askForCredentials = controller.CheckUserNameAndPassword(userName, password);

            if (askForCredentials == 0)
            {
                Console.WriteLine("Velkommen");

            }
            else if (askForCredentials == 1)
            {
                Console.WriteLine("Forkert brugernavn eller password");
                return;
            }

            //hvor leder login
            switch (loginCase)
            {
                case 0:     //admin  menu
                    {
                        AdminMenu();
                        break;
                    }

                case 1:     //password change
                    {
                        ChangePassword(userName);
                        break;
                    }
            }
        }

        private void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Features");
            Console.WriteLine("Tryk 1 for overblik over K nummer i brug");
            Console.WriteLine("Tryk 2 for at slette medarbejder");
            Console.WriteLine("Tryk 3 for shuffle medarbejdere");
            Console.WriteLine("Tryk 4 for at skifte kode");
            Console.WriteLine("Tryk 5 for for Overblik over pladser i brug");

            int adminMenu = Convert.ToInt32(Console.ReadLine());

            switch (adminMenu)
            {
                case 1:
                    List<string> list = controller.ShowKnumberList();
                    PrintKnumberList(list);
                    break;
                case 4:
                    AdminLogin(1);
                    break;
                case 5:
                    controller.ShowSeatingList();
                   break;
            }
        }

        private void ChangePassword(string userName)
        {
            //String newPassword;
           // int changeAdminPassword;

            Console.Clear();
            Console.WriteLine("Skift kode");
            Console.WriteLine("");
            Console.WriteLine("Indtast ny kode:");
            Console.WriteLine("");

            string newPassword = Convert.ToString(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Din kode vil blive ændret til: " + newPassword);
            Console.WriteLine("Bekræft?");
            Console.ReadKey();

            int changeAdminPassword = controller.ChangePasswordInDB(userName, newPassword);

            if (changeAdminPassword == 0)
            {
                Console.WriteLine("Password has been changed");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Password has not been changed, try again");
                Console.ReadKey();
                ChangePassword(userName);
            }
        }


        private void getDesiredKNumber()
        {
            int KnumberValidate;
            Console.Clear();
            Console.WriteLine("Ønskning af K-nummer");
            Console.WriteLine("Hvilket K-nummer ønsker du?");

            string ØnsketKnummer = Convert.ToString(Console.ReadLine()); // Convert to??

            Console.WriteLine("Hvad er dit Medarbejder ID?");

            int medarbejder_ID = Convert.ToInt32(Console.ReadLine());

            controller.ØnsketKNummer(ØnsketKnummer, medarbejder_ID); // Lav en return. Methoden laver for meget

            KnumberValidate = medarbejder_ID;

            if (KnumberValidate == 0)
            {
                Console.WriteLine("Dit K nummer er nu: " + ØnsketKnummer);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Desværre, dit K-nummer er optaget, vælg et nyt");
                Console.ReadKey();
                getDesiredKNumber();
            }
        }
        public void PrintKnumberList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);

            }

        }
    }
}

