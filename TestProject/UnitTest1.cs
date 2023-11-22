using ClassLibrary;
using KappLab1.AppDataFile;

namespace TestProject
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.GetByName("Jon");
            var expect = ConnectDB.db.TableLab4.Where(x => x.name == "Jon");
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void Test2()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.GetByName("Alex");
            var expect = ConnectDB.db.TableLab4.Where(x => x.name == "Alex");
            Assert.AreEqual(expect, actual);
        }
        public void GetByID1()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.GetByID(1);
            var expect = ConnectDB.db.TableLab4.Where(x => x.ID == 1).FirstOrDefault();
            Assert.AreEqual(expect, actual);
        }
        public void GetByID2()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.GetByID(2);
            var expect = ConnectDB.db.TableLab4.Where(x => x.ID == 2).FirstOrDefault();
            Assert.AreEqual(expect, actual);
        }
        public void Add1()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.Add(3, "Maria", "Hello");
            var expect = true;
            Assert.AreEqual(expect, actual);
        }
        public void Add2()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.Add(4, null, "Hello");
            var expect = false;
            Assert.AreEqual(expect, actual);
        }
        public void Update1()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.Update(1, "Goodbye");
            var expect = true;
            Assert.AreEqual(expect, actual);
        }
        public void Update2()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.Update(1, null);
            var expect = false;
            Assert.AreEqual(expect, actual);
        }
        public void Delete1()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.Delete(1000);
            var expect = false;
            Assert.AreEqual(expect, actual);
        }
        public void Delete2()
        {
            WorkingDataBase dataBase = new WorkingDataBase();
            var actual = dataBase.Delete(1);
            var expect = true;
            Assert.AreEqual(expect, actual);
        }
    }
}