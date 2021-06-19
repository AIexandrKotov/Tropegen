
namespace Tropegen
{
    partial class CharacterLists
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
            this.NewButton = new System.Windows.Forms.Button();
            this.ListOfList = new System.Windows.Forms.ComboBox();
            this.NewTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(185, 40);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(78, 25);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // ListOfList
            // 
            this.ListOfList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListOfList.FormattingEnabled = true;
            this.ListOfList.Location = new System.Drawing.Point(13, 12);
            this.ListOfList.Name = "ListOfList";
            this.ListOfList.Size = new System.Drawing.Size(275, 21);
            this.ListOfList.TabIndex = 4;
            this.ListOfList.SelectedIndexChanged += new System.EventHandler(this.ListOfList_SelectedIndexChanged);
            // 
            // NewTextBox
            // 
            this.NewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTextBox.Location = new System.Drawing.Point(12, 43);
            this.NewTextBox.Name = "NewTextBox";
            this.NewTextBox.Size = new System.Drawing.Size(167, 20);
            this.NewTextBox.TabIndex = 5;
            this.NewTextBox.TextChanged += new System.EventHandler(this.NewTextBox_TextChanged);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(13, 70);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.Size = new System.Drawing.Size(359, 130);
            this.DescriptionTextBox.TabIndex = 6;
            this.DescriptionTextBox.Text = "";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Location = new System.Drawing.Point(294, 9);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(78, 25);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RenameButton.Location = new System.Drawing.Point(269, 40);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(103, 25);
            this.RenameButton.TabIndex = 8;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // CharacterLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NewTextBox);
            this.Controls.Add(this.ListOfList);
            this.Controls.Add(this.NewButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "CharacterLists";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CharacterLists";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.ComboBox ListOfList;
        private System.Windows.Forms.TextBox NewTextBox;
        private System.Windows.Forms.RichTextBox DescriptionTextBox;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button RenameButton;
    }
}