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
        }

        private uint last_id;
        private Random seeder = new Random(24);

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
    }
}
