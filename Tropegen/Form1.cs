using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tropegenbase.Characters;
using Tropegenbase.Data;

namespace Tropegen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            copyrightLabel.Text = "Alexandr Kotov 2021";
            usedLabel.Text = "thanks to mydata.biz";
            versionLabel.Text = Tropegenbase.GlobalAssemblyVersion.VersionInfo;
            RandomButton.Text = Lang.Current["WF_RandomButton"];
            SettingsButton.Text = Lang.Current["Settings"];
            RunExtendedButton.Text = Lang.Current["WF_RunExtended"];
        }

        private uint last_id;
        private Random seeder = new Random(Environment.TickCount);

        private void TB_Seed_TextChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(TB_Seed.Text, out var i))
            {
                TB_Seed.ForeColor = Color.Black;
                if (i != last_id) Update(i);
            }
            else TB_Seed.ForeColor = Color.Red;
        }

        public void Update(uint i)
        {
            last_id = i;
            ChString.Text = new CharacterBuilder((int)i).Init().ToString();
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            TB_Seed.Text = seeder.Next().ToString();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var sets = new Settings();
            sets.ShowDialog();
        }

        private void RunExtendedButton_Click(object sender, EventArgs e)
        {
            var ext = new Extended();
            ext.FormClosed += (o, e2) =>
            {
                Visible = true;
                Enabled = true;
            };
            Enabled = false;
            Visible = false;
            ext.Show();
        }
    }
}
