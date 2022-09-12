using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
	internal class Player
	{
        #region PROPERTIES
        // Properties
        public float Health { get; private set; } 
		public float MaxHealth { get; private set; }
		public float Mana { get; private set; } 
		public float MaxMana { get; private set; }
		public float ATK { get; private set; }
		public int STR { get; private set; }
		public int DEX { get; private set; }
		public int INT { get; private set; }

		public List<Item> Inventory { get; set; } = new List<Item>();
		public List<Item> Equipment { get; set; } = new List<Item>();
		private UIEventArgs eventArgs = new UIEventArgs();
        #endregion

        // Constructor
        public Player()
		{
			Health = 10;
			MaxHealth = 10;
			Mana = 100;
			MaxMana = 100;
			ATK = 0;
			STR = 1;
			DEX = 1;
			INT = 1;
			eventArgs.Player = this;
		}

		/// <summary>
		/// Makes the player take the given amount of damage.
		/// </summary>
		/// <param name="amount">The amount of damage to take.</param>
		public void TakeDamage(float amount, ProgressBar hpBar, GroupBox hpText)
        {
			Health = Math.Max(Health - amount, 0);
			MainForm.UpdateHealthBar(hpBar, hpText, this);
        }

		/// <summary>
		/// Heals the player by the specified amount.
		/// </summary>
		/// <param name="amount">The amount to heal.</param>
		public void Heal(float amount, ProgressBar hpBar, GroupBox hpText)
        {
			Health = Math.Min(Health + amount, MaxHealth);
			MainForm.UpdateHealthBar(hpBar, hpText, this);
        }

		/// <summary>
		/// Adds the specified Item object to the Player's Inventory.
		/// </summary>
		/// <param name="itemToAdd">The Item object to be added.</param>
		/// <param name="TV">The TreeView displaying the items.</param>
		public void AddToInventory(Item itemToAdd)
		{
			// TODO: BETTER EQUALITY COMPARER FOR ITEMS
			Item? added = Inventory.Find(x => itemToAdd.Equals(x));
			if (added != null)
			{
				added.Amount++;
			}
			else
			{
				if (itemToAdd.Amount < 1)
				itemToAdd.Amount++;

				Inventory.Add(itemToAdd);
			}

			MainForm.OnUIUpdate(eventArgs);
		}

		/// <summary>
		/// Adds the specified amount of Item objects to the Player's Inventory.
		/// </summary>
		/// <param name="itemToAdd">The Item object to be added.</param>
		/// <param name="amount">The amount of Items to add.</param>
		/// <param name="TV">The TreeView displaying the items.</param>
		public void AddToInventory(Item itemToAdd, int amount)
		{
			Item? added = Inventory.Find(x => itemToAdd.Equals(x));
			if (added != null)
			{
				added.Amount += amount;
			}
			else
			{
				itemToAdd.Amount = amount;
				Inventory.Add(itemToAdd);
			}

			MainForm.OnUIUpdate(eventArgs);
		}

		/// <summary>
		/// Removes the specified Item object from the Player's Inventory.
		/// </summary>
		/// <param name="itemToRemove">The Item object to be removed.</param>
		/// /// <param name="TV">The TreeView displaying the items.</param>
		public void RemoveFromInventory(TreeView TV, Item itemToRemove)
		{
			Item? removed = Inventory.Find(x => itemToRemove.Equals(x));

			if (removed != null)
			{
				if (removed.Amount > 1)
				{
					removed.Amount--;
				}
				else
				{
					Inventory.Remove(removed);
				}
			}

			MainForm.UpdateInventory(TV, this);
		}

		/// <summary>
		/// Checks for the Item in the Player's Inventory specified with a name.
		/// </summary>
		/// <param name="name">The name of the Item to find.</param>
		public bool ExistsInInventory(string name)
		{
			return Inventory.Any(x => x.Name == name);
		}

		/// <summary>
		/// Checks for the Item in the Player's Inventory specified with an Id.
		/// </summary>
		/// <param name="id">The Id of the Item to find.</param>
		public bool ExistsInInventory(int id)
		{
			return Inventory.Any(x => x.Id == id);
		}

		/// <summary>
		/// Checks for available player data to load, if none, creates new data.
		/// </summary>
		/// <returns>Player data.</returns>
		public static Player LoadPlayerData()
		{
			return new Player();
		}
	}
}
