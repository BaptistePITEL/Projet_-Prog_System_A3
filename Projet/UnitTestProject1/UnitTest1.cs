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
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
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
            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
            resto = restaurantEngineer.getRestaurant();

            gc1 = FabriqueGroupeClient.create();

            resto.groupeClientArrive(gc1);


            resto.tickFor(11);


            Assert.AreNotEqual(null, gc1.table);
        }

        [TestMethod]
        public void TestAttribuerCarte()
        {
            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
            resto = restaurantEngineer.getRestaurant();

            gc1 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc1);

            resto.tickFor(12);

            Assert.AreEqual(EnumEtatTable.ONT_CARTE, gc1.table.enumEtatTable);
        }

        [TestMethod]
        public void TestPrendreCommande()
        {

            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
            resto = restaurantEngineer.getRestaurant();

            gc1 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc1);
            
            resto.tickFor(24);

            Assert.AreEqual(EnumEtatTable.COMMANDE_EMISE, gc1.table.enumEtatTable);
        }

        [TestMethod]
        public void TestClientChoixRecette()
        {

            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
            resto = restaurantEngineer.getRestaurant();

            gc1 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc1);

            resto.tickFor(14);


            Assert.AreNotEqual(gc1.clients[0].entree, null);
        }

        [TestMethod]
        public void TestCommandeprise()
        {

            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
            resto = restaurantEngineer.getRestaurant();

            gc1 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc1);
            

            resto.tickFor(24);


            Assert.AreNotEqual(resto.comptoir.commandeAPrepare.Count, 0);
        }


        [TestMethod]
        public void TestChefDeCuisineRecuCommande()
        {
            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
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
            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
            resto = restaurantEngineer.getRestaurant();

            gc1 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc1);

            gc2 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc2);


            resto.tickFor(500);

           
            Assert.AreEqual(12, resto.comptoir.entreesAServir.Count);
            
        }
        [TestMethod]
        public void TestServeur()
        {
            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> listChef = new List<string>();
            listChef.Add("Chef de Rang 1");
            listChef.Add("Chef de Rang 2");

            List<string> listServeur = new List<string>();
            listServeur.Add("Serveur 1");
            listServeur.Add("Serveur 2");
            listServeur.Add("Serveur 3");
            listServeur.Add("Serveur 4");



            restaurantEngineer.makeRestaurant(2, 6, 3, 5, listChef, "Maitre d'hotel", "Chef de cuisine", listServeur);
            resto = restaurantEngineer.getRestaurant();

            gc1 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc1);

            gc2 = FabriqueGroupeClient.create();
            resto.groupeClientArrive(gc2);

            resto.tickFor(700);



            Assert.AreEqual(0, resto.comptoir.entreesAServir.Count);

        }



    }
}
