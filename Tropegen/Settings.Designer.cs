
namespace Tropegen
{
    partial class Settings
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
            this.LangGB = new System.Windows.Forms.GroupBox();
            this.labelSurnamesCount = new System.Windows.Forms.Label();
            this.labelNamesCount = new System.Windows.Forms.Label();
            this.TB_NamesCount = new System.Windows.Forms.TextBox();
            this.TB_SurnamesCount = new System.Windows.Forms.TextBox();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.RandomationLawsGB = new System.Windows.Forms.GroupBox();
            this.CB_AgeTypeLaw = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_MoralityLaw = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_PoliticalLaw = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_ProtestLaw = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_StaminaLaw = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_WillPowerLaw = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_MagicPowerLaw = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_PhysicalPowerLaw = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_IntellectLaw = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.HelpInfoLabel = new System.Windows.Forms.TextBox();
            this.LangGB.SuspendLayout();
            this.RandomationLawsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // LangGB
            // 
            this.LangGB.Controls.Add(this.TB_SurnamesCount);
            this.LangGB.Controls.Add(this.TB_NamesCount);
            this.LangGB.Controls.Add(this.labelNamesCount);
            this.LangGB.Controls.Add(this.labelSurnamesCount);
            this.LangGB.Location = new System.Drawing.Point(13, 13);
            this.LangGB.Name = "LangGB";
            this.LangGB.Size = new System.Drawing.Size(270, 252);
            this.LangGB.TabIndex = 0;
            this.LangGB.TabStop = false;
            this.LangGB.Text = "Lang";
            // 
            // labelSurnamesCount
            // 
            this.labelSurnamesCount.Location = new System.Drawing.Point(6, 41);
            this.labelSurnamesCount.Name = "labelSurnamesCount";
            this.labelSurnamesCount.Size = new System.Drawing.Size(151, 25);
            this.labelSurnamesCount.TabIndex = 0;
            this.labelSurnamesCount.Text = "SurnamesCount:";
            this.labelSurnamesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNamesCount
            // 
            this.labelNamesCount.Location = new System.Drawing.Point(6, 16);
            this.labelNamesCount.Name = "labelNamesCount";
            this.labelNamesCount.Size = new System.Drawing.Size(151, 25);
            this.labelNamesCount.TabIndex = 1;
            this.labelNamesCount.Text = "NamesCount:";
            this.labelNamesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_NamesCount
            // 
            this.TB_NamesCount.Location = new System.Drawing.Point(163, 19);
            this.TB_NamesCount.Name = "TB_NamesCount";
            this.TB_NamesCount.Size = new System.Drawing.Size(101, 20);
            this.TB_NamesCount.TabIndex = 2;
            this.TB_NamesCount.TextChanged += new System.EventHandler(this.TB_NamesCount_TextChanged);
            // 
            // TB_SurnamesCount
            // 
            this.TB_SurnamesCount.Location = new System.Drawing.Point(163, 44);
            this.TB_SurnamesCount.Name = "TB_SurnamesCount";
            this.TB_SurnamesCount.Size = new System.Drawing.Size(101, 20);
            this.TB_SurnamesCount.TabIndex = 3;
            this.TB_SurnamesCount.TextChanged += new System.EventHandler(this.TB_SurnamesCount_TextChanged);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Location = new System.Drawing.Point(460, 290);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(101, 23);
            this.DefaultButton.TabIndex = 5;
            this.DefaultButton.Text = "Default";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // RandomationLawsGB
            // 
            this.RandomationLawsGB.Controls.Add(this.CB_IntellectLaw);
            this.RandomationLawsGB.Controls.Add(this.label12);
            this.RandomationLawsGB.Controls.Add(this.CB_StaminaLaw);
            this.RandomationLawsGB.Controls.Add(this.label7);
            this.RandomationLawsGB.Controls.Add(this.CB_WillPowerLaw);
            this.RandomationLawsGB.Controls.Add(this.label8);
            this.RandomationLawsGB.Controls.Add(this.CB_MagicPowerLaw);
            this.RandomationLawsGB.Controls.Add(this.label9);
            this.RandomationLawsGB.Controls.Add(this.CB_PhysicalPowerLaw);
            this.RandomationLawsGB.Controls.Add(this.label10);
            this.RandomationLawsGB.Controls.Add(this.CB_PoliticalLaw);
            this.RandomationLawsGB.Controls.Add(this.label5);
            this.RandomationLawsGB.Controls.Add(this.CB_ProtestLaw);
            this.RandomationLawsGB.Controls.Add(this.label6);
            this.RandomationLawsGB.Controls.Add(this.CB_MoralityLaw);
            this.RandomationLawsGB.Controls.Add(this.label4);
            this.RandomationLawsGB.Controls.Add(this.CB_AgeTypeLaw);
            this.RandomationLawsGB.Controls.Add(this.label3);
            this.RandomationLawsGB.Location = new System.Drawing.Point(290, 13);
            this.RandomationLawsGB.Name = "RandomationLawsGB";
            this.RandomationLawsGB.Size = new System.Drawing.Size(271, 252);
            this.RandomationLawsGB.TabIndex = 6;
            this.RandomationLawsGB.TabStop = false;
            this.RandomationLawsGB.Text = "RandomationLaws";
            // 
            // CB_AgeTypeLaw
            // 
            this.CB_AgeTypeLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_AgeTypeLaw.FormattingEnabled = true;
            this.CB_AgeTypeLaw.Location = new System.Drawing.Point(146, 22);
            this.CB_AgeTypeLaw.Name = "CB_AgeTypeLaw";
            this.CB_AgeTypeLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_AgeTypeLaw.TabIndex = 9;
            this.CB_AgeTypeLaw.SelectedIndexChanged += new System.EventHandler(this.CB_AgeTypeLaw_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "AgeTypeLaw:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_MoralityLaw
            // 
            this.CB_MoralityLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MoralityLaw.FormattingEnabled = true;
            this.CB_MoralityLaw.Location = new System.Drawing.Point(146, 47);
            this.CB_MoralityLaw.Name = "CB_MoralityLaw";
            this.CB_MoralityLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_MoralityLaw.TabIndex = 11;
            this.CB_MoralityLaw.SelectedIndexChanged += new System.EventHandler(this.CB_MoralityLaw_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "MoralityLaw:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_PoliticalLaw
            // 
            this.CB_PoliticalLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PoliticalLaw.FormattingEnabled = true;
            this.CB_PoliticalLaw.Location = new System.Drawing.Point(146, 97);
            this.CB_PoliticalLaw.Name = "CB_PoliticalLaw";
            this.CB_PoliticalLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_PoliticalLaw.TabIndex = 15;
            this.CB_PoliticalLaw.SelectedIndexChanged += new System.EventHandler(this.CB_PoliticalLaw_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "PoliticalLaw:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_ProtestLaw
            // 
            this.CB_ProtestLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ProtestLaw.FormattingEnabled = true;
            this.CB_ProtestLaw.Location = new System.Drawing.Point(146, 72);
            this.CB_ProtestLaw.Name = "CB_ProtestLaw";
            this.CB_ProtestLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_ProtestLaw.TabIndex = 13;
            this.CB_ProtestLaw.SelectedIndexChanged += new System.EventHandler(this.CB_ProtestLaw_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "ProtestLaw:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_StaminaLaw
            // 
            this.CB_StaminaLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_StaminaLaw.FormattingEnabled = true;
            this.CB_StaminaLaw.Location = new System.Drawing.Point(146, 197);
            this.CB_StaminaLaw.Name = "CB_StaminaLaw";
            this.CB_StaminaLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_StaminaLaw.TabIndex = 23;
            this.CB_StaminaLaw.SelectedIndexChanged += new System.EventHandler(this.CB_StaminaLaw_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "StaminaLaw:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_WillPowerLaw
            // 
            this.CB_WillPowerLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_WillPowerLaw.FormattingEnabled = true;
            this.CB_WillPowerLaw.Location = new System.Drawing.Point(146, 172);
            this.CB_WillPowerLaw.Name = "CB_WillPowerLaw";
            this.CB_WillPowerLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_WillPowerLaw.TabIndex = 21;
            this.CB_WillPowerLaw.SelectedIndexChanged += new System.EventHandler(this.CB_WillPowerLaw_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "WillPowerLaw:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_MagicPowerLaw
            // 
            this.CB_MagicPowerLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MagicPowerLaw.FormattingEnabled = true;
            this.CB_MagicPowerLaw.Location = new System.Drawing.Point(146, 147);
            this.CB_MagicPowerLaw.Name = "CB_MagicPowerLaw";
            this.CB_MagicPowerLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_MagicPowerLaw.TabIndex = 19;
            this.CB_MagicPowerLaw.SelectedIndexChanged += new System.EventHandler(this.CB_MagicPowerLaw_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "MagicPowerLaw:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_PhysicalPowerLaw
            // 
            this.CB_PhysicalPowerLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PhysicalPowerLaw.FormattingEnabled = true;
            this.CB_PhysicalPowerLaw.Location = new System.Drawing.Point(146, 122);
            this.CB_PhysicalPowerLaw.Name = "CB_PhysicalPowerLaw";
            this.CB_PhysicalPowerLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_PhysicalPowerLaw.TabIndex = 17;
            this.CB_PhysicalPowerLaw.SelectedIndexChanged += new System.EventHandler(this.CB_PhysicalPowerLaw_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "PhysicalPowerLaw:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_IntellectLaw
            // 
            this.CB_IntellectLaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_IntellectLaw.FormattingEnabled = true;
            this.CB_IntellectLaw.Location = new System.Drawing.Point(146, 222);
            this.CB_IntellectLaw.Name = "CB_IntellectLaw";
            this.CB_IntellectLaw.Size = new System.Drawing.Size(119, 21);
            this.CB_IntellectLaw.TabIndex = 25;
            this.CB_IntellectLaw.SelectedIndexChanged += new System.EventHandler(this.CB_IntellectLaw_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 25);
            this.label12.TabIndex = 24;
            this.label12.Text = "IntellectLaw:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HelpInfoLabel
            // 
            this.HelpInfoLabel.Location = new System.Drawing.Point(13, 273);
            this.HelpInfoLabel.Multiline = true;
            this.HelpInfoLabel.Name = "HelpInfoLabel";
            this.HelpInfoLabel.ReadOnly = true;
            this.HelpInfoLabel.Size = new System.Drawing.Size(441, 40);
            this.HelpInfoLabel.TabIndex = 7;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 325);
            this.Controls.Add(this.HelpInfoLabel);
            this.Controls.Add(this.RandomationLawsGB);
            this.Controls.Add(this.LangGB);
            this.Controls.Add(this.DefaultButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.LangGB.ResumeLayout(false);
            this.LangGB.PerformLayout();
            this.RandomationLawsGB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox LangGB;
        private System.Windows.Forms.Label labelSurnamesCount;
        private System.Windows.Forms.Label labelNamesCount;
        private System.Windows.Forms.TextBox TB_SurnamesCount;
        private System.Windows.Forms.TextBox TB_NamesCount;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.GroupBox RandomationLawsGB;
        private System.Windows.Forms.ComboBox CB_AgeTypeLaw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_PoliticalLaw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_ProtestLaw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_MoralityLaw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_IntellectLaw;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox CB_StaminaLaw;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_WillPowerLaw;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CB_MagicPowerLaw;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CB_PhysicalPowerLaw;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox HelpInfoLabel;
    }
}