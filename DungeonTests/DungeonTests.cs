using DungeonLibrary;
using Xunit.Sdk;

namespace DungeonTests
{
    public class DungeonTests
    {
        [Fact]
        public void Test_MaxLife()
        {
            Player player = new Player("", 0, 0, 100, 0, 0, new Weapon("", 0, 2, 0, true));
            int expected = 100;

            player.Life += 20;

            Assert.Equal(expected, player.Life);
        }

        [Fact]
        public void Test_WeaponMaxDamage()
        {
            //use in-range function to specify range
            Weapon weapon = new Weapon("", 5, 75, 0, true);
             int expected = 75;

            weapon.MaxDamage += 100;

            Assert.InRange(75, 5, 75);
        }
    }
}