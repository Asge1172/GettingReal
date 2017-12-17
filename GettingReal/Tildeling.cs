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

        public string spuGivRNDKnummerOgLås(int Medarbejder_ID)
        {
            string knummer = "";
            using (SqlConnection kNumberDB = new SqlConnection(connectionsString))
            {
                try
                {
                    kNumberDB.Open();
                    SqlCommand tildeling = new SqlCommand("spuGivFørsteKNummer", kNumberDB);
                    tildeling.CommandType = CommandType.StoredProcedure;

                    tildeling.Parameters.Add(new SqlParameter("@MEDARBEJDER_ID", Medarbejder_ID));

                    SqlDataReader givKnummerIkkeIBrug = tildeling.ExecuteReader();

                    string kNummer = givKnummerIkkeIBrug["KNUMMER"].ToString(); ;
                    Console.WriteLine("Dit K-nummer for i dag er: " + kNummer);

                    knummer = givKnummerIkkeIBrug["@KNUMMER"].ToString();
                }
                catch (SqlException error)
                {
                    Console.WriteLine("Fejl: " + error.Message);
                }
            }
            return knummer;
        }
    }
}
