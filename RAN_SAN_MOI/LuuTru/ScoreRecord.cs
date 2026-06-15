using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public class ScoreRecord
    {
        public int ID { get; set; }
        public int NguoiChoiID { get; set; }
        public string TenNguoiChoi { get; set; }
        public int Diem { get; set; }
        public string DoKho { get; set; }
        public DateTime ThoiGian { get; set; }
        public int ThoiLuong { get; set; }
    }
}
