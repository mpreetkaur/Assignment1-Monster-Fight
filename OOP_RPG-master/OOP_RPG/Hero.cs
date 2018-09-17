using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        public int Gold { get; set; }
        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero() {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionBag = new List<Potion>();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 0;
            this.Speed = 30;

        }
        
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Speed { get; set; }
        
        public List<Armor> ArmorsBag { get; set;}
        public List <Weapon> WeaponsBag { get; set; }
        public List <Potion> PotionBag { get; set; }
        
        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("gold: " + this.Gold);
            Console.WriteLine("Speed: " + this.Speed);

        }

        public void ShowInventory() {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach(var w in this.WeaponsBag){
                Console.WriteLine(w.Name + " of " + w.Strength + " Strength");
            }
            Console.WriteLine("Armor: ");
            foreach(var a in this.ArmorsBag){
                Console.WriteLine(a.Name + " of " + a.Defense + " Defense");
            }
            Console.WriteLine("Potion: ");
            foreach (var p in this.PotionBag)
            {
                Console.WriteLine(p.Name + " of " + p.HP + " Hp");
            }
        }
        
        public void EquipWeapon(int selectedIndex) {
            if(WeaponsBag.Any()) {
                this.EquippedWeapon = this.WeaponsBag[selectedIndex];
            }
        }
        
        public void EquipArmor(int selectedIndex) {
            if(ArmorsBag.Any()) {
                this.EquippedArmor = this.ArmorsBag[selectedIndex];
            }
        }
        public void Equip()
        {
            Console.WriteLine("*****Choose the equipment here******");
            Console.WriteLine("1. Weapon");
            Console.WriteLine("2. Armor");
            Console.WriteLine("3. Gain Hp");
            var choosenEquip = Console.ReadLine();

            if(choosenEquip == "1")
            {
                foreach(var w in this.WeaponsBag){
                    Console.WriteLine(this.WeaponsBag.IndexOf(w) + ". " + w.Name + " of strength " + w.Strength);
                }
                var toEquip = Console.ReadLine();
                if(toEquip == "0" || toEquip == "1" || toEquip == "2")
                {
                    if(this.EquippedWeapon == null)
                    {
                        this.EquipWeapon(Convert.ToInt32(toEquip));
                        this.Strength += this.EquippedWeapon.Strength;
                        this.WeaponsBag.RemoveAt(Convert.ToInt32(toEquip));
                    }
                    else
                    {
                        this.WeaponsBag.Add(this.EquippedWeapon);
                        this.Strength -= this.EquippedWeapon.Strength;
                        this.EquipWeapon(Convert.ToInt32(toEquip));
                        this.WeaponsBag.RemoveAt(Convert.ToInt32(toEquip));
                        this.Strength += this.EquippedWeapon.Strength;
                    }
                }
            }
            else if (choosenEquip == "2")
            {
                foreach (var a in this.ArmorsBag)
                {
                    Console.WriteLine(this.ArmorsBag.IndexOf(a) + ". " + a.Name + " of strength " + a.Defense);
                }
                var toEquip = Console.ReadLine();
                if (toEquip == "0" || toEquip == "1" || toEquip == "2")
                {
                    if(EquippedArmor == null)
                    {
                        this.EquipArmor(Convert.ToInt32(toEquip));
                        this.Defense += this.EquippedArmor.Defense;
                        this.ArmorsBag.RemoveAt(Convert.ToInt32(toEquip));
                    }
                    else
                    {
                        this.ArmorsBag.Add(this.EquippedArmor);
                        this.Defense -= this.EquippedArmor.Defense;
                        this.EquipArmor(Convert.ToInt32(toEquip));
                        this.Defense += this.EquippedArmor.Defense;
                        this.ArmorsBag.RemoveAt(Convert.ToInt32(toEquip));
                    }
                }

            }else if(choosenEquip == "3")
            {
                if(this.PotionBag.Count > 0)
                {
                    foreach(var p in this.PotionBag)
                    {
                        this.CurrentHP += p.HP;
                        Console.WriteLine(p.HP);
                    }
                }
            }
            else
            {
                Console.WriteLine("You don't have any equipment");
            }

        }
        
    }
}