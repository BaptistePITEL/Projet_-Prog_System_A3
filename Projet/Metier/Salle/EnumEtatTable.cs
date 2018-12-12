using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    public enum EnumEtatTable
    {
        INITIALE,
        INSTALLE, 
        ONT_CARTE,
        PRET_A_COMMANDE,
        PRET_A_COMMANDE_ATTENTE,
        COMMANDE_EMISE,
        EN_ATTENTE,
        ENTREE,
        PLAT,
        DESSERT,
        REPAS_FINI,
        PAYE
    }
}
