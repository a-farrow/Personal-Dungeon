using DungeonLibrary;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here your journey begins, whether you will survive the countless opponets" +
                " that come your way is up to you! \nYour kingdom has faith in you!");

            #region Player setup
            Console.Write("\nSo tell us your name, hopefully it won't be added to the list of dead players," +
                " but I do have my doubts. \nMy Name is: ");
            string playerName = Console.ReadLine();
            Console.WriteLine($"\n\nAhh so {playerName} is your name. Now we will know what to put on your tombstone!");


            #endregion

            #region Main Game Loop

            bool exit = false; //if true game will quit
            do
            {
                //TODO generate a monster
                //TODO generate a room
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
                        "X) Exit\n");

                    string userChoice = Console.ReadKey(true).Key.ToString();
                    Console.Clear();

                    switch (userChoice)
                    {
                        case "A":
                            Console.WriteLine("ATTACK!");
                            //TODO Combat Functionality
                            break;
                        case "R":
                            //TODO Monster Free Attack Chance
                            Console.WriteLine("Run Away!!!");
                            newRoom = true;
                            break;

                        case "P":
                            Console.WriteLine("Behold, a gamer...");
                            //TODO show player info
                            break;

                        case "O":
                            Console.WriteLine("Monster Stuff");
                            //TODO show monster info
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
                    //TODO Check Playyer Life
                    #endregion
                } while (!newRoom && !exit);//while both newRoom and exit are not true, keep looping.
                #endregion
            } while (!exit);//while exit is not true, keep looping

            #endregion

            #region Outro
            //TODO Final Score, end the story
            #endregion
        }
        private static string GetRoom()
        {
            string[] rooms =
            {
            "As you step into the Great Hall, your footsteps echo against the stone walls which \nare full of countless banners depicting heroic " +
            "battles and noble deeds. Courtiers whisper in hushed nervous tones, casting wary glances in your direction.",

            "The Armory is a vast chamber filled with rows of gleaming weapons and suits of armor, reflecting the flickering light of torches " +
            "mounted on the walls. Swords, shields, and axes line the racks, all waiting to be used by brave warriors in battle.",

            "You are engulfed by darkness as narrow passageways wind their way through the labyrinthine tunnels. Skulls and bones litter " +
            "\nthe ground, silent witnesses to the countless souls laid to rest within these walls. A sense of dread hangs heavy in the \nair as " +
            "your next opponent is looking to have you laid to rest within these very walls.",

            "Concealed within the heart of the castle, the Secret Chamber is a hidden sanctuary of ancient mysteries \nand forbidden knowledge." +
            " Torchlight flickers off the walls, illuminating shelves laden with dusty tomes and curious artifacts. The air hums with latent magic," +
            " hinting at the power and peril that lies dormant within these hallowed halls.",

            "Stepping into the Royal Library, you are surrounded by towering shelves laden with leather-bound tomes and scrolls of ancient \nwisdom." +
            " Dust motes dance in the shafts of sunlight that filter through stained glass windows. The scent of aged parchment \nfills the air.",

            "Hidden deep in the forest, the Bandit Camp is a lawless outpost where brigands and cutthroats gather to plan raids and divide \ntheir " +
            "ill-gotten gains. Tents and makeshift shelters dot the clearing, and the sound of raucous laughter and \nclanging swords fills the air.",

            "Venturing into the Abandoned Mine, you find yourself in a labyrinth of tunnels and caverns, where the walls glisten with veins of " +
            "precious ore and the air is heavy with the scent of damp earth and sulfur. Shadows dance in the flickering light of your \ntorch, and " +
            "distant echoes hint at the presence of unseen dangers lurking in the darkness."
            };
            Random rand = new Random();

            int index = rand.Next(rooms.Length);

            string room = rooms[index];

            return room;


        }
        Weapon a1 = new Weapon("Short Sword", 20, 70, 0, false, WeaponType.Close_Range);
        Weapon a2 = new Weapon("Longsword", 20, 70, 5, false, WeaponType.Close_Range);
        
        Weapon b1 = new Weapon("Battleaxe", 30, 90, 3, true, WeaponType.Close_Range);
        Weapon c1 = new Weapon("Crossbow", 40, 85, 8, true, WeaponType.Long_Range);
        Weapon d1 = new Weapon("Warhammer", 35, 95, 4, true, WeaponType.Close_Range);
        Weapon c2 = new Weapon("Shortbow", 30, 60, 12, false, WeaponType.Medium_Range);
        Weapon e1 = new Weapon("Throwing Axe", 20, 70, 9, false, WeaponType.Medium_Range);

    }
}
