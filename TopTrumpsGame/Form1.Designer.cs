namespace TopTrumpsGame
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playersComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characteristicComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.battleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(673, 425);
            this.dataGridView1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playersComboBox,
            this.registerToolStripMenuItem,
            this.characteristicComboBox,
            this.battleToolStripMenuItem,
            this.buyCardToolStripMenuItem,
            this.nextCardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(673, 27);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playersComboBox
            // 
            this.playersComboBox.Name = "playersComboBox";
            this.playersComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // characteristicComboBox
            // 
            this.characteristicComboBox.Name = "characteristicComboBox";
            this.characteristicComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // battleToolStripMenuItem
            // 
            this.battleToolStripMenuItem.Name = "battleToolStripMenuItem";
            this.battleToolStripMenuItem.Size = new System.Drawing.Size(49, 23);
            this.battleToolStripMenuItem.Text = "Battle";
            this.battleToolStripMenuItem.Click += new System.EventHandler(this.battleToolStripMenuItem_Click);
            // 
            // buyCardToolStripMenuItem
            // 
            this.buyCardToolStripMenuItem.Name = "buyCardToolStripMenuItem";
            this.buyCardToolStripMenuItem.Size = new System.Drawing.Size(67, 23);
            this.buyCardToolStripMenuItem.Text = "Buy Card";
            this.buyCardToolStripMenuItem.Click += new System.EventHandler(this.buyCardToolStripMenuItem_Click);
            // 
            // nextCardToolStripMenuItem
            // 
            this.nextCardToolStripMenuItem.Name = "nextCardToolStripMenuItem";
            this.nextCardToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.nextCardToolStripMenuItem.Text = "Next Card";
            this.nextCardToolStripMenuItem.Click += new System.EventHandler(this.nextCardToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 452);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Top Trumps Game";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buyCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem battleToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox characteristicComboBox;
        private System.Windows.Forms.ToolStripComboBox playersComboBox;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextCardToolStripMenuItem;
    }
}

