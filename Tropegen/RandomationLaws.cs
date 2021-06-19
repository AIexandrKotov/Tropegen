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
using Tropegenbase.Data;

namespace Tropegen
{
    public partial class RandomationLaws : Form
    {
        static Type td = typeof(Defaults);

        public RandomationLaws()
        {
            InitializeComponent();
            LawsList.Items.AddRange(RandomationLawHelper.Types.Select(x => x.Lang()).ToArray());
            Text = Lang.Get("RandomationLaws");
            DefaultButton.Text = Lang.Get("Default");
            HelpInfoBox.Text = Lang.Get("WF_STG_Loaded");
            NameLabel.Text = Lang.Get("WF_STG_Names");
            SurnameLabel.Text = Lang.Get("WF_STG_Surnames");
            NameValue.Maximum = Lang.MaxNames;
            SurnameValue.Maximum = Lang.MaxSurnames;
            NameValue.Value = Lang.PopularSettingNames;
            SurnameValue.Value = Lang.PopularSettingSurnames;
            UpdateDesc();
        }

        private void UpdateDesc()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < RandomationLawHelper.Types.Length; i++)
            {
                var x = RandomationLawHelper.Types[i];
                var prop = td.GetProperty($"Current{x.Name}RandomLaw");
                sb.AppendLine($"{x.Lang(), -20} │ {prop.GetValue(null).ToString().Lang()} / ({Enum.GetNames(prop.PropertyType).Select(y => y.Lang()).JoinIntoString(", ")})");
            }
            AllLawsDesc.Text = sb.ToString();
        }

        private void UpdateHelp()
        {
            if (LawsList.SelectedIndex == -1) return;
            var prop = typeof(Defaults).GetProperty($"Current{RandomationLawHelper.Types[LawsList.SelectedIndex].Name}RandomLaw");
            HelpInfoBox.Text = Lang.Get($"HelpInfo_{prop.PropertyType.Name}.{prop.GetValue(null)}");
        }

        private void RandomationLaws_Load(object sender, EventArgs e)
        {
        }

        private void LawsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LawsList.SelectedIndex == -1) return;
            var prop = typeof(Defaults).GetProperty($"Current{RandomationLawHelper.Types[LawsList.SelectedIndex].Name}RandomLaw");
            CurrentLaw.Items.Clear();
            CurrentLaw.Items.AddRange(Enum.GetNames(prop.PropertyType));
            CurrentLaw.Text = prop.GetValue(null).ToString();
        }

        private void CurrentLaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            var prop = typeof(Defaults).GetProperty($"Current{RandomationLawHelper.Types[LawsList.SelectedIndex].Name}RandomLaw");
            prop.SetValue(null, Enum.Parse(prop.PropertyType, CurrentLaw.Text));
            UpdateDesc();
            UpdateHelp();
        }

        private void LawsList_Leave(object sender, EventArgs e)
        {
            LawsList.Update();
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < RandomationLawHelper.Types.Length; i++)
            {
                var x = RandomationLawHelper.Types[i];
                td.GetProperty($"Current{x.Name}RandomLaw").SetValue(null, td.GetField($"Default{x.Name}RandomLaw").GetValue(null));
            }
            UpdateDesc();
            if (LawsList.SelectedIndex != -1)
            {
                var prop = typeof(Defaults).GetProperty($"Current{RandomationLawHelper.Types[LawsList.SelectedIndex].Name}RandomLaw");
                CurrentLaw.Text = prop.GetValue(null).ToString();
            }
            UpdateHelp();
            Lang.PopularSettingNames = Lang.DefaultPopularSettingNames;
            Lang.PopularSettingSurnames = Lang.DefaultPopularSettingSurnames;
            NameValue.Value = Lang.PopularSettingNames;
            SurnameValue.Value = Lang.PopularSettingSurnames;
        }

        private void NameValue_ValueChanged(object sender, EventArgs e)
        {
            if (Lang.PopularSettingNames != NameValue.Value)
            {
                Lang.PopularSettingNames = (int)NameValue.Value;
            }
            HelpInfoBox.Text = Lang.Current["HelpInfo_NamesCount"];
        }

        private void SurnameValue_ValueChanged(object sender, EventArgs e)
        {
            if (Lang.PopularSettingSurnames != SurnameValue.Value)
            {
                Lang.PopularSettingSurnames = (int)SurnameValue.Value;
            }
            HelpInfoBox.Text = Lang.Current["HelpInfo_SurnamesCount"];
        }
    }
}
