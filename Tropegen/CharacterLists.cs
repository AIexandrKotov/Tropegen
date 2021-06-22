using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tropegenbase.Data;

namespace Tropegen
{
    public partial class CharacterLists : Form
    {
        public CharacterEditor Reference;
        public CharacterLists(CharacterEditor extended)
        {
            InitializeComponent();
            Reference = extended;
            ListOfList.Items.AddRange(Reference.SavedFiles.Select(x => x.Name).ToArray());
            ListOfList.Text = Reference.CurrentFile;
            NewTextBox.Text = ListOfList.Text;
            NewButton.Enabled = false;
            RenameButton.Enabled = false;
            RemoveButton.Enabled = ListOfList.Items.Count > 1;
            Text = Lang.Get("CharacterLists");
            DescriptionTextBox.Text = Lang.Get("CLDesc");
            RemoveButton.Text = Lang.Get("Remove");
            RenameButton.Text = Lang.Get("Rename");
            NewButton.Text = Lang.Get("New");
        }

        private void NewTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ListOfList.Items.Contains(NewTextBox.Text))
            {
                NewButton.Enabled = false;
                RenameButton.Enabled = false;
            }
            else
            {
                NewButton.Enabled = true;
                RenameButton.Enabled = true;
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Reference.SavedFiles.Add(CharacterFile.New(NewTextBox.Text));
            ListOfList.Text = Reference.SavedFiles[Reference.SavedFiles.Count - 1].Name;
            Reference.SavedFiles.Find(x => Reference.CurrentFile == x.Name).Save();
            var ind = Reference.SavedFiles.FindIndex(x => x.Name == ListOfList.Text);
            Reference.CurrentSavedCharacters = Reference.SavedFiles[ind].CharacterList;
            Reference.CurrentFile = Reference.SavedFiles[ind].Name;
            UpdateListOfList();
            if (ListOfList.Items.Count > 1) RemoveButton.Enabled = true;
            ListOfList.Text = NewTextBox.Text;
            NewButton.Enabled = false;
        }

        private bool indelete;

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var ind = Reference.SavedFiles.FindIndex(x => x.Name == ListOfList.Text);
            var name = Reference.SavedFiles[ind].Name;
            indelete = true;
            if (name == ListOfList.Text) ListOfList.Text = (string)ListOfList.Items[ListOfList.Items.Count - 1];
            Reference.SavedFiles[ind].Remove();
            Reference.SavedFiles.RemoveAt(ind);
            UpdateListOfList();
            if (ListOfList.Items.Count > 1) RemoveButton.Enabled = true;
            else RemoveButton.Enabled = false;
            ListOfList.SelectedIndex = ind > 0 ? ind - 1 : 0;
        }

        void UpdateListOfList()
        {
            ListOfList.Items.Clear();
            ListOfList.Items.AddRange(Reference.SavedFiles.Select(x => x.Name).ToArray());
        }

        private void ListOfList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!indelete)
            Reference.SavedFiles.Find(x => Reference.CurrentFile == x.Name).Save();
            else indelete = false;
            var ind = Reference.SavedFiles.FindIndex(x => x.Name == ListOfList.Text);
            Reference.CurrentSavedCharacters = Reference.SavedFiles[ind].CharacterList;
            Reference.CurrentFile = Reference.SavedFiles[ind].Name;
            NewTextBox.Text = Reference.CurrentFile;
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            var ind = Reference.SavedFiles.FindIndex(x => x.Name == ListOfList.Text);
            ListOfList.Items.Remove(ListOfList.Text);
            Reference.SavedFiles[ind].Rename(NewTextBox.Text);
            Reference.CurrentFile = NewTextBox.Text;
            UpdateListOfList();
            ListOfList.Text = NewTextBox.Text;
            RenameButton.Enabled = false;
        }
    }
}
