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
        public Hero hero { get; set; }
        public Game game { get; set; }
        public Shop(Hero hero, Game game)
        {
            this.Weapon = new List<Weapon>();
            this.Armor = new List<Armor>();
            this.Potion = new List<Potion>();

            this.Weapon.Add(new Weapon("Sword", 10, 2, 3));
            this.Weapon.Add(new Weapon("Axe", 12, 3, 4));
            this.Weapon.Add(new Weapon("Longsword", 20, 5, 7));

            this.Armor.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.Armor.Add(new Armor("Metal Armor", 20, 5, 7));

            this.Potion.Add(new Potion(5, "Healing Potion", 10, 8));
            this.hero = hero;
            this.game = game;
        }
        public void MainMenu()
        {
            this.game.Main();
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to my shop! What would you like to do?");
            Console.WriteLine("1) Buy Item");
            Console.WriteLine("2) Sell Item");
            Console.WriteLine("3) Return to Game Menu");
            var chosenValue = Console.ReadLine();
            if(chosenValue == "1")
            {
                this.ShowInventory();
            }
            else if(chosenValue == "2")
            {
                this.BuyFromUser();
            }
            else
            {
                this.MainMenu();
            }
        }
        public void ShowInventory()
        {
            Console.WriteLine("a) Weapons");
            Console.WriteLine("b) Armors");
            Console.WriteLine("c) Potions");
            Console.WriteLine("r) Return to main menu");
            var selectedItem = Console.ReadLine();
            if(selectedItem == "a")
            {
                foreach(var w in this.Weapon)
                {
                    Console.WriteLine(this.Weapon.IndexOf(w) + ") " + w.Name + " costs " + w.OriginalValue + " Gold");

                }

                Console.WriteLine("r) Return to main menu");
                var choosenWeapon = Console.ReadLine();
                if(choosenWeapon == "0" || choosenWeapon == "1" || choosenWeapon == "2")
                {
                    this.Sell(Convert.ToInt32(choosenWeapon), "weapon");
                    Console.ReadLine();
                    this.MainMenu();

                }
                else
                {
                    this.MainMenu();
                }
            }
            if (selectedItem == "b")
            {
                foreach (var a in this.Armor)
                {
                    Console.WriteLine(this.Armor.IndexOf(a) + ") " + a.Name + " costs " + a.OriginalValue + " Gold");

                }
                var chooseArmor = Console.ReadLine();
                if (chooseArmor == "0" || chooseArmor == "1" || chooseArmor == "2")
                {
                    this.Sell(Convert.ToInt32(chooseArmor), "armor");
                    Console.ReadLine();
                    this.MainMenu();

                }
                else
                {
                    this.MainMenu();
                }
            }
            if (selectedItem == "c")
            {
                foreach (var p in this.Potion)
                {
                    Console.WriteLine(this.Potion.IndexOf(p) + ") " + p.Name + " costs " + p.OriginalValue + " Gold");

                }
                var choosePotion = Console.ReadLine();
                if (choosePotion == "0" || choosePotion == "1" || choosePotion == "2")
                {
                    this.Sell(Convert.ToInt32(choosePotion), "potion");
                    Console.ReadLine();
                    this.MainMenu();
                }
                else
                {
                    this.MainMenu();
                }
            }
            else if (selectedItem == "r" || selectedItem == "return")
            {
                this.MainMenu();
                Console.ReadLine();
            }
        }
        public void Sell(int item, string typeOfGadget)
        {
            if(typeOfGadget == "weapon" && this.hero.Gold > 0)
            {
                this.hero.WeaponsBag.Add(this.Weapon[item]);
                this.hero.Gold -= this.Weapon[item].OriginalValue;
            }
            else if (typeOfGadget == "armor" && this.hero.Gold > 0)
            {
                this.hero.ArmorsBag.Add(this.Armor[item]);
                this.hero.Gold -= this.Armor[item].OriginalValue;

            }
            else if (typeOfGadget == "potion" && this.hero.Gold > 0)
            {
                this.hero.PotionBag.Add(this.Potion[item]);
                this.hero.Gold -= this.Potion[item].OriginalValue;

            }
            else
            {
                Console.WriteLine("Gold is not enough for purchase");
            }
        }
        public void BuyFromUser()
        {
            Console.WriteLine("Please choose item to sell: ");
            Console.WriteLine("1) Weapons");
            Console.WriteLine("2) Armors");
            Console.WriteLine("3) Potions");
            Console.WriteLine("4) Return to main menu");
            var toBeSoldItem = Console.ReadLine();
            if(toBeSoldItem == "1" &&  hero.WeaponsBag.Count > 0)
            {
                foreach(var h in this.hero.WeaponsBag)
                {
                    Console.WriteLine(this.hero.WeaponsBag.IndexOf(h) + ") " + h.Name + " has ResellValue of " + h.ResellValue + " Gold.");
                }
                Console.WriteLine("r) Return to main menu");
                var choosenWeapon = Console.ReadLine();
                if (choosenWeapon == "0" || choosenWeapon == "1" || choosenWeapon == "2")
                {
                    this.SellFromuser(Convert.ToInt32(choosenWeapon), "weapon");
                    Console.ReadLine();
                    this.MainMenu();

                }
                else
                {
                    Console.WriteLine("Not enough gold");
                    this.MainMenu();
                }
            }
            else if (toBeSoldItem == "2" && hero.ArmorsBag.Count > 0)
            {
                foreach(var a in this.hero.ArmorsBag)
                {
                    Console.WriteLine(this.hero.ArmorsBag.IndexOf(a) + ") " + a.Name + " has ResellValue of " + a.ResellValue + " Gold.");
                }
                var chooseArmor = Console.ReadLine();
                if (chooseArmor == "0" || chooseArmor == "1" || chooseArmor == "2")
                {
                    this.SellFromuser(Convert.ToInt32(chooseArmor), "armor");
                    Console.ReadLine();
                    this.MainMenu();

                }
                else
                {
                    this.MainMenu();
                }
            }
            else if (toBeSoldItem == "3" && hero.PotionBag.Count > 0)
            {
                foreach(var p in this.hero.PotionBag)
                {
                    Console.WriteLine(this.hero.PotionBag.IndexOf(p) + ") " + p.Name + " has ResellValue of " + p.ResellValue + " Gold.");
                }
                var choosePotion = Console.ReadLine();
                if (choosePotion == "0" || choosePotion == "1" || choosePotion == "2")
                {
                    this.SellFromuser(Convert.ToInt32(choosePotion), "potion");
                    Console.ReadLine();
                    this.MainMenu();
                }
                else
                {
                    this.MainMenu();
                }
            }
            else
            {
                Console.WriteLine("No item in the bag");
                this.MainMenu();
            }
        }
        public void SellFromuser(int item, string gadget)
        {

            if (gadget == "weapon")
            {
                this.hero.WeaponsBag.RemoveAt(item);
                this.hero.Gold += this.Weapon[item].OriginalValue;
            }
            else if (gadget == "armor")
            {
                this.hero.ArmorsBag.RemoveAt(item);
                this.hero.Gold += this.Armor[item].OriginalValue;

            }
            else if (gadget == "potion")
            {
                this.hero.PotionBag.RemoveAt(item);
                this.hero.Gold += this.Potion[item].OriginalValue;

            }
            else
            {
                this.MainMenu();
            }

        }

    }
}
