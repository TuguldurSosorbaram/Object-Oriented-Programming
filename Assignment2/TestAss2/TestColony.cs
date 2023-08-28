using System;
using ass2;
namespace TestAss2
{
    [TestClass]
    public class TestColony
    {
        [TestMethod]
        public void TestPerish()
        {
            Wolf Wolf = new("w", "Wolf", 0);
            Fox Fox = new("w", "Fox", 0);
            Owl Owl = new("w", "Owl", 0);
            Wolf.Perish(0);
            Assert.IsTrue(Wolf.GetPopulation()==0);
            Fox.Perish(0);
            Assert.IsTrue(Fox.GetPopulation() == 0);
            Owl.Perish(0);
            Assert.IsTrue(Owl.GetPopulation() == 0);
            try
            {
                Wolf.Perish(1);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Colony.TooManytoPerish);
            }
            try
            {
                Fox.Perish(1);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Colony.TooManytoPerish);
            }
            try
            {
                Owl.Perish(1);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Colony.TooManytoPerish);
            }
            Wolf.SetPopulation(100);
            Wolf.Perish(100);
            Assert.IsTrue(Wolf.GetPopulation() == 75);
            Fox.SetPopulation(100);
            Fox.Perish(100);
            Assert.IsTrue(Fox.GetPopulation() == 75);
            Owl.SetPopulation(100);
            Owl.Perish(100);
            Assert.IsTrue(Owl.GetPopulation() == 75);
        }
        [TestMethod]
        public void TestOffspring()
        {
            Wolf Wolf = new("w", "Wolf", 10);
            Fox Fox = new("w", "Fox", 10);
            Owl Owl = new("w", "Owl", 10);
            Wolf.OffSpringProduction(8);
            Fox.OffSpringProduction(8);
            Owl.OffSpringProduction(8);
            Assert.IsTrue(Wolf.GetPopulation() == 14);
            Assert.IsTrue(Fox.GetPopulation() == 16);
            Assert.IsTrue(Owl.GetPopulation() == 12);
        }
        [TestMethod]
        public void TestMultiply()
        {
            Lemming lemming = new("n","lemming",201);
            Hare hare = new("n", "lemming", 101);
            Gopher gopher = new("n", "lemming", 201);

            lemming.Multiply(2);
            hare.Multiply(2);
            gopher.Multiply(4); 

            Assert.IsTrue(lemming.GetPopulation()==30);
            Assert.IsTrue(hare.GetPopulation() == 20);
            Assert.IsTrue(gopher.GetPopulation() == 40);
            lemming.SetPopulation(100);
            hare.SetPopulation(50);
            gopher.SetPopulation(100);

            lemming.Multiply(2);
            hare.Multiply(2);
            gopher.Multiply(4);

            Assert.IsTrue(lemming.GetPopulation() == 200);
            Assert.IsTrue(hare.GetPopulation() == 75);
            Assert.IsTrue(gopher.GetPopulation() == 200);
        }
        [TestMethod]
        public void TestHunt()
        {
            Wolf Wolf = new("w", "Wolf", 10);
            Fox Fox = new("w", "Fox", 10);
            Owl Owl = new("w", "Owl", 10);
            Lemming lemming = new("n", "lemming", 100);

            Wolf.Hunt(lemming);
            Assert.IsTrue(lemming.GetPopulation() == 60);
            Assert.IsTrue(Wolf.GetPopulation() == 10);

            lemming.SetPopulation(100);
            Fox.Hunt(lemming);
            Assert.IsTrue(lemming.GetPopulation() == 60);
            Assert.IsTrue(Fox.GetPopulation() == 10);

            lemming.SetPopulation(100);
            Owl.Hunt(lemming);
            Assert.IsTrue(lemming.GetPopulation() == 60);
            Assert.IsTrue(Owl.GetPopulation() == 10);

            Wolf.SetPopulation(30);
            lemming.SetPopulation(100);
            Wolf.Hunt(lemming);
            Assert.IsTrue(lemming.GetPopulation() == 0);
            Assert.IsTrue(Wolf.GetPopulation() == 29);

            lemming.SetPopulation(100);
            Fox.SetPopulation(30);
            Fox.Hunt(lemming);
            Assert.IsTrue(lemming.GetPopulation() == 0);
            Assert.IsTrue(Fox.GetPopulation() == 29);

            lemming.SetPopulation(100);
            Owl.SetPopulation(30);
            Owl.Hunt(lemming);
            Assert.IsTrue(lemming.GetPopulation() == 0);
            Assert.IsTrue(Owl.GetPopulation() == 29);
        }
        [TestMethod]
        public void TestHunted()
        {
            Lemming lemming = new("n", "lemming", 100);
            Hare hare = new("n", "lemming", 100);
            Gopher gopher = new("n", "lemming", 100);
            Wolf Wolf = new("w", "Wolf", 10);

            lemming.getHunted(Wolf);
            Assert.IsTrue(lemming.GetPopulation() == 60);
            Assert.IsTrue(Wolf.GetPopulation() == 10);

            hare.getHunted(Wolf);
            Assert.IsTrue(hare.GetPopulation() == 80);
            Assert.IsTrue(Wolf.GetPopulation() == 10);

            gopher.getHunted(Wolf);
            Assert.IsTrue(gopher.GetPopulation() == 80);
            Assert.IsTrue(Wolf.GetPopulation() == 10);

            lemming.SetPopulation(100);
            hare.SetPopulation(100);
            gopher.SetPopulation(100);

            Wolf.SetPopulation(30);
            lemming.getHunted(Wolf);
            Assert.IsTrue(lemming.GetPopulation() == 0);
            Assert.IsTrue(Wolf.GetPopulation() == 29);

            Wolf.SetPopulation(60);
            hare.getHunted(Wolf);
            Assert.IsTrue(hare.GetPopulation() == 0);
            Assert.IsTrue(Wolf.GetPopulation() == 58);

            Wolf.SetPopulation(60);
            gopher.getHunted(Wolf);
            Assert.IsTrue(gopher.GetPopulation() == 0);
            Assert.IsTrue(Wolf.GetPopulation() == 58);
        }
    }
}