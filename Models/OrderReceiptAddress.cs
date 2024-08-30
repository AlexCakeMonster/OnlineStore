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

        [Required]
        public string City { get; set; }
        public string District { get; set; }
        [Required]
        public string Street { get; set; }
        
        [DisplayName("Number House")]       
        [Range(1, int.MaxValue, ErrorMessage = "Display Order for category must be greater than 0")]
        [Required]
        public int NumberHouse { get; set; }

        [MaxLength(12, ErrorMessage = "Phone must be 12 characters long")]
        public string Phone { get; set; }

    }
}
