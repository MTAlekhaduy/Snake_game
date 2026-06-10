using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public abstract  class VatCan
    {
       public ToaDo Vitri { get; set; }
       public Color MauSac { get; set;  }
       protected VatCan(ToaDo vitri, Color mausac)
        {
            Vitri=vitri;
            MauSac=mausac;
        }
        public virtual void CapNhat(int oNgang,int oDoc) { }
        public virtual void Ve(Graphics g,int rong,int cao) 
        {
            using(var brush =new SolidBrush(MauSac))
            {
                g.FillRectangle(brush, Vitri.X * rong, Vitri.Y * cao,rong,cao);
            }
            using(var pen=new Pen(Color.DarkGray,1))
            {
                g.DrawRectangle(pen, Vitri.X * rong, Vitri.Y * cao, rong, cao);
            }
        }
    }

}
