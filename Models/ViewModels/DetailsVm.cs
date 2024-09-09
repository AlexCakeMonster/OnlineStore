using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models.ViewModels
{
    public class DetailsVm
    {
        public DetailsVm()
        {
            Product = new Product();
        }
        public Product Product { get; set; }

        public bool ExistsInCart { get; set; }
    }
}
