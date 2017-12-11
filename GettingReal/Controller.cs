using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    class Controller
    {
        Tildeling tildeling = new Tildeling();
        Overblik overblik = new Overblik();

        public void ShowKnumberList()
        {
            overblik.SpShowKnubmerList();
        }

        public void GetKNummer()
        {
            int Medarbejder_ID = GetMedarbejderID();
            string tildeltknummer = tildeling.spuGivRNDKnummerOgLås(Medarbejder_ID);
            if (tildeltknummer != string.Empty)
            {
                Console.WriteLine("dit knummer er nu " + tildeltknummer + "!"); 

            }
            else
            {
                Console.WriteLine("sorry, prøv igen, noget gik galt.");
            }
        }

        public int GetMedarbejderID()
        {
            int MedarbejderÌD = Convert.ToInt32(Console.ReadLine());
            return MedarbejderÌD;
        }
    }       //methoder fra menu  
}
