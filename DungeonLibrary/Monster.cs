using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //FIELDS
        private int _minDamage;

        //PROPERTIES
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //CONSTRUCTORS
        public Monster(string name, int hitChance, int dodge, int maxLife,
            int maxDamage, int minDamage, string description)
            : base(name, hitChance, dodge, maxLife)
        {
            //MacDamage must be set before MinDamage
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;

        }
        //default ctor for default monsters later
        //If your parent class does not have a parameterless ctor, you CANNOT have one in the child classes.
        public Monster() //: base()
        {

        }
        //METHODS
        public override string ToString()
        {
            return "********** OPPONENT **********\n" +
                base.ToString() +
                $"Damage: {MinDamage} - {MaxDamage}\n" +
                $"Description: {Description}";
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }

        public static List<Monster> GetMonsters()
        {
            //Come back and customize this list with your own monster subtypes.
            Monster m1 = new("Willowbrook Archer", 80, 20, 30, 10, 2, "A skilled marksman from the lush forests of Willowbrook, capable of raining down deadly arrows upon \ntheir foes. Speed, anticipation and staying out of sight is the name of their game. However just one significant \nstrike can lay them to rest. Their arrows have a max damage of 10 per hit.");
            
            Monster m2 = new("Riverdale Squire", 70, 15, 40, 20, 10, "A young and agile warrior training to become a knight, wielding a sword with finesse and determination. \nHe can deal up to 20 damage with each swift strike.");
            
            Monster m3 = new("Greenwood Footman", 80, 20, 50, 25, 5, "A stalwart defender of the feared Greenwood realm, armed with a sturdy spear that can deal up to 25 damage \neach hit. This Footman is not one you should take lightly! As his ability to land hits and dodge attacks may give \nhim the upperhand in this battle.");
            // Possibly reset USERPLAYER health here
            Monster m4 = new("Stonegate Guardsman", 55, 20, 50, 50, 20, "Now an even tougher task, this battle you will face a disciplined soldier sworn to protect the unpassable \ngates of the Stonegate Kingdom. He wields a terrifying human crushing Battle Axe that if lands can deal up to a bone \nshivering 50 damage each hit! The gates and walls of Stonegate haven't been breached in over a century. This Guardsman \nhas even lost one of his eyes in the honor of battle and since then his ability to actually land his strikes has been \ndiminished. That may be your only hope at victory.");
            
            Monster m5 = new("Blackthorn Knight", 75, 20, 60, 35, 20, "A fearsome knight covered head-to-toe in the black battle tested armor of the Blackthorn mercenary guild, \nknown for their relentless assault and unwavering resolve in battle. This knight may very well add you to his list of \nkills as his freshly sharpened longsword deals up to 35 each hit!");
            
            Monster m6 = new("Ironfang Warlord", 80, 20, 50, 40, 20, "A ruthless leader of the Ironfang clan, commanding their forces with strategic prowess and brute force. \nDon't mistake his ability to command with his ability to battle as he's as battle tested as any. With his \nstrategic upperhand and his Warhammer which can land up to 40 damage with each thunderous strike.");
            // Possibly reset USERPLAYER health here
            Monster m7 = new("Dreadfort Champion", 75, 25, 50, 40, 30, "Wielding a massive two-handed axe that can deal up to 40 damage, this champion is ready to send their \nunmatched ferocity and brutality your way to protect Dreadfort and more importantly his status as champion. \nHis sheer strength also posses a big threat with each landed strike dealing a minimum of 30 damage!");
            
            Monster m8 = new("Shadowmarch Overlord", 90, 20, 60, 40, 10, "You have had an incredible journey! Win this battle and all the gold and riches will be yours. Now the Shadowmarch Overlord, \nthe formidable ruler of Shadowmarch who is feared all across Medieval Europe, cloaked in darkness and wielding dark powers that bend reality almost to their will. Their apparent mastery over shadowy forces guides their Throwing Axes almost without error to their targets, striking with deadly accuracy each shadow infused axe throw that hits their target deals up to a staggering 40 damage. If you are to defeat this Overlord you will need to overcome both his dark powers and deadly accuracy, you must land some massive hits of your own, on top of all that you will even need a bit of luck.");

            List<Monster> monsters = new List<Monster>()
            {
                m1,
                m2,
                m3,
                m4,
                m5,
                m6,
                m7,
                m8
            };
            return monsters;
            

        }
    }
}
