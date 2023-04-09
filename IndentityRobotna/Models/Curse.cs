using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndentityRobotna.Models
{
    public class Curse
    {
    
        public int CurseId { get; set; }
        public string CurseName { get; set; }
        public DateTime Period { get; set; }
        public decimal Cost { get; set; }
        public string Img { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
