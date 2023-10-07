using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Tests.UnitTest.Scripts
{
    public class Inventory
    {
        private Dictionary<EquipSlots, Item> equippedItems = new Dictionary<EquipSlots, Item>();
        private List<Item> unequippedItems = new List<Item>();

        private readonly ICharacter character;
        
        public Inventory(ICharacter character)
        {
            this.character = character;
        }
        
        public void EquipItem(Item item)
        {
            if (equippedItems.TryGetValue(item.EquipSlot, out var oldIteM))
            {
                unequippedItems.Add(oldIteM);
            }

            equippedItems[item.EquipSlot] = item; 
            character.OnItemEquipped(item);
        }

        public Item GetItem(EquipSlots equipSlot)
        {
            return equippedItems.TryGetValue(equipSlot, out var item) ? item : null;
        }

        public int GetTotalArmor()
        {
            int totalArmor = equippedItems.Values.Sum(item => item.Armor);
            return totalArmor;
        }
    }
}
