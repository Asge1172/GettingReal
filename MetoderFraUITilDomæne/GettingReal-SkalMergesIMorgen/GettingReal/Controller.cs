using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DTO_PladsOverblik;


namespace GettingReal
{
    class Controller
    {
        Tildeling tildeling = new Tildeling();
        Overblik overblik = new Overblik();
        Admin admin = new Admin();
        //Validate validate = new Validate();

        public void ShowKnumberList()
        {
            overblik.SpShowKnubmerList();
        }

        public void GetKNummer()
        {
            int Medarbejder_ID = GetMedarbejderID();
            string tildeltknummer = tildeling.SpuGivRNDKnummerOgLås(Medarbejder_ID);
            if (tildeltknummer != string.Empty)
            {
                Console.WriteLine("dit knummer er nu " + tildeltknummer + "!");

            }
            else
            {
                Console.WriteLine("sorry, prøv igen, noget gik galt.");
            }
        }

        public string ReleaseKNumberInDB(string kNumberToBeReleased)
        {
            return tildeling.ReleaseKNumberInDB(kNumberToBeReleased);
        }

        public bool CheckUserNameAndPassword(string userName, string password)
        {
            return admin.CheckUserNameAndPassword(userName, password);
        }

        public int GetMedarbejderID()
        {
            Console.WriteLine("Indtast dit Medarbejder ID");
            int MedarbejderÌD = Convert.ToInt32(Console.ReadLine());
            return MedarbejderÌD;
        }

        public bool ChangePasswordInDB(string userName, string newPassword)
        {
            return admin.ChangePasswordInDB(userName, newPassword);
        }

        public string HasPasswordBeenUpdated(bool changeAdminPassword)
        {
            return admin.HasPasswordBeenUpdated(changeAdminPassword);
        }

        //public int IsUserInputInt(string inputString)
        //{
        //    return validate.IsUserInputInt(inputString);
        //}

            public int ØnsketKNummer(string ønsketKnummer, int medarbejder_ID)
        {
            return tildeling.SpuØnskKNummer(ønsketKnummer, medarbejder_ID);
        }

        //public List<DTOPladsOverblik> ShowSeatingList() //Frederik
        //{
        //    return overblik.SpuSeatingList();
        //}
    }       //methoder fra menu  
}
