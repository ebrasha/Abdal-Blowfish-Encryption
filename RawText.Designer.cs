namespace Abdal_Security_Group_App
{
    partial class RawText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawText));
            visualStudio2022DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2022DarkTheme();
            RawRichTextEditor = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // RawRichTextEditor
            // 
            RawRichTextEditor.BackColor = Color.FromArgb(36, 36, 36);
            RawRichTextEditor.BorderStyle = BorderStyle.None;
            RawRichTextEditor.Dock = DockStyle.Fill;
            RawRichTextEditor.ForeColor = Color.WhiteSmoke;
            RawRichTextEditor.Location = new Point(0, 0);
            RawRichTextEditor.Name = "RawRichTextEditor";
            RawRichTextEditor.Size = new Size(672, 295);
            RawRichTextEditor.TabIndex = 0;
            RawRichTextEditor.Text = "";
            // 
            // RawText
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 295);
            Controls.Add(RawRichTextEditor);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RawText";
            Opacity = 0.94D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RawText";
            ThemeName = "VisualStudio2022Dark";
            FormClosing += RawText_FormClosing;
            Load += RawText_Load;
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Telerik.WinControls.Themes.VisualStudio2022DarkTheme visualStudio2022DarkTheme1;
        private RichTextBox RawRichTextEditor;
    }
}
