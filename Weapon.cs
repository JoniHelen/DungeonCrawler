using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
	internal class Weapon : Item
	{
		// Properties

		/// <summary>The base <c>Damage</c> stat of the Weapon.</summary>
		public float WeaponDamage { get; set; }

		/// <summary>The <c>STR</c> scaling of the Weapon.</summary>
		public WeaponScaling STRScaling { get; set; }

		/// <summary>The <c>DEX</c> scaling of the Weapon.</summary>
		public WeaponScaling DEXScaling { get; set; }

		/// <summary>The <c>INT</c> scaling of the Weapon.</summary>
		public WeaponScaling INTScaling { get; set; }

		/// <summary>The <c>Enchantment</c> of the Weapon.</summary>
		public WeaponEnchantment Enchantment { get; set; }

		/// <summary>The <c>Enchantability</c> factor of the Weapon.</summary>
		public float Enchantability { get; set; }


		// Constructor

		/// <summary>
		/// Creates a new weapon with the option of adding an enchantment.
		/// </summary>
		/// <param name="id">The item Id</param>
		/// <param name="value">Value of the Item</param>
		/// <param name="rarity">Rarity of the Item</param>
		/// <param name="weaponDamage">Base Damage of the weapon</param>
		/// <param name="strScaling">STR scaling of the weapon</param>
		/// <param name="dexScaling">DEX scaling of the weapon</param>
		/// <param name="intScaling">INT scaling of the weapon</param>
		/// <param name="enchantability">The enchantability multiplier</param>
		/// <param name="name">Name of the Item</param>
		/// <param name="enchantment">The Enchantment applied to the weapon</param>
		/// <param name="amount">Amount of items</param>
		public Weapon(int id, float value, ItemRarity rarity, float weaponDamage, string strScaling, string dexScaling, string intScaling, float enchantability, string name = "", WeaponEnchantment enchantment = new(), int amount = 0) : base(id, value, rarity, name, amount)
		{
			Id = id;
			Value = value;
			Rarity = rarity;
			Name = name;
			Amount = amount;
			WeaponDamage = weaponDamage;
			STRScaling = new(strScaling);
			DEXScaling = new(dexScaling);
			INTScaling = new(intScaling);
			Enchantment = enchantment;
			Enchantability = enchantability;
		}

        public override bool Equals(object? obj)
        {
			if (obj != null && obj is Weapon w)
            {
				return base.Equals(w) 
					&& w.WeaponDamage == WeaponDamage 
					&& w.STRScaling.Equals(STRScaling.Grade) 
					&& w.DEXScaling.Equals(DEXScaling.Grade) 
					&& w.INTScaling.Equals(INTScaling.Grade) 
					&& w.Enchantment.Equals(Enchantment) 
					&& w.Enchantability == Enchantability;
            }
			else
            {
				return false;
            }
        }

        // Struct

        /// <summary>
        /// Represents the Weapon's stat scaling in grades.
        /// </summary>
        public struct WeaponScaling
		{
			/// <summary>The <c>Grade</c> of the Scaling.</summary>
			public string Grade { get; set; }

			public WeaponScaling(string grade)
            {
				Grade = grade;
            }

			/// <summary>
			/// Converts the string grade to a float multiplier.
			/// </summary>
			/// <returns>Returns the grade multiplier as a float value.</returns>
			public float ToFloat()
            {
                return Grade switch
                {
                    "S+" => 1.50f,
					"S" => 1.25f,
                    "A+" => 1.10f,
                    "A" => 1.00f,
                    "B+" => 0.95f,
                    "B" => 0.90f,
                    "C+" => 0.85f,
                    "C" => 0.80f,
                    "D+" => 0.75f,
                    "D" => 0.70f,
                    "E+" => 0.65f,
                    "E" => 0.60f,
                    _ => 0f,
                };
            }

            public override bool Equals(object? obj)
            {
				if(obj is string)
                {
					return Grade.Equals(obj);
				}
				else if (obj is float f)
                {
					return f.Equals(ToFloat());
                }
                else
                {
					return false;
                }
                
            }

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
		}

		/// <summary>
		/// Represents the Enchantment values of a Weapon.
		/// </summary>
		public struct WeaponEnchantment
		{
			/// <summary>The <c>ATK</c> percentage boost of the Enchantment.</summary>
			public float ATKUp { get; set; }

			/// <summary>The flat <c>ATK</c> boost of the Enchantment.</summary>
			public float ATKUpFlat { get; set; }

			/// <summary>The <c>STR</c> scaling boost of the Enchantment.</summary>
			public float STRScalingUp { get; set; }

			/// <summary>The <c>DEX</c> scaling boost of the Enchantment.</summary>
			public float DEXScalingUp { get; set; }

			/// <summary>The <c>INT</c> scaling boost of the Enchantment.</summary>
			public float INTScalingUp { get; set; }

            public override bool Equals(object? obj)
            {
				if (obj != null && obj is WeaponEnchantment we)
                {
					return we.ATKUp == ATKUp 
						&& we.ATKUpFlat == ATKUpFlat 
						&& we.STRScalingUp == STRScalingUp 
						&& we.DEXScalingUp == DEXScalingUp 
						&& we.INTScalingUp == INTScalingUp;
				}
				else
                {
					return false;
                }
                
            }

            public override int GetHashCode()
            {
				return base.GetHashCode();
			}
        }

        public override int GetHashCode()
        {
			return base.GetHashCode();
        }
    }
}
