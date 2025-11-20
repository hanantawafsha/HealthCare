using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.DTO.Responses
{
    public class AddressResponseDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
