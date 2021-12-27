using QLBH_DAO;
using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_BUS
{
    public class QLBUS
    {
        QLDAO dao = new QLDAO();
        public List<QLDTO> ReadCustomer()
        {
            List<QLDTO> lstCus = dao.ReadCustomer();
            return lstCus;
        }
        public void AddCustomer(QLDTO cus)
        {
            dao.AddCustomer(cus);
        }
        public void DeleteCustomer(QLDTO cus)
        {
            dao.DeleteCustomer(cus);
        }
        public void EditCustomer(QLDTO cus)
        {
            dao.EditCustomer(cus);
        }
    }
}
