using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_registros_de_usuarios.Models
{
    internal class Schedule
    {
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int UserId { get; set; }
    }
}
