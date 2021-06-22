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
    public partial class ChangeFiveChanges : Form
    {
        Archetypes.Changes[] Current;
        CharacterEditor Reference;
        TextBox TBRef;

        public event Action OnUpdate;

        public ChangeFiveChanges(CharacterEditor reference, TextBox tbref, string title, Archetypes.Changes[] changes)
        {
            InitializeComponent();
            Reference = reference;
            TBRef = tbref;
            Text = title;
            comboBox1.Items.AddRange(CachedEnum<Archetypes.Changes>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            comboBox2.Items.AddRange(CachedEnum<Archetypes.Changes>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            comboBox3.Items.AddRange(CachedEnum<Archetypes.Changes>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            comboBox4.Items.AddRange(CachedEnum<Archetypes.Changes>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            comboBox5.Items.AddRange(CachedEnum<Archetypes.Changes>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            Current = changes;
            comboBox1.Text = changes[0].Lang();
            comboBox2.Text = changes[1].Lang();
            comboBox3.Text = changes[2].Lang();
            comboBox4.Text = changes[3].Lang();
            comboBox5.Text = changes[4].Lang();
            CFCHelp.Text = Lang.Get("CFCHelp");
        }

        private void UpdateTextBox()
        {
            TBRef.Text = Character.InfoChanges(Current, 5);
            OnUpdate?.Invoke();
        }

        private void ChangeFiveChanges_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Current[0] = (Archetypes.Changes)comboBox1.SelectedIndex;
            UpdateTextBox();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Current[1] = (Archetypes.Changes)comboBox2.SelectedIndex;
            UpdateTextBox();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Current[2] = (Archetypes.Changes)comboBox3.SelectedIndex;
            UpdateTextBox();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Current[3] = (Archetypes.Changes)comboBox4.SelectedIndex;
            UpdateTextBox();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Current[4] = (Archetypes.Changes)comboBox5.SelectedIndex;
            UpdateTextBox();
        }
    }
}
