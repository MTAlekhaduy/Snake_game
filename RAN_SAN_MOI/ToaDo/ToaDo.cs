using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public  class ToaDo
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public ToaDo()
        {
            X = 0;
            Y = 0;
        }
        public ToaDo(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
