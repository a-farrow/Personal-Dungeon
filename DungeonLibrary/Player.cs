using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public int _maxDamage { get; set; }
        public int _minDamage { get; set; }


        //Properties
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }




        //Constructors
        public Player(string name, int hitChance, int dodge, int maxLife, int maxDamage, int minDamage, Weapon equippedWeapon)
            : base(name, hitChance, dodge, maxLife)
        {
            
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            EquippedWeapon = equippedWeapon;

            #region Potential Expansion - Racial Bonuses
            
            #endregion
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"Minimum Damage: {MinDamage}" + $"\nMaximum Damage: {MaxDamage}" + $"\nOpponets Killed: {Score}";
                
        }

        public override int CalcDamage()
        {
            //create a random object
            Random rand = new Random();

            //determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage,
                EquippedWeapon.MaxDamage + 1);

            //return damage
            return damage;
        }

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }
        //attacker.CalcHitChance() - defender.CalcDodge() = 55%
        //if random.Next(1,101) < 55, then they hit. Call CalDamage, apply damage to defender.
    }
}
