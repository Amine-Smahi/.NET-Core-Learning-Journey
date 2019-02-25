using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeklaAPI.MeklaCRUD {
    public class MeklaUpdate {
        public string Name { get; set; }
        public int Calories { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
    }
}