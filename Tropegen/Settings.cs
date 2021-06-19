using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tropegenbase;
using Tropegenbase.Characters;
using Tropegenbase.Data;

namespace Tropegen
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            LangGB.Text = Lang.Current["WF_STG_LangGB"];
            RandomationLawsGB.Text = Lang.Current["WF_STG_RLGB"];
            labelNamesCount.Text = Lang.Current["WF_STG_Names"];
            labelSurnamesCount.Text = Lang.Current["WF_STG_Surnames"];
            DefaultButton.Text = Lang.Current["WF_STG_DefaultB"];

            CB_AgeTypeLaw.Items.AddRange(CachedEnum<Defaults.AgeTypeLaw>.Names);
            CB_MoralityLaw.Items.AddRange(CachedEnum<Defaults.MoralityLaw>.Names);
            CB_ProtestLaw.Items.AddRange(CachedEnum<Defaults.ProtestLaw>.Names);
            CB_PoliticalLaw.Items.AddRange(CachedEnum<Defaults.PoliticalLaw>.Names);
            CB_PhysicalPowerLaw.Items.AddRange(CachedEnum<Defaults.PhysicalPowerLaw>.Names);
            CB_MagicPowerLaw.Items.AddRange(CachedEnum<Defaults.MagicPowerLaw>.Names);
            CB_WillPowerLaw.Items.AddRange(CachedEnum<Defaults.WillPowerLaw>.Names);
            CB_StaminaLaw.Items.AddRange(CachedEnum<Defaults.StaminaLaw>.Names);
            CB_IntellectLaw.Items.AddRange(CachedEnum<Defaults.IntellectLaw>.Names);
            LoadAll();
            Text = Lang.Current["Settings"];
            HelpInfoLabel.Text = Lang.Current["WF_STG_Loaded"];
        }

        public void LoadAll()
        {
            CB_AgeTypeLaw.Text = Defaults.CurrentAgeTypeRandomLaw.ToString();
            CB_MoralityLaw.Text = Defaults.CurrentMoralityRandomLaw.ToString();
            CB_ProtestLaw.Text = Defaults.CurrentProtestRandomLaw.ToString();
            CB_PoliticalLaw.Text = Defaults.CurrentPoliticalRandomLaw.ToString();
            CB_PhysicalPowerLaw.Text = Defaults.CurrentPhysicalPowerRandomLaw.ToString();
            CB_MagicPowerLaw.Text = Defaults.CurrentMagicPowerRandomLaw.ToString();
            CB_WillPowerLaw.Text = Defaults.CurrentWillPowerRandomLaw.ToString();
            CB_StaminaLaw.Text = Defaults.CurrentStaminaRandomLaw.ToString();
            CB_IntellectLaw.Text = Defaults.CurrentIntellectRandomLaw.ToString();
            TB_NamesCount.Text = Lang.PopularSettingNames.ToString();
            TB_SurnamesCount.Text = Lang.PopularSettingSurnames.ToString();
        }

        public void Save()
        {

        }
        
        public void Default()
        {
            Defaults.CurrentAgeTypeRandomLaw = Defaults.AgeTypeLaw.Normal;
            Defaults.CurrentMoralityRandomLaw = 0;
            Defaults.CurrentProtestRandomLaw = 0;
            Defaults.CurrentPoliticalRandomLaw = 0;
            Defaults.CurrentPhysicalPowerRandomLaw = 0;
            Defaults.CurrentMagicPowerRandomLaw = 0;
            Defaults.CurrentWillPowerRandomLaw = 0;
            Defaults.CurrentIntellectRandomLaw = 0;
            Lang.PopularSettingNames = Lang.DefaultPopularSettingNames;
            Lang.PopularSettingSurnames = Lang.DefaultPopularSettingSurnames;
            LoadAll();
            HelpInfoLabel.Text = Lang.Current["WF_STG_Defaulted"];
        }

        private void TB_NamesCount_TextChanged(object sender, EventArgs e)
        {
            HelpInfoLabel.Text = Lang.Current["HelpInfo_NamesCount"];
            if (int.TryParse(TB_NamesCount.Text, out var res) && res <= Lang.MaxNames)
            {
                TB_NamesCount.ForeColor = Color.Black;
                Lang.PopularSettingNames = res;
            }
            else
            {
                TB_NamesCount.ForeColor = Color.Red;
            }
        }

        private void TB_SurnamesCount_TextChanged(object sender, EventArgs e)
        {
            HelpInfoLabel.Text = Lang.Current["HelpInfo_SurnamesCount"];
            if (int.TryParse(TB_SurnamesCount.Text, out var res) && res <= Lang.MaxSurnames)
            {
                TB_SurnamesCount.ForeColor = Color.Black;
                Lang.PopularSettingSurnames = res;
            }
            else
            {
                TB_SurnamesCount.ForeColor = Color.Red;
            }
        }

        private void CB_AgeTypeLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentAgeTypeRandomLaw = CB_AgeTypeLaw.Text.ToEnum<Defaults.AgeTypeLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.AgeTypeLaw>.Type.Name}.{Defaults.CurrentAgeTypeRandomLaw}"];
        }

        private void CB_MoralityLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentMoralityRandomLaw = CB_MoralityLaw.Text.ToEnum<Defaults.MoralityLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.MoralityLaw>.Type.Name}.{Defaults.CurrentMoralityRandomLaw}"];
        }

        private void CB_ProtestLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentProtestRandomLaw = CB_ProtestLaw.Text.ToEnum<Defaults.ProtestLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.ProtestLaw>.Type.Name}.{Defaults.CurrentProtestRandomLaw}"];
        }

        private void CB_PoliticalLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentPoliticalRandomLaw = CB_PoliticalLaw.Text.ToEnum<Defaults.PoliticalLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.PoliticalLaw>.Type.Name}.{Defaults.CurrentPoliticalRandomLaw}"];
        }

        private void CB_PhysicalPowerLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentPhysicalPowerRandomLaw = CB_PhysicalPowerLaw.Text.ToEnum<Defaults.PhysicalPowerLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.PhysicalPowerLaw>.Type.Name}.{Defaults.CurrentPhysicalPowerRandomLaw}"];
        }

        private void CB_MagicPowerLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentMagicPowerRandomLaw = CB_MagicPowerLaw.Text.ToEnum<Defaults.MagicPowerLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.MagicPowerLaw>.Type.Name}.{Defaults.CurrentMagicPowerRandomLaw}"];
        }

        private void CB_WillPowerLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentWillPowerRandomLaw = CB_WillPowerLaw.Text.ToEnum<Defaults.WillPowerLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.WillPowerLaw>.Type.Name}.{Defaults.CurrentWillPowerRandomLaw}"];
        }

        private void CB_StaminaLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentStaminaRandomLaw = CB_StaminaLaw.Text.ToEnum<Defaults.StaminaLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.StaminaLaw>.Type.Name}.{Defaults.CurrentStaminaRandomLaw}"];
        }

        private void CB_IntellectLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defaults.CurrentIntellectRandomLaw = CB_IntellectLaw.Text.ToEnum<Defaults.IntellectLaw>();
            HelpInfoLabel.Text = Lang.Current[$"HelpInfo_{CachedEnum<Defaults.IntellectLaw>.Type.Name}.{Defaults.CurrentIntellectRandomLaw}"];
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            Default();
        }
    }
}
