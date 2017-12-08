using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    class Tildeling
    {
     
        private static string connectionsString =
        "Server=EALSQL1.eal.local; Database = DB2017_C03; User Id = user_C03; PassWord=SesamLukOp_03;";

        public void spuGivRNDKnummerOgLås()
        {
            List<string> listeOverKNummre = new List<string>();
            Random rnd = new Random();
            using (SqlConnection kNumberDB = new SqlConnection(connectionsString))
            {
                try
                {

                    kNumberDB.Open();
                    SqlCommand tildeling = new SqlCommand("spuGivRNDKnummerOgLås", kNumberDB);
                    tildeling.CommandType = CommandType.StoredProcedure;

                    SqlDataReader givKnummerIkkeIBrug = tildeling.ExecuteReader();

                    if (givKnummerIkkeIBrug.HasRows)
                    {
                        while (givKnummerIkkeIBrug.Read())
                        {
                            listeOverKNummre = givKnummerIkkeIBrug["KNUMMER"].ToString();
                            listeOverKNummre kNummer_Email = GivKnummerEmail["KNUMMER_EMAIL"].ToString();
                            listeOverKNummre.OrderBy(x => rnd.Next()).Take(1);
                            Console.WriteLine(kNummer + " " + kNummer_i_Brug + " ");
                        }

                    }
                }
                catch (SqlException error)
                {
                    Console.WriteLine("Fejl: " + error.Message);
                }
            }
            public void GivKnummerSomIkkeErIBrug();
            {
                
}           }

        }
    }

    
}
