using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDataAccess
{
    public class Operation
    {
        INVENTORYEntities entity = null;

        public bool AddNewProduct(PRODUCT prod)
        {
            entity = new INVENTORYEntities();
            entity.PRODUCTs.Add(prod);
            entity.SaveChanges();
            return true;
        }


        public List<PRODUCT> GetAllProduct()
        {
            entity = new INVENTORYEntities();
            var lstPrd = entity.PRODUCTs.ToList();
            return lstPrd;


        }

        public PRODUCT GetProdById(string pID)
        {
            entity = new INVENTORYEntities();
            PRODUCT prod = entity.PRODUCTs.Find(int.Parse(pID));
            return prod;
        }

        public bool DeleteProductByID(string pID)
        {
            entity = new INVENTORYEntities();
            PRODUCT prod = entity.PRODUCTs.Find(int.Parse(pID));
            entity.PRODUCTs.Remove(prod);
            entity.SaveChanges();
            return true;
        }

    }
}
