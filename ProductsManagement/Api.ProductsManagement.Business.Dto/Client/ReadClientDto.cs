using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ProductsManagement.Business.Dto.Client
{
    public class ReadClientDto : CreateClientDto
    {
        public int Id { get; set; }

        // public string Address { get; set; }
    }
}
