using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Shop
    {
        List<Weapon> Weapon { get; set; }
        List<Armor> Armor { get; set; }
        List<Potion> Potion { get; set; }
        public Shop()
        {
            this.Weapon = new List<Weapon>();
            this.Armor = new List<Armor>();
            this.Potion = new List<Potion>();

        }
    }
}
