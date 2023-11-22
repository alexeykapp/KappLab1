using KappLab1.AppDataFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class WorkingDataBase
    {
        public TableLab4 GetByID(int id)
        {
            return ConnectDB.db.TableLab4.Where(x => x.ID == id).FirstOrDefault();
        }
        public List<TableLab4> GetByName(string name)
        {
            return ConnectDB.db.TableLab4.Where(x => x.name == name).ToList();
        }
        public bool Add(int id, string name, string message)
        {
            if (name != null && name.Length < 256 && message != null && message.Length < 8096)
            {
                return false;
            }
            var objTeble = new TableLab4
            {
                name = name,
                message = message
            };
            try
            {
                ConnectDB.db.TableLab4.Add(objTeble);
                ConnectDB.db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
        public bool Update(int id, string message)
        {
            var objTable = ConnectDB.db.TableLab4.Where(x => x.ID == id).FirstOrDefault();
            if (objTable == null) { return false; }
            try
            {
                objTable.message = message;
                ConnectDB.db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            return true;
        }
        public bool Delete(int id)
        {
            var objTable = ConnectDB.db.TableLab4.Where(x => x.ID == id).FirstOrDefault();
            if (objTable == null) { return false; }
            try
            {
                ConnectDB.db.TableLab4.Remove(objTable);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            return true;
        }
    }
}
