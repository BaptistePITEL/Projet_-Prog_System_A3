using Metier;
using Metier.Salle;
using Metier.Builder;
using Metier.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Restaurant resto;
        private GroupeClient gc1;
        private GroupeClient gc2;
        /*  private Client clt1;
          private Client clt2;
          */


        [TestInitialize]
        public void TestInitialize()
        {

            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> list = new List<string>();
            list.Add("Didier");
            list.Add("Gilbert");
            restaurantEngineer.makeRestaurant(2, 6, 3, 5, list, "Gontrand", "Gilbert");
            resto = restaurantEngineer.getRestaurant();

            /* gc1 = new GroupeClient();
             gc2 = new GroupeClient();

             FabriqueClient fabriqueClient = new FabriqueClient();

             clt1 = fabriqueClient.create(gc1);
             clt2 = fabriqueClient.create(gc1);

             gc1.clients.Add(clt1);
             gc1.clients.Add(clt2);

             for(int i = 0; i < 6; i++)
             {
                 gc2.clients.Add(fabriqueClient.create(gc2));

             }*/
             

            gc1 = FabriqueGroupeClient.create();
            gc2 = FabriqueGroupeClient.create();
        }

        [TestMethod]
        public void TestAccueilClient()
        {
            resto.groupeClientArrive(gc1);


            resto.tickFor(11);


            Assert.AreNotEqual(null, gc1.table);
        }

        [TestMethod]
        public void TestAttribuerCarte()
        {
            resto.groupeClientArrive(gc1);

            resto.tickFor(12);

            Assert.AreEqual(EnumEtatTable.ONT_CARTE, gc1.table.enumEtatTable);
        }

        [TestMethod]
        public void TestPrendreCommande()
        {
            resto.groupeClientArrive(gc1);



            resto.tickFor(24);

            Assert.AreEqual(EnumEtatTable.COMMANDE_EMISE, gc1.table.enumEtatTable);
        }

        [TestMethod]
        public void TestClientChoixRecette()
        {
            resto.groupeClientArrive(gc1);

            resto.tickFor(14);


            Assert.AreNotEqual(gc1.clients[0].entree, null);
        }

        [TestMethod]
        public void TestCommandeprise()
        {
            resto.groupeClientArrive(gc1);

            resto.tickFor(24);


            Assert.AreNotEqual(resto.commandesEnAttente.Count, 0);
        }


        [TestMethod]
        public void TestChefDeCuisineRecuCommande()
        {
            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> list = new List<string>();
            list.Add("Didier");
            list.Add("Manu");
            restaurantEngineer.makeRestaurant(2, 6, 3, 5, list, "Gontrand", "Gilbert");
            resto = restaurantEngineer.getRestaurant();
            
            gc1 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc1);

            resto.tickFor(27);
            int nbRecetteEnCours = 0;
            foreach (var chefPartie in resto.chefDeCuisine.chefParties)
            {
                nbRecetteEnCours += chefPartie.recettes.Count;
            }
            Assert.AreEqual(6, nbRecetteEnCours);
        }

        [TestMethod]
        public void TestChefDePartieRecettePrete()
        {
            resto.groupeClientArrive(gc1);

            resto.tickFor(29);


            Assert.AreNotEqual(resto.chefDeCuisine.chefParties[0].recettes[0], false);
        }


    }
}
