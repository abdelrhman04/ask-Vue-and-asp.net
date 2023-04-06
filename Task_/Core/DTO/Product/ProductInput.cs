using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTO
{
    public class ProductInput
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public int Price { get; set; }
        public IFormFile file { get; set; }
        public string Image { get; set; } = String.Empty;
    }
}
