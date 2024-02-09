namespace DungeonLibrary
{
    public class Character
    {
        //FIELDS
        private string _name = null!;
        private int _maxLife;
        private int _life;
        private int _hitChance;
        private int _dodge;
        //PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }

        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }

        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }

        public int Dodge
        {
            get { return _dodge; }
            set { _dodge = value; }
        }
        //CONSTRUCTORS
        public Character(string name, int hitChance, int dodge, int maxLife)
        {
            // we did not account for Life in the parameter list because we're going to assign it manually
            //Property
            Name = name;
            HitChance = hitChance;
            Dodge = dodge;
            MaxLife = maxLife;
            Life = maxLife;//start all characters at max health.
        }

        public Character()
        {
            //added so we can have default ctors in our monster classes later
        }
        //METHODS
        public override string ToString()
        {
            //return base.ToString(); //Namespace.ClassName -> DungeonLibrary.Character
            return $"----- {Name} -----\n" +
                   $"Life: {Life}/{MaxLife}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Dodge: {Dodge}%\n";
        }

        public int CalcDodge()
        {
            return Dodge;
        }

        public int CalcHitChance()
        {
            return HitChance;
        }

        public int CalcDamage()
        {
            return 0;
        }
    }
}
