using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
	internal class Item
	{
		// Properties
		public string Name { get; set; }
		public int Id { get; set; }
		public int Amount { get; set; }
		public float Value { get; set; }
		public ItemRarity Rarity { get; set; }

		// Constructor
		public Item(int id, float value, ItemRarity rarity, string name = "", int amount = 0)
		{
			Name = name;
			Id = id;
			Amount = amount;
			Value = value;
			Rarity = rarity;
		}

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Item i)
            {
                return i.Name == Name && i.Rarity == Rarity && i.Id == Id;
            }
			else 
			{
				return false; 
			}
        }

		public enum ItemRarity
        {
			Common,
			Uncommon,
			Rare,
			Heroic,
			Epic,
			Legendary,
			Mythical
        }

        public override int GetHashCode()
        {
			return base.GetHashCode();
        }
    }
}
