using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GettingReal
{
    class Tildeling
    {

        private static string connectionsString =
        "Server=EALSQL1.eal.local; Database = DB2017_C03; User Id = user_C03; PassWord=SesamLukOp_03;";

        public void spuGivRNDKnummerOgLås()
        {
            using (SqlConnection kNumberDB = new SqlConnection(connectionsString))
            {
                try
                {
                    kNumberDB.Open();
                    SqlCommand tildeling = new SqlCommand("spuGivFørsteKNummer", kNumberDB);
                    tildeling.CommandType = CommandType.StoredProcedure;

                    SqlDataReader givKnummerIkkeIBrug = tildeling.ExecuteReader();

                    if (givKnummerIkkeIBrug.HasRows)
                    {
                        while (givKnummerIkkeIBrug.Read())
                        {
                            string kNummer = givKnummerIkkeIBrug["KNUMMER"].ToString(); ;
                            string kNummerEmail = givKnummerIkkeIBrug["KNUMMER_EMAIL"].ToString();
                            Console.WriteLine("Dit K-nummer for i dag er: " + kNummer);
                            Console.WriteLine("Din Email for i dag er:    " + kNummerEmail);
                        }
                    }
                }
                catch (SqlException error)
                {
                    Console.WriteLine("Fejl: " + error.Message);
                }
            }
        }
    }
}
