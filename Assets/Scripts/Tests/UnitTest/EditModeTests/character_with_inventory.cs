using NSubstitute;
using NUnit.Framework;
using Tests.UnitTest.Scripts;

namespace Tests.UnitTest.EditModeTests
{
    public class character_with_inventory
    {
        [Test]
        public void with_90_armor_takes_10_percent_damage()
        {
            //ARRANGE 
            ICharacter character = Substitute.For<ICharacter>();
            Inventory inventory = new Inventory(character);

            Item pants = new Item() { EquipSlot = EquipSlots.Legs, Armor = 40 };
            Item shield = new Item() { EquipSlot = EquipSlots.RightHand, Armor = 50 };
            
            inventory.EquipItem(pants);
            inventory.EquipItem(shield);

            // character.Inventory = inventory;
            character.Inventory.Returns(inventory);

            // ACT
            int calculatedDamage = DamageCalculator.CalculateDamage(1000, character);
            
            // ASSERT
            Assert.AreEqual(100, calculatedDamage);
        }
    }
}
