namespace DungeonCrawler
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GameOutputBox = new System.Windows.Forms.RichTextBox();
            this.GameInputBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Inventory = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Equipment = new System.Windows.Forms.TreeView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.PlayerStats = new System.Windows.Forms.RichTextBox();
            this.HPText = new System.Windows.Forms.GroupBox();
            this.HealthBar = new System.Windows.Forms.ProgressBar();
            this.MPText = new System.Windows.Forms.GroupBox();
            this.ManaBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.HPText.SuspendLayout();
            this.MPText.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GameOutputBox);
            this.groupBox1.Location = new System.Drawing.Point(17, 308);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1109, 250);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Output";
            // 
            // GameOutputBox
            // 
            this.GameOutputBox.BackColor = System.Drawing.Color.Black;
            this.GameOutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GameOutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameOutputBox.ForeColor = System.Drawing.SystemColors.Control;
            this.GameOutputBox.Location = new System.Drawing.Point(4, 27);
            this.GameOutputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameOutputBox.Name = "GameOutputBox";
            this.GameOutputBox.ReadOnly = true;
            this.GameOutputBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.GameOutputBox.Size = new System.Drawing.Size(1101, 218);
            this.GameOutputBox.TabIndex = 0;
            this.GameOutputBox.Text = "";
            // 
            // GameInputBox
            // 
            this.GameInputBox.BackColor = System.Drawing.Color.Black;
            this.GameInputBox.ForeColor = System.Drawing.SystemColors.Control;
            this.GameInputBox.Location = new System.Drawing.Point(9, 32);
            this.GameInputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameInputBox.Name = "GameInputBox";
            this.GameInputBox.Size = new System.Drawing.Size(1090, 29);
            this.GameInputBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GameInputBox);
            this.groupBox2.Location = new System.Drawing.Point(17, 566);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1109, 76);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // Inventory
            // 
            this.Inventory.BackColor = System.Drawing.Color.Black;
            this.Inventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Inventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inventory.ForeColor = System.Drawing.SystemColors.Control;
            this.Inventory.Location = new System.Drawing.Point(4, 27);
            this.Inventory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(412, 249);
            this.Inventory.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Inventory);
            this.groupBox3.Location = new System.Drawing.Point(17, 17);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(420, 281);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inventory";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Equipment);
            this.groupBox4.Location = new System.Drawing.Point(446, 17);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(411, 281);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Equipment";
            // 
            // Equipment
            // 
            this.Equipment.BackColor = System.Drawing.Color.Black;
            this.Equipment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Equipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Equipment.ForeColor = System.Drawing.SystemColors.Control;
            this.Equipment.Location = new System.Drawing.Point(4, 27);
            this.Equipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Equipment.Name = "Equipment";
            this.Equipment.Size = new System.Drawing.Size(403, 249);
            this.Equipment.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.PlayerStats);
            this.groupBox5.Controls.Add(this.HPText);
            this.groupBox5.Controls.Add(this.MPText);
            this.groupBox5.Location = new System.Drawing.Point(866, 17);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(260, 281);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Player Stats";
            // 
            // PlayerStats
            // 
            this.PlayerStats.BackColor = System.Drawing.Color.Black;
            this.PlayerStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayerStats.ForeColor = System.Drawing.SystemColors.Control;
            this.PlayerStats.Location = new System.Drawing.Point(9, 204);
            this.PlayerStats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PlayerStats.Name = "PlayerStats";
            this.PlayerStats.Size = new System.Drawing.Size(243, 67);
            this.PlayerStats.TabIndex = 5;
            this.PlayerStats.Text = "";
            // 
            // HPText
            // 
            this.HPText.Controls.Add(this.HealthBar);
            this.HPText.Location = new System.Drawing.Point(9, 32);
            this.HPText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HPText.Name = "HPText";
            this.HPText.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HPText.Size = new System.Drawing.Size(243, 75);
            this.HPText.TabIndex = 4;
            this.HPText.TabStop = false;
            this.HPText.Text = "HP 0/0";
            // 
            // HealthBar
            // 
            this.HealthBar.ForeColor = System.Drawing.Color.Green;
            this.HealthBar.Location = new System.Drawing.Point(9, 32);
            this.HealthBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(226, 32);
            this.HealthBar.Step = 1;
            this.HealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.HealthBar.TabIndex = 2;
            this.HealthBar.Value = 10;
            // 
            // MPText
            // 
            this.MPText.Controls.Add(this.ManaBar);
            this.MPText.Location = new System.Drawing.Point(9, 116);
            this.MPText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MPText.Name = "MPText";
            this.MPText.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MPText.Size = new System.Drawing.Size(243, 79);
            this.MPText.TabIndex = 3;
            this.MPText.TabStop = false;
            this.MPText.Text = "MP 0/0";
            // 
            // ManaBar
            // 
            this.ManaBar.BackColor = System.Drawing.Color.Black;
            this.ManaBar.Location = new System.Drawing.Point(9, 32);
            this.ManaBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ManaBar.Name = "ManaBar";
            this.ManaBar.Size = new System.Drawing.Size(226, 36);
            this.ManaBar.Step = 1;
            this.ManaBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ManaBar.TabIndex = 1;
            this.ManaBar.Value = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1143, 660);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1159, 699);
            this.MinimumSize = new System.Drawing.Size(1159, 699);
            this.Name = "MainForm";
            this.Text = "Dungeon Crawler";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.HPText.ResumeLayout(false);
            this.MPText.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private GroupBox groupBox1;
		private TextBox GameInputBox;
		private GroupBox groupBox2;
		private RichTextBox GameOutputBox;
		private TreeView Inventory;
		private GroupBox groupBox3;
		private GroupBox groupBox4;
		private TreeView Equipment;
		private GroupBox groupBox5;
		private ProgressBar HealthBar;
		private ProgressBar ManaBar;
		private GroupBox HPText;
		private GroupBox MPText;
		private RichTextBox PlayerStats;
	}
}