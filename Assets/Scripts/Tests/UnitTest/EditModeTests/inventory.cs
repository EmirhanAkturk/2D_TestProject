using NSubstitute;
using NUnit.Framework;
using Tests.UnitTest.Scripts;

namespace Tests.UnitTest.EditModeTests
{
    public class inventory 
    {
        [Test]
        public void only_allows_one_chest_to_be_equipped_at_a_time()
        {
            //ARRANGE
            ICharacter character = Substitute.For<ICharacter>();
            Inventory inventory = new Inventory(character);
            
            Item chestOne = new Item() { EquipSlot = EquipSlots.Chest };
            Item chestTwo = new Item() { EquipSlot = EquipSlots.Chest };
            
            // ACT
            inventory.EquipItem(chestOne);
            inventory.EquipItem(chestTwo);
            
            // ASSERT
            Item equippedItem = inventory.GetItem(EquipSlots.Chest);
            Assert.AreEqual(chestTwo, equippedItem);
        }
        
        [Test]
        public void tells_character_when_an_item_is_equipped_successfully()
        {
            //ARRANGE
            ICharacter character = Substitute.For<ICharacter>();
            Inventory inventory = new Inventory(character);
            
            Item chestOne = new Item() { EquipSlot = EquipSlots.Chest };
            
            // ACT
            inventory.EquipItem(chestOne);
            
            // ASSERT
            character.Received().OnItemEquipped(chestOne);
        }
        
    }
}
