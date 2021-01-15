using System.Collections.Generic;

namespace Inventory.Models
{
    public class Flavor
    {
        public Flavor()
        {
            this.Treats = new HashSet<FlavorTreat>();
        }

        public int FlavorId { get; set; }
        public string FlavorDescription { get; set; }
        public virtual ICollection<FlavorTreat> Treats { get; set; }
    }
}