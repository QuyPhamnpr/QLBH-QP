using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLBH_DTO;
using System.Data;

namespace QLBH_DAO
{
    public class QLDAO : DBConnection
    {
        public object CongNo { get; private set; }

        public List<QLDTO> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from CongNo", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<QLDTO> lstCus = new List<QLDTO>();
            while (reader.Read())
            {
                QLDTO cus = new QLDTO();
                cus.Makhachhang = reader["makhachhang"].ToString();
                cus.Tenkhachhang = reader["tenkhachhang"].ToString();
                cus.Sodienthoai = reader["sodienthoai"].ToString();
                cus.Sotienno = reader["sotienno"].ToString();
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public void DeleteCustomer(QLDTO cus)
        {
            //SqlConnection conn = CreateConnection();
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("delete from CongNo where Makhachhang =@makhachhang", conn);
            //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Makhachhang));

            //cmd.ExecuteNonQuery();
            //conn.Close();
            //sử dụng lớp SqlConnection để tạo chuỗi kết nối
            SqlConnection con = new SqlConnection();

            //Chỗ này tạm thời có thể gán chuỗi kết nối
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "DeleteNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Makhachhang));
                //mở chuỗi kết nối
                con.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                con.Close();

                Console.WriteLine("Xoa hoc sinh thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                con.Close();
            }


        }
        public void AddCustomer(QLDTO cus)
        {
            //SqlConnection conn = CreateConnection();
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("insert into CongNo values(@makhachhang,@tenkhachhang,@sodienthoai,@sotienno)", conn);
            //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Makhachhang));
            //cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.Tenkhachhang));
            //cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.Sodienthoai));
            //cmd.Parameters.Add(new SqlParameter("@sotienno", cus.Sotienno));


            //cmd.ExecuteNonQuery();
            //conn.Close();
            SqlConnection conn = CreateConnection();
            conn.Open();


            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "AddNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Makhachhang));
                cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.Tenkhachhang));
                cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.Sodienthoai));
                cmd.Parameters.Add(new SqlParameter("@sotienno", cus.Sotienno));
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Them hoc sinh thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        public void EditCustomer(QLDTO cus)
        {
            //SqlConnection conn = CreateConnection();
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("update CongNo set Tenkhachhang =@tenkhachhang, Sodienthoai=@sodienthoai, Sotienno=@sotienno where Makhachhang=@makhachhang", conn);
            //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Makhachhang));
            //cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.Tenkhachhang));
            //cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.Sodienthoai));
            //cmd.Parameters.Add(new SqlParameter("@sotienno", cus.Sotienno));

            //cmd.ExecuteNonQuery();
            //conn.Close();
            //sử dụng lớp SqlConnection để tạo chuỗi kết nối
            SqlConnection con = new SqlConnection();


            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "UpdateNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Makhachhang));
                cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.Tenkhachhang));
                cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.Sodienthoai));
                cmd.Parameters.Add(new SqlParameter("@sotienno", cus.Sotienno));
                //mở chuỗi kết nối
                con.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                con.Close();

                Console.WriteLine("Sua hoc sinh thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                con.Close();
            }
        }
    }
}
