using System.Collections.Generic;

namespace Inventory.Models
{
    public class Treat
    {
        public Treat()
        {
            this.Flavors = new HashSet<FlavorTreat>();
        }

        public int TreatId { get; set; }
        public string TreatName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<FlavorTreat> Flavors { get; }
    }
}