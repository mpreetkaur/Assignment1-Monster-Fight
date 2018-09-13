using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }
        public Monster monster { get; set; }
        
        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Ninja", 13, 15, 40);
            this.AddMonster("Pikachu", 5, 17, 10);
            this.AddMonster("Turtle", 9, 21, 35);
            var enemy = this.Monsters[0];
            var lastEnemy = this.Monsters.Last();
            var secondEnemy = this.Monsters.ElementAt(1);
            var randomEnemy = this.Monsters.OrderBy(p => Guid.NewGuid()).LastOrDefault();
            var lessHpEnemy = (from p in this.Monsters select p.CurrentHP < 20).FirstOrDefault();
            var lessStrengthEnemy = (from p in this.Monsters select p.Strength >= 11).FirstOrDefault();
            this.monster = randomEnemy;

        }

        public void AddMonster(string name, int strength, int defense, int hp) {
            var monster = new Monster(name, strength, defense,hp,hp);
            this.Monsters.Add(monster);
        }
        
        public void Start() {
           

            Console.WriteLine("You've encountered a " + monster.Name + "! " + monster.Strength + " Strength/" + monster.Defense + " Defense/" +
            monster.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn();
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(){
          
           var compare = hero.Strength - monster.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
                monster.CurrentHP -= damage;
           }
           else{
               damage = compare;
                monster.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(monster.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){
           int damage;
           var compare = monster.Strength - hero.Defense;
           if(compare <= 0) {
               damage = 1;
               hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               hero.CurrentHP -= damage;
           }
           Console.WriteLine(monster.Name + " does " + damage + " damage!");
           if(hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {
            Console.WriteLine(monster.Name + " has been defeated! You win the battle!");
            this.hero.Gold += this.monster.Gold;
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}