
namespace Tropegen
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TB_Seed = new System.Windows.Forms.TextBox();
            this.ChString = new System.Windows.Forms.RichTextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.RandomButton = new System.Windows.Forms.Button();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.usedLabel = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.RunExtendedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_Seed
            // 
            this.TB_Seed.Location = new System.Drawing.Point(13, 13);
            this.TB_Seed.Name = "TB_Seed";
            this.TB_Seed.Size = new System.Drawing.Size(124, 20);
            this.TB_Seed.TabIndex = 0;
            this.TB_Seed.TextChanged += new System.EventHandler(this.TB_Seed_TextChanged);
            // 
            // ChString
            // 
            this.ChString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChString.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChString.Location = new System.Drawing.Point(13, 40);
            this.ChString.Name = "ChString";
            this.ChString.ReadOnly = true;
            this.ChString.Size = new System.Drawing.Size(467, 287);
            this.ChString.TabIndex = 1;
            this.ChString.Text = "";
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.Location = new System.Drawing.Point(259, 9);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.versionLabel.Size = new System.Drawing.Size(221, 23);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "version";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RandomButton
            // 
            this.RandomButton.Location = new System.Drawing.Point(143, 11);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(85, 23);
            this.RandomButton.TabIndex = 3;
            this.RandomButton.Text = "Rand";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copyrightLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.copyrightLabel.Location = new System.Drawing.Point(10, 330);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(326, 23);
            this.copyrightLabel.TabIndex = 4;
            this.copyrightLabel.Text = "copyright";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usedLabel
            // 
            this.usedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.usedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.usedLabel.Location = new System.Drawing.Point(259, 330);
            this.usedLabel.Name = "usedLabel";
            this.usedLabel.Size = new System.Drawing.Size(224, 23);
            this.usedLabel.TabIndex = 5;
            this.usedLabel.Text = "thanks";
            this.usedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(234, 11);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(85, 23);
            this.SettingsButton.TabIndex = 6;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // RunExtendedButton
            // 
            this.RunExtendedButton.Location = new System.Drawing.Point(325, 11);
            this.RunExtendedButton.Name = "RunExtendedButton";
            this.RunExtendedButton.Size = new System.Drawing.Size(94, 23);
            this.RunExtendedButton.TabIndex = 7;
            this.RunExtendedButton.Text = "Extended";
            this.RunExtendedButton.UseVisualStyleBackColor = true;
            this.RunExtendedButton.Click += new System.EventHandler(this.RunExtendedButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 362);
            this.Controls.Add(this.RunExtendedButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.usedLabel);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.TB_Seed);
            this.Controls.Add(this.ChString);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(508, 400);
            this.Name = "Form1";
            this.Text = "Tropegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Seed;
        private System.Windows.Forms.RichTextBox ChString;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label usedLabel;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button RunExtendedButton;
    }
}

