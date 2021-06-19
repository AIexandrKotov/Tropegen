
namespace Tropegen
{
    partial class RandomationLaws
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomationLaws));
            this.LawsList = new System.Windows.Forms.ListBox();
            this.CurrentLaw = new System.Windows.Forms.ComboBox();
            this.AllLawsDesc = new System.Windows.Forms.RichTextBox();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.HelpInfoBox = new System.Windows.Forms.RichTextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameValue = new System.Windows.Forms.NumericUpDown();
            this.SurnameValue = new System.Windows.Forms.NumericUpDown();
            this.SurnameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NameValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurnameValue)).BeginInit();
            this.SuspendLayout();
            // 
            // LawsList
            // 
            this.LawsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LawsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LawsList.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LawsList.FormattingEnabled = true;
            this.LawsList.ItemHeight = 15;
            this.LawsList.Location = new System.Drawing.Point(12, 12);
            this.LawsList.Name = "LawsList";
            this.LawsList.Size = new System.Drawing.Size(169, 302);
            this.LawsList.TabIndex = 0;
            this.LawsList.SelectedIndexChanged += new System.EventHandler(this.LawsList_SelectedIndexChanged);
            this.LawsList.Leave += new System.EventHandler(this.LawsList_Leave);
            // 
            // CurrentLaw
            // 
            this.CurrentLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentLaw.FormattingEnabled = true;
            this.CurrentLaw.Location = new System.Drawing.Point(187, 12);
            this.CurrentLaw.Name = "CurrentLaw";
            this.CurrentLaw.Size = new System.Drawing.Size(179, 21);
            this.CurrentLaw.TabIndex = 1;
            this.CurrentLaw.SelectedIndexChanged += new System.EventHandler(this.CurrentLaw_SelectedIndexChanged);
            // 
            // AllLawsDesc
            // 
            this.AllLawsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllLawsDesc.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllLawsDesc.Location = new System.Drawing.Point(187, 100);
            this.AllLawsDesc.Name = "AllLawsDesc";
            this.AllLawsDesc.ReadOnly = true;
            this.AllLawsDesc.Size = new System.Drawing.Size(685, 248);
            this.AllLawsDesc.TabIndex = 2;
            this.AllLawsDesc.Text = "";
            // 
            // DefaultButton
            // 
            this.DefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DefaultButton.Location = new System.Drawing.Point(12, 325);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(169, 23);
            this.DefaultButton.TabIndex = 3;
            this.DefaultButton.Text = "Default";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // HelpInfoBox
            // 
            this.HelpInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpInfoBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpInfoBox.Location = new System.Drawing.Point(187, 40);
            this.HelpInfoBox.Name = "HelpInfoBox";
            this.HelpInfoBox.ReadOnly = true;
            this.HelpInfoBox.Size = new System.Drawing.Size(685, 54);
            this.HelpInfoBox.TabIndex = 4;
            this.HelpInfoBox.Text = "";
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLabel.Location = new System.Drawing.Point(414, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(150, 25);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Name:";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameValue
            // 
            this.NameValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NameValue.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NameValue.Location = new System.Drawing.Point(570, 13);
            this.NameValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NameValue.Name = "NameValue";
            this.NameValue.Size = new System.Drawing.Size(70, 20);
            this.NameValue.TabIndex = 6;
            this.NameValue.ThousandsSeparator = true;
            this.NameValue.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.NameValue.ValueChanged += new System.EventHandler(this.NameValue_ValueChanged);
            // 
            // SurnameValue
            // 
            this.SurnameValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SurnameValue.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SurnameValue.Location = new System.Drawing.Point(802, 13);
            this.SurnameValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.SurnameValue.Name = "SurnameValue";
            this.SurnameValue.Size = new System.Drawing.Size(70, 20);
            this.SurnameValue.TabIndex = 8;
            this.SurnameValue.ThousandsSeparator = true;
            this.SurnameValue.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SurnameValue.ValueChanged += new System.EventHandler(this.SurnameValue_ValueChanged);
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SurnameLabel.Location = new System.Drawing.Point(646, 8);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(150, 25);
            this.SurnameLabel.TabIndex = 7;
            this.SurnameLabel.Text = "Surname:";
            this.SurnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RandomationLaws
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 362);
            this.Controls.Add(this.SurnameValue);
            this.Controls.Add(this.SurnameLabel);
            this.Controls.Add(this.NameValue);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.HelpInfoBox);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.AllLawsDesc);
            this.Controls.Add(this.CurrentLaw);
            this.Controls.Add(this.LawsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomationLaws";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RandomationLaws";
            this.Load += new System.EventHandler(this.RandomationLaws_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NameValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurnameValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LawsList;
        private System.Windows.Forms.ComboBox CurrentLaw;
        private System.Windows.Forms.RichTextBox AllLawsDesc;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.RichTextBox HelpInfoBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.NumericUpDown NameValue;
        private System.Windows.Forms.NumericUpDown SurnameValue;
        private System.Windows.Forms.Label SurnameLabel;
    }
}