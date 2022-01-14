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

        /// <summary>The <c>Health</c> value of the Player.</summary> 
        public float Health { get; private set; }

		/// <summary>The <c>MaxHealth</c> value of the Player.</summary> 
		public float MaxHealth { get; private set; }

		/// <summary>The <c>Mana</c> value of the Player.</summary> 
		public float Mana { get; private set; }

		/// <summary>The <c>MaxMana</c> value of the Player.</summary> 
		public float MaxMana { get; private set; }

		/// <summary>The <c>Attack</c> value of the Player.</summary> 
		public float ATK { get; private set; }

		/// <summary>The <c>Strength</c> stat value of the Player.</summary> 
		public int STR { get; private set; }

		/// <summary>The <c>Dexterity</c> stat value of the Player.</summary> 
		public int DEX { get; private set; }

		/// <summary>The <c>Intelligence</c> stat value of the Player.</summary> 
		public int INT { get; private set; }

		/// <summary>The Inventory list of the Player.</summary> 
		public List<Item> Inventory { get; set; } = new List<Item>();

		/// <summary>The Equipment list of the Player.</summary>
		public List<Item> Equipment { get; set; } = new List<Item>();
        #endregion

        // Constructor

        /// <summary>Create a new Player with default stats.</summary>
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
		public void AddToInventory(TreeView TV, Item itemToAdd)
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

			MainForm.UpdateInventory(TV, this);
		}

		/// <summary>
		/// Adds the specified amount of Item objects to the Player's Inventory.
		/// </summary>
		/// <param name="itemToAdd">The Item object to be added.</param>
		/// <param name="amount">The amount of Items to add.</param>
		/// <param name="TV">The TreeView displaying the items.</param>
		public void AddToInventory(TreeView TV, Item itemToAdd, int amount)
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

			MainForm.UpdateInventory(TV, this);
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
