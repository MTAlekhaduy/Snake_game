using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace RAN_SAN_MOI
{
    public class VatCanDiChuyen : VatCan
    {
        private int _huong = 1;
        private bool _diTheoChieuDoc;
        public VatCanDiChuyen(ToaDo vitri, bool diTheoChieuDoc = true)  : base(vitri, Color.DarkRed)
        {
            _diTheoChieuDoc= diTheoChieuDoc;
        }
        public override void CapNhat(int oNgang, int oDoc)
        {
            if (_diTheoChieuDoc)
            {
                Vitri.Y += _huong;
                // Nếu vượt quá giới hạn hàng trên hoặc hàng dưới, đổi hướng di chuyển
                if (Vitri.Y <= 2 || Vitri.Y >= oDoc - 3)
                {
                    _huong = -_huong;
                }
            }
            else
            {
                Vitri.X += _huong;
                // Nếu vượt quá giới hạn cột trái hoặc cột phải, đổi hướng di chuyển
                if (Vitri.X <= 2 || Vitri.X >= oNgang - 3)
                {
                    _huong = -_huong;
                }
            }
        }
    }
}
