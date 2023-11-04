using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Connection.Model
{
    public class UserTransaction
    {
        [Key]
        public string Id { get; set; }

        [StringLength(55)]
        public string Title { get; set; }

        [StringLength(55)]
        public string TransType { get; set; }

        [StringLength(55)]
        public string TransIcon { get; set; }

        public TimeSpan CreTime { get; set; }

        public DateTime CreDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public bool Status { get; set; }
    }
}
