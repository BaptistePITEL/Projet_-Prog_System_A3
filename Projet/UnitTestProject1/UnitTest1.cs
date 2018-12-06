using Metier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Restaurant resto;
        private GroupeClient gc;
        private Rang rg;
        private Carre carre;
        private MaitreHotel mH;
        private ChefDeRang chefR;
        private Table table;
        private Client clt1;
        private Client clt2;

        [TestInitialize]
        public void TestInitialize()
        {
            resto = new Restaurant();
            gc = new GroupeClient();
            rg = new Rang();
            carre = new Carre();
            mH = new MaitreHotel("Charles");
        }
        
        
        
       

        [TestMethod]
        public void TestAccueilClient()
        {
            table = new Table(2);
            chefR = new ChefDeRang(carre, "Didier");
            clt1 = new Client(gc, "Jacques");
            clt2 = new Client(gc, "Denis");

            rg.tables.Add(table);

            carre.rangs.Add(rg);
            carre.chefDeRang = chefR;

            resto.carres.Add(carre);
            resto.maitreHotel = mH;

            mH.resto = resto;

            gc.clients.Add(clt1);
            gc.clients.Add(clt2);

            resto.groupeClientArrive(gc);
            resto.tick();
      
            Assert.AreNotEqual(null, gc.table);
        }
    }
}
