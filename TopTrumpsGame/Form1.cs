using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace TopTrumpsGame
{
    public partial class Form1 : Form
    {
        TopTrumpsGame topTrumpsGame;
        BindingList<TopTrumpsPlayer> players;
        TopTrumpsPlayer player;
        public Form1()
        {
            this.topTrumpsGame = new TopTrumpsGame();
            this.players = new BindingList<TopTrumpsPlayer>();
            this.players.ListChanged += Players_ListChanged;

            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.playersComboBox.SelectedIndexChanged += PlayersComboBox_SelectedIndexChanged;
            Array characteristicValues = Enum.GetValues(typeof(Characteristic));
            foreach(Characteristic c in characteristicValues) {
                this.characteristicComboBox.Items.Add(c);
            }
            this.characteristicComboBox.SelectedIndex = 0;
        }

        private void PlayersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.player = this.players[this.playersComboBox.SelectedIndex];
            this.bindingSource1.DataSource = this.player.cards;
            this.dataGridView1.DataSource = bindingSource1;
        }

        private void Players_ListChanged(object sender, ListChangedEventArgs e)
        {
            this.playersComboBox.Items.Clear();
            foreach(TopTrumpsPlayer player in this.players)
            {
                this.playersComboBox.Items.Add(player);
            }
        }

        bool IsError(ITopTrumpsResponse response)
        {
            ErrorResponse error = response as ErrorResponse;
            if (error != null)
            {
                MessageBox.Show(error.message, String.Format("Error {0}", error.errorCode));
                return true;
            }
            return false;
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "player" + new Random().Next(1023);
            TopTrumpsPlayer player = new TopTrumpsPlayer(name, name + "@gmail.com", "1999-02-13");
            ITopTrumpsResponse response = this.topTrumpsGame.RegisterPlayer(ref player);
            if (IsError(response))
                return;
            this.players.Add(player);
            this.playersComboBox.SelectedItem = player;
            
        }

        private void battleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.player == null)
                return;
            ITopTrumpsResponse response = this.topTrumpsGame.Battle(this.player, (Characteristic)this.characteristicComboBox.SelectedItem);
            if (IsError(response))
                return;
            BattleResponse battleResponse = response as BattleResponse;
            if (battleResponse != null)
            {
                //MessageBox.Show(String.Format("{0} vs. {1}", battleResponse.card.name, battleResponse.opponentCard.name), battleResponse.outcome);
                this.topTrumpsGame.ListCards(ref this.player);
            }
        }

        private void buyCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.player == null)
                return;
            ITopTrumpsResponse response = this.topTrumpsGame.BuyCard(ref this.player);
            if (IsError(response))
                return;
            Card card = response as Card;
            if (card != null)
                //MessageBox.Show(String.Format("Strength: {0}\nSkill: {1}\nSize: {2}\nPopularity: {3}", card.strength, card.skill, card.size, card.popularity), card.name);
                this.topTrumpsGame.ListCards(ref this.player);
        }

        private void nextCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.player == null)
                return;
            ITopTrumpsResponse response = this.topTrumpsGame.GetNextCard(this.player);
            if (IsError(response))
                return;
            Card card = response as Card;
            if (card != null)
            {
                MessageBox.Show(String.Format("Strength: {0}\nSkill: {1}\nSize: {2}\nPopularity: {3}", card.strength, card.skill, card.size, card.popularity), card.name);
            }
        }
    }
   
}
