using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom10_QuanLyBanVeXemPhim
{
    public class Utilities
    {
        public static string connectionString =
           ConfigurationManager.ConnectionStrings["NgaNguyen"].ConnectionString;
    }
}
