namespace DungeonCrawler
{
	public partial class MainForm : Form
	{
		/// <summary>This is the main Event that handles all of the interaction with the game.</summary>
		internal event EventHandler<GameEventArgs> GameEvent;

		internal static event EventHandler<UIEventArgs> UIUpdateEvent = delegate { };

		/// <summary>The data to be passed to all GameEvents.</summary>
		internal GameEventArgs GameArgs = new();

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// This delegate triggers the next GameEvent.
		/// </summary>
		/// <param name="e">The data to be passed to the Event.</param>
		internal virtual void OnGameEvent(GameEventArgs e)
		{
            GameEvent?.Invoke(this, e);
        }

		internal static void OnUIUpdate(UIEventArgs e)
        {
			if ((e.Elements & UIEventArgs.UpdatedElements.HealthBar) != 0) UIUpdateEvent += MainForm_UpdateInventory;
			UIUpdateEvent?.Invoke(null, e);
        }

		/// <summary>
		/// This Event is called before the Form is shown.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object? sender, EventArgs e)
		{
			GameInputBox.KeyDown += GameInputBox_KeyDown;
		}

		/// <summary>
		/// This Event feeds player input into other events while triggering them.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GameInputBox_KeyDown(object? sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				GameArgs.InputString = GameInputBox.Text;
				GameInputBox.Clear();
				OnGameEvent(GameArgs);
			}
		}

		/// <summary>
		/// This Event is called when the Form is first loaded.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Shown(object? sender, EventArgs e)
		{
			Refresh();
			Player player = Player.LoadPlayerData();
			GameArgs.Player = player;
			player.AddToInventory(new Item(0, 100, Item.ItemRarity.Common, "Stick"), 3);
			player.AddToInventory(new Item(0, 20, Item.ItemRarity.Common, "Bone"), 12);
			player.AddToInventory(new Item(0, 75, Item.ItemRarity.Common, "Grass"), 6);
			player.AddToInventory(new Weapon(0, 2200, Item.ItemRarity.Mythical, 44, "S+", "S+", "S+", 1, "Sword"));
			player.AddToInventory(new Item(0, 100, Item.ItemRarity.Common, "Stick"), 3);
			player.AddToInventory(new Weapon(0, 2200, Item.ItemRarity.Mythical, 44, "S+", "S+", "S+", 1, "Sword"));
			player.TakeDamage(5, HealthBar, HPText);
			UpdateManaBar(ManaBar, MPText, player);
			UpdatePlayerStatBox(PlayerStats, player);
			StartDialogue();
		}

		#region UPDATE_FUNCTIONS

		/// <summary>
		/// Updates the Inventory TreeView component.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		internal void MainForm_UpdateInventory(object? sender, UIEventArgs e)
		{
			Inventory.BeginUpdate();

			Inventory.Nodes.Clear();

			if (e.Player.Inventory.Any(x => x.GetType() == typeof(Item)))
			{
				Inventory.Nodes.Add("Items", "Items");
			}

			if (e.Player.Inventory.Any(x => x.GetType() == typeof(Weapon)))
			{
				Inventory.Nodes.Add("Weapons", "Weapons");
			}

			//if (Inventory.Any(x => x.GetType() == typeof(Equipment)))

			foreach (Item i in e.Player.Inventory)
			{
				if (i is Weapon weapon)
				{
					Inventory.Nodes[Inventory.Nodes.IndexOfKey("Weapons")].Nodes.Add(new TreeNode(weapon.Name, new TreeNode[] {
						new TreeNode("Amount: " + weapon.Amount.ToString()),
						new TreeNode("Value: " + weapon.Value.ToString()),
						new TreeNode("Base damage: " + weapon.WeaponDamage.ToString()),
						new TreeNode("STR Scaling: " + weapon.STRScaling.Grade),
						new TreeNode("DEX Scaling: " + weapon.DEXScaling.Grade),
						new TreeNode("INT Scaling: " + weapon.INTScaling.Grade),
						new TreeNode("Enchantability: " + weapon.Enchantability.ToString())
					}));
				}
				else
				{
					Inventory.Nodes[Inventory.Nodes.IndexOfKey("Items")].Nodes.Add(new TreeNode(i.Name, new TreeNode[] {
						new TreeNode("Amount: " + i.Amount.ToString()),
						new TreeNode("Value: " + i.Value.ToString())
					}));
				}
			}

			Inventory.EndUpdate();
		}

		/// <summary>
		/// Updates the Health ProgressBar Component.
		/// </summary>
		/// <param name="hpBar">The ProgressBar Component.</param>
		/// <param name="player">Player Object.</param>
		internal static void UpdateHealthBar(ProgressBar hpBar, GroupBox hpText, Player player)
		{
			double length = Math.Sqrt(Math.Pow(1 - player.Health / player.MaxHealth, 2) + Math.Pow(player.Health / player.MaxHealth, 2));

			hpBar.Value = (int)(player.Health / player.MaxHealth * 100);
			hpBar.ForeColor = Color.FromArgb((int)((1 - player.Health / player.MaxHealth) / length * 255f), (int)(player.Health / player.MaxHealth / length * 255f), 0);
			hpBar.Invalidate();
			hpText.Text = "HP: " + player.Health.ToString() + "/" + player.MaxHealth.ToString();
			hpText.ForeColor = Color.FromArgb((int)((1 - player.Health / player.MaxHealth) / length * 255f), (int)(player.Health / player.MaxHealth / length * 255f), 0);
			hpText.Invalidate();
		}

		/// <summary>
		/// Updates the Mana ProgressBar Component.
		/// </summary>
		/// <param name="mpBar">The ProgressBar Component.</param>
		/// <param name="player">Player Object.</param>
		internal static void UpdateManaBar(ProgressBar mpBar, GroupBox mpText, Player player)
		{
			double length = Math.Sqrt(Math.Pow((int)(1 - (player.Mana / player.MaxMana)), 2) + Math.Pow((int)(player.Mana / player.MaxMana), 2));

			mpBar.Value = (int)(player.Mana / player.MaxMana * 100);
			mpBar.ForeColor = Color.FromArgb((int)((1 - player.Mana / player.MaxMana) / length * 255f), 0, (int)(player.Mana / player.MaxMana / length * 255f));
			mpBar.Invalidate();
			mpText.Text = "MP: " + player.Mana.ToString() + "/" + player.MaxMana.ToString();
			mpText.ForeColor = Color.FromArgb((int)((1 - player.Mana / player.MaxMana) / length * 255f), (int)(player.Mana / player.MaxMana / length * 255f), 0);
			mpText.Invalidate();
		}

		/// <summary>
		/// Updates the statbox displaying player stats.
		/// </summary>
		/// <param name="box">The textbox displaying the stats.</param>
		/// <param name="player">The Player Object.</param>
		internal static void UpdatePlayerStatBox(RichTextBox box, Player player)
		{
			box.Text = "ATK: " + player.ATK.ToString()
				+ "\n\nSTR: " + player.STR.ToString("00 ")
				+ "DEX: " + player.DEX.ToString("00 ")
				+ "INT: " + player.INT.ToString("00 ");
		}

		#endregion

		#region GAME_DIALOGUE

		private void StartDialogue()
		{
			PrintScreen("Type 'Enter' to continue.");
			IfElse("Enter",
					new GameEventArgs.ResponseString { True = "Well done.", False = "Try again." },

					new GameEventArgs.ResponseAction { True = HealPlayer, False = StartDialogue }
				);
		}

		private void HealPlayer()
        {
			PrintScreen("Next, type 'Heal' to heal the player.");
			IfElse("Heal",
					new GameEventArgs.ResponseString { True = "Well done.", False = "Try again." },

					new GameEventArgs.ResponseAction { True = SwitchTest, False = HealPlayer },

					() => { GameArgs.Player.Heal(100, HealthBar, HPText); }
					);
		}

		private void SwitchTest()
        {
			PrintScreen("This is a Switch test. \n1. OK \n2. YES \n3. S \nPOG");
			Switch(new string[] { "1", "2", "3", "POG" },

				new GameEventArgs.ResponseString[] {
					new GameEventArgs.ResponseString { True = "OK"},
					new GameEventArgs.ResponseString { True = "YES"},
					new GameEventArgs.ResponseString { True = "SHEEEEEESH"},
					new GameEventArgs.ResponseString { True = "POGGERS"}
				},

				new GameEventArgs.ResponseAction[] {
					new GameEventArgs.ResponseAction { True = Complete, False = SwitchTest },
					new GameEventArgs.ResponseAction { True = Complete, False = SwitchTest },
					new GameEventArgs.ResponseAction { True = Complete, False = SwitchTest },
					new GameEventArgs.ResponseAction { True = Complete, False = SwitchTest }
				});
        }

		private void Complete()
        {
			PrintScreen("YOU MADE IT! Type 'Switch' to return to the switch.");
			IfElse("Switch",
				new GameEventArgs.ResponseString { True = "Returning to Switch.", False = "Aight." },

				new GameEventArgs.ResponseAction { True = SwitchTest, False = Complete }
				);
        }

		#endregion

		#region EVENT_FRAMEWORK

		/// <summary>
		/// Clears the whole screen and writes the message.
		/// </summary>
		/// <param name="message"> The message to write. </param>
		private void PrintScreen(string message)
		{
			GameArgs.Responses.Enqueue(new GameEventArgs.ResponseString { True = message });
			GameEvent += MainForm_PrintScreen;
			OnGameEvent(GameArgs);
			GameEvent -= MainForm_PrintScreen;

		}

		/// <summary>
		/// This is the event that writes the text to the screen from PrintScreen.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_PrintScreen(object? sender, GameEventArgs e)
		{
			GameOutputBox.Text = e.Responses.Dequeue().True;
		}

		/// <summary>
		/// Writes the message to the end of the current text on the screen.
		/// </summary>
		/// <param name="message"> The text to write on the screen. </param>
		private void PrintLine(string message)
		{
			GameArgs.Responses.Enqueue(new GameEventArgs.ResponseString { True = message });
			GameEvent += MainForm_PrintLine;
			OnGameEvent(GameArgs);
			GameEvent -= MainForm_PrintLine;
		}

		/// <summary>
		/// This is the event that writes the text to the screen from PrintLine.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_PrintLine(object? sender, GameEventArgs e)
		{
			GameOutputBox.AppendText(e.Responses.Dequeue().True);
		}

		/// <summary>
		/// This function serves as an If Else function that handles player input.
		/// </summary>
		/// <param name="comparison"> The string to compare against. </param>
		/// <param name="responseString"> The messages to the player for True and False cases. </param>
		/// <param name="responseAction"> Functions to execute on True and False. </param>
		/// <param name="executeOnVerify"> Function to execute immediately after verification. </param>
		private void IfElse(string comparison, GameEventArgs.ResponseString responseString, GameEventArgs.ResponseAction responseAction, Action? executeOnVerify = null)
		{
			GameArgs.ComparisonStrings.Enqueue(comparison.ToUpper());
			GameArgs.Responses.Enqueue(responseString);
			GameArgs.ResponseCallbacks?.Enqueue(responseAction);
			GameArgs.ExecuteOnVerify = executeOnVerify;
			GameEvent += MainForm_IfElse;
		}

		/// <summary>
		/// This is the event that handles the If Else statement.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_IfElse(object? sender, GameEventArgs e)
		{
			if (e.ComparisonStrings.Dequeue() == e.InputString.ToUpper())
			{
				e.ExecuteOnVerify?.Invoke();
				GameOutputBox.Text = e.Responses.Dequeue().True;
				GameArgs.NextFunc = e.ResponseCallbacks?.Dequeue().True;
				GameEvent -= MainForm_IfElse;
				GameEvent += MainForm_Await;
			}
			else
			{
				GameOutputBox.Text = e.Responses.Dequeue().False;
				GameArgs.NextFunc = e.ResponseCallbacks?.Dequeue().False;
				GameEvent -= MainForm_IfElse;
				GameEvent += MainForm_Await;
			}
		}

		/// <summary>
		/// This function serves as a Switch function that handles player input.
		/// </summary>
		/// <param name="comparisons"> The options of the Switch. </param>
		/// <param name="responseStrings"> The responses to the different cases. </param>
		/// <param name="responseActions"> Functions to execute on different cases. </param>
		/// <param name="executeOnVerify"> Function to execute immediately after verification. </param>
		private void Switch(string[] comparisons, GameEventArgs.ResponseString[] responseStrings, GameEventArgs.ResponseAction[] responseActions, Action? executeOnVerify = null)
        {
			GameArgs.ComparisonStrings = new Queue<string>(comparisons);
			GameArgs.Responses = new Queue<GameEventArgs.ResponseString>(responseStrings);
			GameArgs.ResponseCallbacks = new Queue<GameEventArgs.ResponseAction>(responseActions);
			GameArgs.ExecuteOnVerify = executeOnVerify;
            GameEvent += MainForm_Switch;
        }

		/// <summary>
		/// This is the event that handles the Switch statement.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void MainForm_Switch(object? sender, GameEventArgs e)
        {
			GameEvent -= MainForm_Switch;

			Action? def = e.ResponseCallbacks?.Peek().False;

            for (int i = 0, n = e.ComparisonStrings.Count; i < n; i++)
            {
				if (e.ComparisonStrings.Dequeue() == e.InputString)
                {
					string? response = e.Responses.Dequeue().True;
					if (response != null)
                    {
						e.ExecuteOnVerify?.Invoke();
						GameOutputBox.Text = response;
						GameArgs.NextFunc = e.ResponseCallbacks?.Dequeue().True;

						GameArgs.ComparisonStrings.Clear();
						GameArgs.Responses.Clear();
						GameArgs.ResponseCallbacks?.Clear();

						GameEvent += MainForm_Await;
						return;
					}
					else
                    {
						GameArgs.ComparisonStrings.Clear();
						GameArgs.Responses.Clear();
						GameArgs.ResponseCallbacks?.Clear();

						e.ResponseCallbacks?.Dequeue().True?.Invoke();
                    }
				}
				else
                {
					e.Responses.Dequeue();
					e.ResponseCallbacks?.Dequeue();
                }
            }
			def?.Invoke();
        }

		/// <summary>
		/// This is a small event to require the player to input nothing once.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void MainForm_Await(object? sender, GameEventArgs e)
		{
			GameEvent -= MainForm_Await;
            e.NextFunc?.Invoke();
        }

        #endregion
    }

	internal class UIEventArgs : EventArgs
    {
		/// <summary>The player data passed to this Event.</summary>
		public Player Player { get; set; } = new();
		public UpdatedElements Elements { get; set; }

        [Flags]
		public enum UpdatedElements
        {
			none = 0,
			HealthBar = 1 << 0,
			ManaBar = 1 << 1,
			Inventory = 1 << 2,
			StatBox = 1 << 3
        }
	}

    internal class GameEventArgs : EventArgs
	{
		/// <summary>The player data passed to this Event.</summary>
		public Player Player { get; set; } = new();

		/// <summary>The input data passed to this Event.</summary>
		public string InputString { get; set; } = string.Empty;

		public Action? NextFunc { get; set; }

		/// <summary>The string data to use in response to this Event.</summary>
		public Queue<ResponseString> Responses { get; set; } = new();

		/// <summary>The String to compare in this Event.</summary>
		public Queue<string> ComparisonStrings { get; set; } = new();

		public Action? ExecuteOnVerify { get; set; }

		public Queue<ResponseAction>? ResponseCallbacks { get; set; } = new();

		public struct ResponseString
		{
			public string? True { get; set; }
			public string? False { get; set; }
		}

		public struct ResponseAction
		{
			public Action? True { get; set; }

			public Action? False { get; set; }
		}
	}
}