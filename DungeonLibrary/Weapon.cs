using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //FIELDS
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        



        //PROPERTIES
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        

        //CONSTRUCTORS
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
        {
            if (minDamage >= maxDamage)
            {
                throw new ArgumentException("Min Damage must be less than max damage.");
            }
            else if (maxDamage > 75)
            {
                throw new ArgumentException("The max-damage must be lower then or equal to 75.");
            }
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            
        }


        //METHODS
        public override string ToString()
        {
            //return base.ToString();
            return $"{Name}\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n" +
                   //$"Bonus Hit: {BonusHitChance}%\n" +
                   $"{(IsTwoHanded ? "Two" : "One")}-Handed";
        }
    }
}
