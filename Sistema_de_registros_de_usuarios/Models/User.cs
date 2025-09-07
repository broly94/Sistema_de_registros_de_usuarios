using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_registros_de_usuarios.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string CodeUser { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
