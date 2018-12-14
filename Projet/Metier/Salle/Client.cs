using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Metier.Cuisine;
using Metier.Factory;

namespace Metier.Salle
{
    public class Client : Personnel
    {
        public GroupeClient groupeClient;
        public Recette entree;
        public Recette plat;
        public Recette dessert;

        public Recette platRecu;

        public int compteur = 0;
        public int compteurFiniMangeEntree = 0;
        public int compteurFiniMangePlat = 0;
        public int compteurFiniMangeDessert = 0;
        public int compteurPaye = 0;

        public bool paye = false;

        public FabriqueRecette fRe = new FabriqueRecette();
        public FabriqueRecette fRp = new FabriqueRecette();
        public FabriqueRecette fRd = new FabriqueRecette();

        public Client(GroupeClient groupeClient, string nom) : base(nom)
        {
            this.groupeClient = groupeClient;
        }

        public override Restaurant getRestaurant()
        {
            return groupeClient.table.rang.Carre.resto;
        }

        public override void tick()
        {
            if (groupeClient != null)
            {
                compteur += 1;
                if (groupeClient.table.enumEtatTable == EnumEtatTable.ONT_CARTE && compteur == 8)
                {
                    this.entree = fRe.create(1, groupeClient.table);
                    this.plat = fRp.create(2, groupeClient.table);
                    this.dessert = fRd.create(3, groupeClient.table);



                    groupeClient.checkToutLeMondePret();
                    //table.enumEtatTable = EnumEtatTable.PRET_A_COMMANDE;
                    if (this.Equals(groupeClient.clients.First()))
                    {
                        log("Table [" + groupeClient.table.numeroTable + "] prête à commander.");
                    }
                }
                else if (platRecu != null)
                {
                    if (groupeClient.table.enumEtatTable == EnumEtatTable.COMMANDE_EMISE)
                        groupeClient.checkToutLeMondeRecu();
                }


                if (groupeClient.table.enumEtatTable == EnumEtatTable.ENTREE)
                {
                    compteurFiniMangeEntree += 1;
                    if (compteurFiniMangeEntree == 15)
                    {
                        platRecu = null;
                        groupeClient.checkToutLeMondeFiniEntree();
                    }
                }


                if (groupeClient.table.enumEtatTable == EnumEtatTable.PLAT)
                {
                    compteurFiniMangePlat += 1;
                    if (compteurFiniMangePlat == 15)
                    {
                        platRecu = null;
                        groupeClient.checkToutLeMondeFiniPlat();
                    }
                }


                if (groupeClient.table.enumEtatTable == EnumEtatTable.DESSERT)
                {
                    compteurFiniMangeDessert += 1;
                    if (compteurFiniMangeDessert == 15)
                    {
                        platRecu = null;
                        groupeClient.checkToutLeMondeFiniDessert();
                    }
                }


                if (groupeClient.table.enumEtatTable == EnumEtatTable.REPAS_FINI)
                {
                    compteurPaye += 1;
                    if (compteurPaye == 5)
                    {
                        paye = true;
                        groupeClient.checkToutLeMondePaye();
                    }
                }

            }
        }
    }
}
