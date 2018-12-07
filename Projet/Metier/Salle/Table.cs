using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    public class Table
    {
        public int nbPlaces;
        public GroupeClient grclient;
        public EnumEtatTable enumEtatTable;

        public Table(int nb )
        {
            this.nbPlaces = nb;
            enumEtatTable = EnumEtatTable.INSTALLE;
        }

        public void log()
        {
            Console.WriteLine(nbPlaces);
        }




    }
}
