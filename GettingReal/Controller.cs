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
            tildeling.spuGivRNDKnummerOgLås();
        }
    }
        //methoder fra menu  
}
