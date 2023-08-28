using BagType;
namespace TestBagtype
{
    [TestClass]
    public class TestBag
    {
        [TestMethod]
        public void TestInsert()
        {
            Bag b = new Bag();
            
            Assert.IsTrue(b.countAll() == 0);
            //putting a element in a empty bag
            b.putin(1);
            Assert.IsTrue(b.countAll() == 1);
            //putting existing element
            b.putin(1);
            Assert.IsTrue(b.countAll() == 2);
            //putting non-existing element in a non-empty bag
            b.putin(-2);
        }
        [TestMethod]
        public void TestDelete()
        {
            Bag b = new Bag();
            //removing from empty bag
            try
            {
                b.takeout(2);
                Assert.Fail("no exception thrown");
            }catch(Exception ex)
            {
                Assert.IsTrue(ex is Bag.EmptyBagException);
            }
            //removing non-existing element from non-empty bag
            b.putin(5);
            try
            {
                b.takeout(2);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NotElementException);
            }
            //removing existing element from bag with only 1 element
            Assert.IsTrue(b.countAll() == 1);
            b.takeout(5);
            Assert.IsTrue(b.countAll() == 0);
            //removing existing element from bag with multiple elements
            b.putin(5);
            b.putin(5);
            b.putin(2);
            Assert.IsTrue(b.countAll() == 3);
            b.takeout(5);
            Assert.IsTrue(b.countAll() == 2);
        }
        [TestMethod]
        public void TestFrequent() 
        {
            Bag b = new Bag();
            //counting element from empty bag
            try
            {
                b.countE(2);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.EmptyBagException);
            }
            //counting non-existing element from non-empty bag
            b.putin(5);
            try
            {
                b.countE(2);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NotElementException);
            }
            //counting only element from bag with 1 element
            
            Assert.IsTrue(b.countE(5) == 1);

            //counting element from bag with multiple element
            b.putin(5);
            Assert.IsTrue(b.countE(5) == 2);
        }
        [TestMethod]
        public void TestNumberOfSingleElement() 
        { 
            Bag b = new Bag();
            //NoSE (Number of Single Elements)from empty bag
            try
            {
                b.getSingleECount();
            }catch(Exception ex)
            {
                Assert.IsTrue(ex is Bag.EmptyBagException);
            }
            //NoSE from non-empty bag but there is none
            b.putin(-5);
            b.putin(-5);
            b.putin(2);
            b.putin(2);
            Assert.IsTrue(b.getSingleECount()==0);
            //NoSE from non-empty bag but NoSE is only 1
            b.clear();
            b.putin(-5);
            b.putin(-5);
            b.putin(2);
            Assert.IsTrue(b.getSingleECount() == 1);
            //NoSE from non-empty bag but NoSE is multiple
            b.clear();
            b.putin(-5);
            b.putin(2);
            Assert.IsTrue(b.getSingleECount() == 2);
            //NoSE increasing after inserting 
            b.clear();
            b.putin(-5);
            Assert.IsTrue(b.getSingleECount() == 1);
            b.putin(2);
            Assert.IsTrue(b.getSingleECount() == 2);
            //NoSE decreasing after inserting 
            b.clear();
            b.putin(-5);
            b.putin(2);
            Assert.IsTrue(b.getSingleECount() == 2);
            b.putin(2);
            Assert.IsTrue(b.getSingleECount() == 1);
            //NoSE increasing after remove
            b.clear();
            b.putin(2);
            b.putin(2);
            Assert.IsTrue(b.getSingleECount() == 0);
            b.takeout(2);
            Assert.IsTrue(b.getSingleECount() == 1);
            //NoSE deccreasing after remove
            b.clear();
            b.putin(2);
            b.putin(1);
            Assert.IsTrue(b.getSingleECount() == 2);
            b.takeout(2);
            Assert.IsTrue(b.getSingleECount() == 1);
        }
    }
}