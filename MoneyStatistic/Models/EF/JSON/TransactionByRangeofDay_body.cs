using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF.JSON
{
    public class TransactionByRangeofDay_body
    {
        public DateTime Startday { get; set; }
        public DateTime Endday { get; set; }

    }
}
