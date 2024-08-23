namespace Abdal_Security_Group_App
{
    partial class EncText
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
            visualStudio2022DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2022DarkTheme();
            EncRichTextEditor = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // EncRichTextEditor
            // 
            EncRichTextEditor.BackColor = Color.FromArgb(36, 36, 36);
            EncRichTextEditor.BorderStyle = BorderStyle.None;
            EncRichTextEditor.Dock = DockStyle.Fill;
            EncRichTextEditor.ForeColor = Color.WhiteSmoke;
            EncRichTextEditor.Location = new Point(0, 0);
            EncRichTextEditor.Name = "EncRichTextEditor";
            EncRichTextEditor.Size = new Size(672, 295);
            EncRichTextEditor.TabIndex = 0;
            EncRichTextEditor.Text = "";
            // 
            // EncText
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 295);
            Controls.Add(EncRichTextEditor);
            Name = "EncText";
            Opacity = 0.94D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EncText";
            ThemeName = "VisualStudio2022Dark";
            FormClosing += EncText_FormClosing;
            Load += EncText_Load;
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2022DarkTheme visualStudio2022DarkTheme1;
        private RichTextBox EncRichTextEditor;
    }
}
