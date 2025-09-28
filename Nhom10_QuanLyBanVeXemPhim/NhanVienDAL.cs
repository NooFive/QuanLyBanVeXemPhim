using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim.DAL
{
    public class NhanVienDAL
    {

        public NhanVienDTO DangNhap(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(Utilities.connectionString))
            {
                conn.Open();
                string sql = "SELECT TenNV, LaAdmin FROM NhanVien WHERE TenDangNhap = @user AND MatKhau = @pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new NhanVienDTO
                    {
                        TenNV = reader["TenNV"].ToString(),
                        LaAdmin = Convert.ToBoolean(reader["LaAdmin"])
                    };
                }
            }
            return null;
        }
    }
}

