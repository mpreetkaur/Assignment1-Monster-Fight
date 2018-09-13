using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Potion :Item
    {
        public int HP { get; set; }
        public string Name { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Potion(int hp, string name, int originalValue, int resellValue) {
            this.HP = hp;
            this.Name = name;
            this.OriginalValue = originalValue;
            this.ResellValue = resellValue;
        }
    }
}
