using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class OrderReceiptAddress
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        [DisplayName("Number House")]
        public int NumberHouse { get; set; }
        public string Phone { get; set; }

    }
}
