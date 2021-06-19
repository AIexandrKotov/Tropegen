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
using Tropegenbase;
using Tropegenbase.Characters;
using Tropegenbase.Data;

namespace Tropegen
{
    public partial class Extended : Form
    {
        public static string GetPath() => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Tropegen\\";

        public Random GlobalSeed = new Random(Environment.TickCount);

        public Character CurrentCharacter;

        public List<Character> SavedCharacters = new List<Character>();

        private void Saved_RemoveButton_Click(object sender, EventArgs e)
        {
            if (SavedListBox.SelectedIndex == -1) return;
            var si = SavedListBox.SelectedIndex;
            SavedCharacters.RemoveAt(SavedListBox.SelectedIndex);
            UpdateSavedListBox();
            if (SavedListBox.Items.Count > si) SavedListBox.SelectedIndex = SavedListBox.Items.Count - 1;
            else SavedListBox.SelectedIndex = si;
        }

        private void SavedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SavedListBox.SelectedIndex == -1) return;
            CurrentCharacter = SavedCharacters[SavedListBox.SelectedIndex];
            UpdateCharacter(CurrentCharacter);
        }

        private void Saved_DuplicateButton_Click(object sender, EventArgs e)
        {
            if (SavedListBox.SelectedIndex == -1) return;
            SavedCharacters.Add((Character)CurrentCharacter.Clone());
            UpdateSavedListBox();
            SavedListBox.SelectedIndex = SavedListBox.Items.Count - 1;
        }

        private void UpdateSavedListBox()
        {
            SavedListBox.Items.Clear();
            SavedListBox.Items.AddRange(SavedCharacters.ConvertAll(x => x.Name + " " + x.Surname).ToArray());
        }

        private void UpdateCurrentInListBox()
        {
            if (!CurrentCharacter.Generated && SavedCharacters.Contains(CurrentCharacter)) SavedListBox.Items[SavedCharacters.IndexOf(CurrentCharacter)] = CurrentCharacter.Name + " " + CurrentCharacter.Surname;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!SavedCharacters.Contains(CurrentCharacter)) 
            {
                CurrentCharacter.Generated = false;
                SavedCharacters.Add(CurrentCharacter);
                UpdateSavedListBox();
            }
        }

        private void Extended_Load(object sender, EventArgs e)
        {
        }

        public Extended()
        {
            InitializeComponent();

            FormClosed += (o, e) =>
            {
                var path = GetPath();
                var characters = GetPath() + "characters.dat";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                Character.Save(characters, SavedCharacters);
            };

            GenderComboBox.Items.AddRange(CachedEnum<Archetypes.BiologicalGender>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            MoralityComboBox.Items.AddRange(CachedEnum<Archetypes.Morality>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            EthicalComboBox.Items.AddRange(CachedEnum<Archetypes.Ethical>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            EgoComboBox.Items.AddRange(CachedEnum<Archetypes.Ego>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            IdeaComboBox.Items.AddRange(CachedEnum<Archetypes.Idea>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            ProtestComboBox.Items.AddRange(CachedEnum<Archetypes.Protest>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            PoliticalComboBox.Items.AddRange(CachedEnum<Archetypes.Political>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            EmpathyComboBox.Items.AddRange(CachedEnum<Archetypes.Empathy>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            EmotionalComboBox.Items.AddRange(CachedEnum<Archetypes.Emotional>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            EyesColorComboBox.Items.AddRange(CachedEnum<Archetypes.EyesColor>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            HairColorComboBox.Items.AddRange(CachedEnum<Archetypes.HairColor>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            HairLengthComboBox.Items.AddRange(CachedEnum<Archetypes.HairLength>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            BeautyTypeComboBox.Items.AddRange(CachedEnum<Archetypes.BeautyType>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            ForcesPhysicalComboBox.Items.AddRange(CachedEnum<Archetypes.PhysicalPower>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            ForcesMagicComboBox.Items.AddRange(CachedEnum<Archetypes.MagicPower>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            ForcesWillComboBox.Items.AddRange(CachedEnum<Archetypes.WillPower>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            ForcesStaminaComboBox.Items.AddRange(CachedEnum<Archetypes.Stamina>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            ForcesIntellectComboBox.Items.AddRange(CachedEnum<Archetypes.Intellect>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            SocialStatusComboBox.Items.AddRange(CachedEnum<Archetypes.SocialStatus>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            SexualityComboBox.Items.AddRange(CachedEnum<Archetypes.Sexuality>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            ResponsibilityComboBox.Items.AddRange(CachedEnum<Archetypes.Responsibility>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            LoyaltyComboBox.Items.AddRange(CachedEnum<Archetypes.Loyalty>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            AdaptibilityComboBox.Items.AddRange(CachedEnum<Archetypes.Adaptability>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            TrustinpeopleComboBox.Items.AddRange(CachedEnum<Archetypes.TrustInPeople>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());
            HumorComboBox.Items.AddRange(CachedEnum<Archetypes.Humor>.Enums.Select(x => Lang.Get(x.Lang())).ToArray());

            SavedGroup.Text = Lang.Get("Saved");
            SearchGroup.Text = Lang.Get("Search");
            CharacterGroup.Text = Lang.Get("Character");
            AppearanceGroup.Text = Lang.Get("Appearance");
            PersonalityGroup.Text = Lang.Get("Personality");
            ForcesGroup.Text = Lang.Get("Forces");
            SocialGroup.Text = Lang.Get("Social");
            TitleGroup.Text = Lang.Get("Title");

            SeedLabel.Text = Lang.Get("Seed") + ":";
            RandomButton.Text = Lang.Get("Random");
            SaveButton.Text = Lang.Get("Save");
            NewButton.Text = Lang.Get("New");
            SettingsStripDown.Text = Lang.Get("Settings");

            RandomationLawsButton.Text = Lang.Get("RandomationLaws");

            NameLabel.Text = Lang.Get("Name") + ":";
            SurnameLabel.Text = Lang.Get("Surname") + ":";
            GenderLabel.Text = Lang.Get(CachedEnum<Archetypes.BiologicalGender>.Type.Lang()) + ":";
            BirthDateLabel.Text = Lang.Get("BirthDate") + ":";
            AgeLabel.Text = Lang.Get("Age") + ":";
            GenderLabel.Text = Lang.Get(CachedEnum<Archetypes.BiologicalGender>.Type.Lang()) + ":";
            MoralityLabel.Text = Lang.Get(CachedEnum<Archetypes.Morality>.Type.Lang()) + ":";
            EthicalLabel.Text = Lang.Get(CachedEnum<Archetypes.Ethical>.Type.Lang()) + ":";
            EgoLabel.Text = Lang.Get(CachedEnum<Archetypes.Ego>.Type.Lang()) + ":";
            IdeaLabel.Text = Lang.Get(CachedEnum<Archetypes.Idea>.Type.Lang()) + ":";
            ProtestLabel.Text = Lang.Get(CachedEnum<Archetypes.Protest>.Type.Lang()) + ":";
            PoliticaLabel.Text = Lang.Get(CachedEnum<Archetypes.Political>.Type.Lang()) + ":";
            EmpathyLabel.Text = Lang.Get(CachedEnum<Archetypes.Empathy>.Type.Lang()) + ":";
            EmotionalLabel.Text = Lang.Get(CachedEnum<Archetypes.Emotional>.Type.Lang()) + ":";
            SocialStatusLabel.Text = Lang.Get(CachedEnum<Archetypes.SocialStatus>.Type.Lang()) + ":";
            SexualityLabel.Text = Lang.Get(CachedEnum<Archetypes.Sexuality>.Type.Lang()) + ":";
            ResponsibilityLabel.Text = Lang.Get(CachedEnum<Archetypes.Responsibility>.Type.Lang()) + ":";
            LoyaltyLabel.Text = Lang.Get(CachedEnum<Archetypes.Loyalty>.Type.Lang()) + ":";
            AdaptibilityLabel.Text = Lang.Get(CachedEnum<Archetypes.Adaptability>.Type.Lang()) + ":";
            TrustinpeopleLabel.Text = Lang.Get(CachedEnum<Archetypes.TrustInPeople>.Type.Lang()) + ":";
            HumorLabel.Text = Lang.Get(CachedEnum<Archetypes.Humor>.Type.Lang()) + ":";
            ForcesPhysical.Text = Lang.Get(CachedEnum<Archetypes.PhysicalPower>.Type.Lang()) + ":";
            ForcesMagic.Text = Lang.Get(CachedEnum<Archetypes.MagicPower>.Type.Lang()) + ":";
            ForcesWill.Text = Lang.Get(CachedEnum<Archetypes.WillPower>.Type.Lang()) + ":";
            ForcesStamina.Text = Lang.Get(CachedEnum<Archetypes.Stamina>.Type.Lang()) + ":";
            ForcesIntellect.Text = Lang.Get(CachedEnum<Archetypes.Intellect>.Type.Lang()) + ":";
            PhysicalPowerLabel.Text = Lang.Get(CachedEnum<Archetypes.PhysicalPower>.Type.Lang()) + ":";
            MagicPowerLabel.Text = Lang.Get(CachedEnum<Archetypes.MagicPower>.Type.Lang()) + ":";
            WillPowerLabel.Text = Lang.Get(CachedEnum<Archetypes.WillPower>.Type.Lang()) + ":";
            StaminaLabel.Text = Lang.Get(CachedEnum<Archetypes.Stamina>.Type.Lang()) + ":";
            IntellectLabel.Text = Lang.Get(CachedEnum<Archetypes.Intellect>.Type.Lang()) + ":";
            HeightLabel.Text = Lang.Get("Height") + ":";
            WeightLabel.Text = Lang.Get("Weight") + ":";
            FatLabel.Text = Lang.Get("Fat") + ":";
            MusclesLabel.Text = Lang.Get("Muscles") + ":";
            EyesColorLabel.Text = Lang.Get(CachedEnum<Archetypes.EyesColor>.Type.Lang()) + ":";
            HairColorLabel.Text = Lang.Get(CachedEnum<Archetypes.HairColor>.Type.Lang()) + ":";
            HairLengthLabel.Text = Lang.Get(CachedEnum<Archetypes.HairLength>.Type.Lang()) + ":";
            BeautyTypeLabel.Text = Lang.Get(CachedEnum<Archetypes.BeautyType>.Type.Lang()) + ":";

            GenderLabel.Text = Lang.Get(CachedEnum<Archetypes.BiologicalGender>.Type.Lang()) + ":";
            GenderLabel.Text = Lang.Get(CachedEnum<Archetypes.BiologicalGender>.Type.Lang()) + ":";
            GenderLabel.Text = Lang.Get(CachedEnum<Archetypes.BiologicalGender>.Type.Lang()) + ":";
            GenderLabel.Text = Lang.Get(CachedEnum<Archetypes.BiologicalGender>.Type.Lang()) + ":";
            GenderLabel.Text = Lang.Get(CachedEnum<Archetypes.BiologicalGender>.Type.Lang()) + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";
            NameLabel.Text = Lang.Get("Name") + ":";

            var path2 = GetPath() + "characters.dat";
            if (File.Exists(path2))
            {
                SavedCharacters = Character.Load(path2).ToList();
                UpdateSavedListBox();
            }

            if (SavedCharacters.Count > 0)
            {
                SavedListBox.SelectedIndex = SavedListBox.Items.Count - 1;
                CurrentCharacter = SavedCharacters[SavedListBox.SelectedIndex];
                UpdateCharacter(CurrentCharacter);
            }
            else
            {
                CurrentCharacter = new Character();
                UpdateCharacter(CurrentCharacter);
            }
            ChPredButton.Enabled = false;
            ChNextButton.Enabled = false;
        }

        public void UpdateCharacter(Character ch)
        {
            FillTitle(ch);
            FillPerson(ch);
            FillAppearance(ch);
            FillForces(ch);
            FillSocial(ch);
            FillPowers(ch);
            FateTextBox.Text = ch.Fate;
        }

        public void LoadHairColor(Character ch)
        {
            if (ch.HairColor == Archetypes.HairColor.Artificial_Coloring)
            {
                HairColorButton.Enabled = true;
                HairColorButton.BackColor = ch.HairColorRGB;
            }
            else
            {
                HairColorButton.Enabled = false;
                HairColorButton.BackColor = Color.Transparent;
            }
        }

        public void FillAppearance(Character ch)
        {
            HeightValue.Value = ch.Height;
            WeightValue.Value = ch.Weight / 10.0M;
            FatValue.Value = (decimal)ch.Fat * 100;
            MusclesValue.Value = (decimal)ch.Muscles * 100;
            EyesColorComboBox.Text = Lang.Get(ch.EyesColor.Lang());
            HairColorComboBox.Text = Lang.Get(ch.HairColor.Lang());
            LoadHairColor(ch);
            HairLengthComboBox.Text = Lang.Get(ch.HairLength.Lang());
            BeautyTypeComboBox.Text = Lang.Get(ch.BeautyType.Lang());
        }

        public void FillSocial(Character ch)
        {
            SocialStatusComboBox.Text = Lang.Get(ch.SocialStatus.Lang());
            SexualityComboBox.Text = Lang.Get(ch.Sexuality.Lang());
            ResponsibilityComboBox.Text = Lang.Get(ch.Responsibility.Lang());
            LoyaltyComboBox.Text = Lang.Get(ch.Loyalty.Lang());
            AdaptibilityComboBox.Text = Lang.Get(ch.Adaptability.Lang());
            TrustinpeopleComboBox.Text = Lang.Get(ch.TrustInPeople.Lang());
            HumorComboBox.Text = Lang.Get(ch.Humor.Lang());
        }

        public void FillTitle(Character ch)
        {
            NameTextBox.Text = ch.Name;
            SurnameTextBox.Text = ch.Surname;
            BirthDatePicker.Value = ch.BirthDate;
            AgeUpDown.Value = ch.Age;
            GenderComboBox.Text = Lang.Get(ch.Gender.Lang());
        }

        public void FillPerson(Character ch)
        {
            MoralityTextBox.Text = Character.InfoChanges(ch.MoralityFuture, 5);
            EthicalTextBox.Text = Character.InfoChanges(ch.EthicalFuture, 5);
            EgoTextBox.Text = Character.InfoChanges(ch.EgoFuture, 5);
            IdeaTextBox.Text = Character.InfoChanges(ch.IdeaFuture, 5);

            MoralityComboBox.Text = Lang.Get(ch.Morality.Lang());
            EthicalComboBox.Text = Lang.Get(ch.Ethical.Lang());
            EgoComboBox.Text = Lang.Get(ch.Ego.Lang());
            IdeaComboBox.Text = Lang.Get(ch.Idea.Lang());
            ProtestComboBox.Text = Lang.Get(ch.Protest.Lang());
            PoliticalComboBox.Text = Lang.Get(ch.Political.Lang());
            EmpathyComboBox.Text = Lang.Get(ch.Empathy.Lang());
            EmotionalComboBox.Text = Lang.Get(ch.Emotional.Lang());
        }

        public void FillForces(Character ch)
        {
            ForcesPhysicalTextBox.Text = Character.InfoChanges(ch.PhysicalPowerFuture, 5);
            ForcesMagicTextBox.Text = Character.InfoChanges(ch.MagicPowerFuture, 5);
            ForcesWillTextBox.Text = Character.InfoChanges(ch.WillPowerFuture, 5);
            ForcesStaminaTextBox.Text = Character.InfoChanges(ch.StaminaFuture, 5);
            ForcesIntellectTextBox.Text = Character.InfoChanges(ch.IntellectFuture, 5);

            ForcesPhysicalComboBox.Text = Lang.Get(ch.PhysicalPower.Lang());
            ForcesMagicComboBox.Text = Lang.Get(ch.MagicPower.Lang());
            ForcesWillComboBox.Text = Lang.Get(ch.WillPower.Lang());
            ForcesStaminaComboBox.Text = Lang.Get(ch.Stamina.Lang());
            ForcesIntellectComboBox.Text = Lang.Get(ch.Intellect.Lang());
        }

        public void FillPowers(Character ch)
        {
            PhysicalFore.Size = new Size((int)(PhysicalBack.Size.Width * ch.PercentPhysicalPower), PhysicalBack.Size.Height);
            PhysicalText.Text = ch.PercentPhysicalPower.Percent();
            MagicFore.Size = new Size((int)(MagicBack.Size.Width * ch.PercentMagicPower), MagicBack.Size.Height);
            MagicText.Text = ch.PercentMagicPower.Percent();
            WillFore.Size = new Size((int)(WillBack.Size.Width * ch.PercentWillPower), WillBack.Size.Height);
            WillText.Text = ch.PercentWillPower.Percent();
            StaminaFore.Size = new Size((int)(StaminaBack.Size.Width * ch.PercentStamina), StaminaBack.Size.Height);
            StaminaText.Text = ch.PercentStamina.Percent();
            IntellectFore.Size = new Size((int)(IntellectBack.Size.Width * ch.PercentIntellect), IntellectBack.Size.Height);
            IntellectText.Text = ch.PercentIntellect.Percent();
        }

        private void MoralityButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, MoralityTextBox, Lang.Get(CachedEnum<Archetypes.Morality>.Type.Lang()), CurrentCharacter.MoralityFuture);
            cfc.FormClosed += (o, e2) =>
            {
                MoralityButton.Enabled = true;
            };
            MoralityButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void EthicalButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, EthicalTextBox, Lang.Get(CachedEnum<Archetypes.Ethical>.Type.Lang()), CurrentCharacter.EthicalFuture);
            cfc.FormClosed += (o, e2) =>
            {
                EthicalButton.Enabled = true;
            };
            EthicalButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void EgoButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, EgoTextBox, Lang.Get(CachedEnum<Archetypes.Ego>.Type.Lang()), CurrentCharacter.EgoFuture);
            cfc.FormClosed += (o, e2) =>
            {
                EgoButton.Enabled = true;
            };
            EgoButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void IdeaButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, IdeaTextBox, Lang.Get(CachedEnum<Archetypes.Idea>.Type.Lang()), CurrentCharacter.IdeaFuture);
            cfc.FormClosed += (o, e2) =>
            {
                IdeaButton.Enabled = true;
            };
            IdeaButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void ForcesPhysicalButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, ForcesPhysicalTextBox, Lang.Get(CachedEnum<Archetypes.PhysicalPower>.Type.Lang()), CurrentCharacter.PhysicalPowerFuture);
            cfc.OnUpdate += () =>
            {
                FillPowers(CurrentCharacter);
            };
            cfc.FormClosed += (o, e2) =>
            {
                ForcesPhysicalButton.Enabled = true;
            };
            ForcesPhysicalButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void ForcesMagicButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, ForcesMagicTextBox, Lang.Get(CachedEnum<Archetypes.MagicPower>.Type.Lang()), CurrentCharacter.MagicPowerFuture);
            cfc.OnUpdate += () =>
            {
                FillPowers(CurrentCharacter);
            };
            cfc.FormClosed += (o, e2) =>
            {
                ForcesMagicButton.Enabled = true;
            };
            ForcesMagicButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void ForcesWillButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, ForcesWillTextBox, Lang.Get(CachedEnum<Archetypes.WillPower>.Type.Lang()), CurrentCharacter.WillPowerFuture);
            cfc.OnUpdate += () =>
            {
                FillPowers(CurrentCharacter);
            };
            cfc.FormClosed += (o, e2) =>
            {
                ForcesWillButton.Enabled = true;
            };
            ForcesWillButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void ForcesStaminaButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, ForcesStaminaTextBox, Lang.Get(CachedEnum<Archetypes.Stamina>.Type.Lang()), CurrentCharacter.StaminaFuture);
            cfc.OnUpdate += () =>
            {
                FillPowers(CurrentCharacter);
            };
            cfc.FormClosed += (o, e2) =>
            {
                ForcesStaminaButton.Enabled = true;
            };
            ForcesStaminaButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void ForcesIntellectButton_Click(object sender, EventArgs e)
        {
            var cfc = new ChangeFiveChanges(this, ForcesIntellectTextBox, Lang.Get(CachedEnum<Archetypes.Intellect>.Type.Lang()), CurrentCharacter.IntellectFuture);
            cfc.OnUpdate += () =>
            {
                FillPowers(CurrentCharacter);
            };
            cfc.FormClosed += (o, e2) =>
            {
                ForcesIntellectButton.Enabled = true;
            };
            ForcesIntellectButton.Enabled = false;
            cfc.ShowDialog();
        }

        private void SeedTextBox_Click(object sender, EventArgs e)
        {
            if (uint.TryParse(SeedTextBox.Text, out var i))
            {
                SeedTextBox.ForeColor = Color.Black;
                CurrentCharacter = new CharacterBuilder((int)i).Init();
                UpdateCharacter(CurrentCharacter);
            }
            else SeedTextBox.ForeColor = Color.Red;
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            CurrentCharacter = new CharacterBuilder(GlobalSeed.Next()).Init();
            AddSeedToBuffer(CurrentCharacter.Seed);
            SeedTextBox.Text = CurrentCharacter.Seed.ToString();
            UpdateCharacter(CurrentCharacter);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            CurrentCharacter = new Character();
            if (BufferId != -1) RemoveNextSeeds(BufferId);
            if (BufferSeeds.Count > 0) ChPredButton.Enabled = true;
            BufferId = -1;
            SeedTextBox.Text = "";
            UpdateCharacter(CurrentCharacter);
        }

        #region Buffer Realization
        public List<int> BufferSeeds = new List<int>();
        public int BufferId = -1;
        private void AddSeedToBuffer(int seed)
        {
            if (BufferId != -1) RemoveNextSeeds(BufferId);
            BufferId = -1;
            BufferSeeds.Add(CurrentCharacter.Seed);
            if (BufferSeeds.Count > 1) ChPredButton.Enabled = true;
            else ChPredButton.Enabled = false;
            ChNextButton.Enabled = false;
        }

        private void SeedText_Leave(object sender, EventArgs e)
        {
            if (!BufferSeeds.Contains(CurrentCharacter.Seed))
            {
                AddSeedToBuffer(CurrentCharacter.Seed);
            }
        }

        private void RemoveNextSeeds(int seed)
        {
            for (var i = BufferSeeds.Count - 1; i > BufferId; i--) BufferSeeds.RemoveAt(i);
            BufferId = -1;
            ChNextButton.Enabled = false;
        }

        private void ChPredButton_Click(object sender, EventArgs e)
        {
            if (BufferId == -1)
            {
                if (BufferSeeds.Count > 1)
                {
                    if (!CurrentCharacter.Generated)
                    {
                        BufferId = BufferSeeds.Count - 1;
                        SeedTextBox.Text = BufferSeeds[BufferId].ToString();
                    }
                    else
                    {
                        BufferId = BufferSeeds.Count - 2;
                        SeedTextBox.Text = BufferSeeds[BufferId].ToString();
                        ChNextButton.Enabled = true;
                    }
                }
                else if (BufferSeeds.Count == 1)
                {
                    if (!CurrentCharacter.Generated)
                    {
                        BufferId = BufferSeeds.Count - 1;
                        SeedTextBox.Text = BufferSeeds[BufferId].ToString();
                    }
                }
            }
            else if (BufferId > 0)
            {
                BufferId -= 1;
                ChNextButton.Enabled = true;
                SeedTextBox.Text = BufferSeeds[BufferId].ToString();
            }
            if (BufferId == 0) ChPredButton.Enabled = false;
        }

        private void ChNextButton_Click(object sender, EventArgs e)
        {
            if (BufferId == -1) return;
            if (BufferId < BufferSeeds.Count - 1)
            {
                BufferId += 1;
                if (BufferId > 0) ChPredButton.Enabled = true;
                if (BufferId == BufferSeeds.Count - 1) ChNextButton.Enabled = false;
                SeedTextBox.Text = BufferSeeds[BufferId].ToString();
            }
        }
        #endregion

        private void RandomName_Click(object sender, EventArgs e)
        {
            CurrentCharacter.RandomName(GlobalSeed);
            FillTitle(CurrentCharacter);
        }

        private void RandomSurname_Click(object sender, EventArgs e)
        {
            CurrentCharacter.RandomSurname(GlobalSeed);
            FillTitle(CurrentCharacter);
        }

        private void RandomBirthDate_Click(object sender, EventArgs e)
        {
            CurrentCharacter.RandomBirthDate(GlobalSeed);
            FillTitle(CurrentCharacter);
        }

        private void HairColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.HairColor = (Archetypes.HairColor)HairColorComboBox.SelectedIndex;
            LoadHairColor(CurrentCharacter);
        }

        private void HairColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentCharacter.HairColorRGB = colorDialog1.Color;
                HairColorButton.BackColor = colorDialog1.Color;
            }
        }

        private void RandomationLawsButton_Click(object sender, EventArgs e)
        {
            var rl = new RandomationLaws();
            rl.ShowDialog();
        }

        private void GenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Gender = (Archetypes.BiologicalGender)GenderComboBox.SelectedIndex;
        }

        private void BirthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacter.BirthDate = BirthDatePicker.Value;
        }

        private void AgeUpDown_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Age = (int)AgeUpDown.Value;
        }

        private void MoralityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Morality = (Archetypes.Morality)MoralityComboBox.SelectedIndex;
        }

        private void EthicalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Ethical = (Archetypes.Ethical)EthicalComboBox.SelectedIndex;
        }

        private void EgoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Ego = (Archetypes.Ego)EgoComboBox.SelectedIndex;
        }

        private void IdeaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Idea = (Archetypes.Idea)IdeaComboBox.SelectedIndex;
        }

        private void ProtestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Protest = (Archetypes.Protest)ProtestComboBox.SelectedIndex;
        }

        private void PoliticalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Political = (Archetypes.Political)PoliticalComboBox.SelectedIndex;
        }

        private void EmpathyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Empathy = (Archetypes.Empathy)EmpathyComboBox.SelectedIndex;
        }

        private void EmotionalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Emotional = (Archetypes.Emotional)EmotionalComboBox.SelectedIndex;
        }

        private void HeightValue_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Height = (int)HeightValue.Value;
        }

        private void WeightValue_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Weight = (int)(WeightValue.Value * 10);
        }

        private void FatValue_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Fat = (double)FatValue.Value / 100.0;
        }

        private void MusclesValue_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Muscles = (double)MusclesValue.Value / 100.0;
        }

        private void EyesColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.EyesColor = (Archetypes.EyesColor)EyesColorComboBox.SelectedIndex;
        }

        private void HairLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.HairLength = (Archetypes.HairLength)HairLengthComboBox.SelectedIndex;
        }

        private void BeautyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.BeautyType = (Archetypes.BeautyType)BeautyTypeComboBox.SelectedIndex;
        }

        private void ForcesPhysicalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.PhysicalPower = (Archetypes.PhysicalPower)ForcesPhysicalComboBox.SelectedIndex;
            FillPowers(CurrentCharacter);
        }

        private void ForcesMagicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.MagicPower = (Archetypes.MagicPower)ForcesMagicComboBox.SelectedIndex;
            FillPowers(CurrentCharacter);
        }

        private void ForcesWillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.WillPower = (Archetypes.WillPower)ForcesWillComboBox.SelectedIndex;
            FillPowers(CurrentCharacter);
        }

        private void ForcesStaminaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Stamina = (Archetypes.Stamina)ForcesStaminaComboBox.SelectedIndex;
            FillPowers(CurrentCharacter);
        }

        private void ForcesIntellectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Intellect = (Archetypes.Intellect)ForcesIntellectComboBox.SelectedIndex;
            FillPowers(CurrentCharacter);
        }

        private void SocialStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.SocialStatus = (Archetypes.SocialStatus)SocialStatusComboBox.SelectedIndex;
        }

        private void SexualityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Sexuality = (Archetypes.Sexuality)SexualityComboBox.SelectedIndex;
        }

        private void ResponsibilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Responsibility = (Archetypes.Responsibility)ResponsibilityComboBox.SelectedIndex;
        }

        private void LoyaltyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Loyalty = (Archetypes.Loyalty)LoyaltyComboBox.SelectedIndex;
        }

        private void AdaptibilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Adaptability = (Archetypes.Adaptability)AdaptibilityComboBox.SelectedIndex;
        }

        private void TrustinpeopleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.TrustInPeople = (Archetypes.TrustInPeople)TrustinpeopleComboBox.SelectedIndex;
        }

        private void HumorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Humor = (Archetypes.Humor)HumorComboBox.SelectedIndex;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Name = NameTextBox.Text;
            UpdateCurrentInListBox();
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Surname = SurnameTextBox.Text;
            UpdateCurrentInListBox();
        }

        private void SavedListBox_Leave(object sender, EventArgs e)
        {
            SavedListBox.Update();
        }

        private void FateTextBox_TextChanged(object sender, EventArgs e)
        {
            CurrentCharacter.Fate = FateTextBox.Text;
        }
    }
}
