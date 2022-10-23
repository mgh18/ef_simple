using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity_Example.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string CarName { get; set; }
        public string CarPlak { get; set; }
    }
}