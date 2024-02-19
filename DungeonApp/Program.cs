using DungeonLibrary;
using System.Numerics;
using System.Threading;
using System.Transactions;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Here your journey begins, whether you will survive the countless opponets" +
                " that come your way is all up to you!");
            Thread.Sleep(4000);
            Console.WriteLine("\nYour Kingdom has faith in you!");
            Thread.Sleep(2000);
            #region Player setup
            Weapon uw = GetWeapon();
            Console.WriteLine($"\nThe {uw.Name}, that's a great choice! So now tell us your name...hopefully it won't be added to the list of dead \nplayers, but I do have my doubts.");
            
            Console.Write("\nMy Name is: ");
            string playerName = Console.ReadLine();
            //Weapon weapon = new Weapon("Longsword", 30, 50, 0, true);
            Player player = new Player(playerName, 50, 25, 100, 75, 5, uw);
            Console.Clear();
            Console.WriteLine($"\n\nAhh so {playerName} is your name. Now we will know what to put on your tombstone!");
            List<Monster> monsters = Monster.GetMonsters();
            Thread.Sleep(4000);
            Console.WriteLine($"\nHere's a look at your {uw.Name}, you and it will need to work together as one. Your life and survival depends on it!\n\nWeapon: {uw}");
            Thread.Sleep(3000);
            Console.WriteLine("\nNow here is your first opponent...");
            Console.WriteLine();
            Console.ResetColor();
            Thread.Sleep(4500);


            #endregion

            #region Main Game Loop

            
            bool exit = false; //if true game will quit
            do
            {
                 
                //generate a monster
                Monster currentMonster = new Monster();
                foreach (Monster item in monsters)
                {
                    if (item.Life > 0)
                    {
                        currentMonster = item;
                        break;
                    }
                }
                
                Console.WriteLine(currentMonster);
                //generate a room
                string room = GetRoom();

                Console.WriteLine("\n\nLocation description: \n\n" + room);
                #region Encounter Loop
                bool newRoom = false;
                do
                {
                    #region MENU
                    //Prompt the user
                    Console.Write("\n\n\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "O) Opponent Info\n" +
                        "X) Exit to Main Menu\n");

                    string userChoice = Console.ReadKey(true).Key.ToString();
                    Console.Clear();

                    switch (userChoice)
                    {
                        case "A":
                            Console.WriteLine("ATTACK!");
                            bool deadMonster = Combat.DoBattle(player, currentMonster);
                            
                            newRoom = deadMonster;
                            break;
                        case "R":
                            //Monster Free Attack Chance
                            Console.WriteLine("Run Away!!!");
                            Console.WriteLine($"{currentMonster.Name} attacks you as you flee...");
                            Combat.DoAttack(currentMonster, player);
                            newRoom = true;
                            break;

                        case "P":
                            //Console.WriteLine("Behold, a gamer...");
                            //show player info
                            Console.WriteLine(player);
                            break;

                        case "O":
                            //Console.WriteLine("Opponent Info:");
                            //show monster info
                            Console.WriteLine(currentMonster);
                            break;

                        case "X":
                            Console.WriteLine("No one likes a quitter.");
                            exit = true;
                            break;
                        default:
                            #region Invalid input
                            Console.WriteLine("Invalid Input. You have made a grave error. Wanna try again?");
                            #endregion
                            break;
                    }

                    #endregion

                    #region Check player life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("\n _______    _________    _______ \n(  ____ )   \\__   __/   (  ____ )\r\n| (    )|      ) (      | (    )|\r\n| (____)|      | |      | (____)|\r\n|     __)      | |      |  _____)\r\n| (\\ (         | |      | (      \r\n| ) \\ \\__ _ ___) (___ _ | )_     \r\n|/   \\__/(_)\\_______/(_)|/(_)\a");
                        exit = true;
                    }
                    #endregion
                } while (!newRoom && !exit);//while both newRoom and exit are not true, keep looping.
                #endregion

            } while (!exit);//while exit is not true, keep looping

            Console.WriteLine($"\nYou Killed {player.Score} Opponets!");

            Console.Write("\n\n\nWould you like to play again?\n" +
                        "Y) Yes, Play Again\n" +
                        "N) No, Exit\n");

                string userChoiceQuit = Console.ReadKey(true).Key.ToString();
                Console.Clear();

                 switch (userChoiceQuit)
                {
                    case "Y":
                    case "y":
                    case "Yes":
                    case "yes":
                    case "YES":
                        Console.WriteLine("Let's see if you can do better this time!");
                    Main(args);
                        break;
                    case "N":
                    case "n":
                    case "No":
                    case "NO":
                    case "no":
                        Console.WriteLine("We always knew you weren't a fighter.");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. We will see you next time!");
                        break;
                }
            #endregion

            #region Outro
            Thread.Sleep(1500);
            Console.WriteLine($"Not bad, but you can defintly do better.");
            //Console.ReadKey(true);
            #endregion
        }
        private static string GetRoom()
        {
            string[] rooms =
            {
            "As you step into the Great Hall, your footsteps echo against the stone walls which \nare full of countless banners depicting heroic " +
            "battles and noble deeds. Courtiers whisper in hushed nervous tones, \ncasting wary glances in your direction.",

            "The Armory is a vast chamber filled with rows of gleaming weapons and suits of armor, reflecting the flickering \nlight of torches " +
            "mounted on the walls. Swords, shields, and axes line the racks, all waiting to be used by \nbrave warriors in battle.",

            "You are engulfed by darkness as narrow passageways wind their way through the labyrinthine tunnels. Skulls and \nbones litter " +
            "the ground, silent witnesses to the countless souls laid to rest within these walls. A sense of dread \nhangs heavy in the air as " +
            "your next opponent is looking to have you laid to rest within these very walls.",

            "Concealed within the heart of the castle, the Secret Chamber is a hidden sanctuary of ancient mysteries \nand forbidden knowledge." +
            " Torchlight flickers off the walls, illuminating shelves laden with dusty tomes and curious \nartifacts. The air hums with latent magic," +
            " hinting at the power and peril that lies dormant within these hallowed halls.",

            "Stepping into the Royal Library, you are surrounded by towering shelves laden with leather-bound tomes and scrolls \nof ancient wisdom." +
            " Dust motes dance in the shafts of sunlight that filter through stained glass windows. The scent \nof aged parchment fills the air.",

            "Hidden deep in the forest, the Bandit Camp is a lawless outpost where brigands and cutthroats gather to plan raids and \ndivide their " +
            "ill-gotten gains. Tents and makeshift shelters dot the clearing, and the sound of raucous laughter and \nclanging swords fills the air.",

            "Venturing into the Abandoned Mine, you find yourself in a labyrinth of tunnels and caverns, where the walls glisten \nwith veins of " +
            "precious ore and the air is heavy with the scent of damp earth and sulfur. Shadows dance in the \nflickering light of your torch, and " +
            "distant echoes hint at the presence of unseen dangers \nlurking in the darkness."
            };
            Random rand = new Random();

            int index = rand.Next(rooms.Length);

            string room = rooms[index];

            return room;


        }
        public static Weapon GetWeapon()
        {
            Weapon w1 = new Weapon("Longsword", 30, 50, 0, true);
            Weapon w2 = new Weapon("Battleaxe", 20, 60, 0, true);
            Weapon w3 = new Weapon("Crossbow", 5, 75, 5, true);

            List<Weapon> Weapons = new List<Weapon>()
            {
                w1,
                w2,
                w3,
            };
            //TODO change return weapon
            foreach (Weapon item in Weapons)
            {
                Console.WriteLine($"\nTo make sure you stand a chance here's 3 Types of Weapons you can choose from... \nPick wisely! Only answer by typing A, B, or C.\n\nOption A - Longsword, the most balanced and consistent weapon, this sword can even give slow and uncordinated \npeople like you a decent chance.\n\nOption B - Battleaxe, if you're cocky and confident in your warrior abilities then this may be the choice for you. \nThe battleaxe has a higher maximum damage but also a lower minimum damage then the Longsword.\n\nOption C - Crossbow, if you're the gambler type (or the sissy type) then this is the choice for you! If you can aim \nwell then lucky for you this weapon will have the highest hit chance and max damage of them all, but if you can't \naim then even a fly could deal more damage.");

                Console.Write("\nPick Your Weapon:\nType: (A) Longsword\nType: (B) Battleaxe\nType: (C) Crossbow\n");
                string userWeaponChoice = Console.ReadKey(true).Key.ToString().ToUpper();
                int intWeaponChoice;
                //intWeaponChoice = 0;
                if (userWeaponChoice == "A")
                {
                    intWeaponChoice = 0;
                    //int.Parse(userWeaponChoice) = 0;
                }
                else if (userWeaponChoice == "B")
                {
                    intWeaponChoice = 1;
                }
                else if (userWeaponChoice == "C")
                {
                    intWeaponChoice = 2;
                }
                else
                {
                    Console.WriteLine("Since you couldn't follow instruction we will just give you the Longsword!");
                    intWeaponChoice = 0;
                }

                return Weapons[intWeaponChoice];

            }
            //Console.WriteLine in a foreach
            //Console.Readkey to collect user input
            //Parse input to an int then change the Weapons index to that int.
            return null;
            //return Weapons[0];
        }

        /*Weapon w1 = new Weapon("Short Sword", 20, 70, 0, false, WeaponType.Close_Range);
        Weapon w2 = new Weapon("Longsword", 20, 70, 5, false, WeaponType.Close_Range);
        
        Weapon w3 = new Weapon("Battleaxe", 30, 90, 3, true, WeaponType.Close_Range);
        Weapon w4 = new Weapon("Crossbow", 40, 85, 8, true, WeaponType.Long_Range);
        Weapon w5 = new Weapon("Warhammer", 35, 95, 4, true, WeaponType.Close_Range);
        Weapon w6 = new Weapon("Shortbow", 30, 60, 12, false, WeaponType.Medium_Range);
        Weapon w7 = new Weapon("Throwing Axe", 20, 70, 9, false, WeaponType.Medium_Range);*/

        

    }
}
