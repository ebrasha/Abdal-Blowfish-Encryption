using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Abdal_Security_Group_App
{
    public partial class EncText : Telerik.WinControls.UI.RadForm
    {
        private string abdal_app_name = Assembly.GetExecutingAssembly().GetName().ToString().Split(',')[0];

        public EncText()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version!;
            Text = abdal_app_name + " " + version.Major + "." + version.Minor + " - Enc Text";
        }

        private void EncText_Load(object sender, EventArgs e)
        {
        }

        public void SetEncText(string EncText)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { EncRichTextEditor.Text = EncText; }));
            }
            else
            {
                EncRichTextEditor.Text = EncText;
            }
        }

        public string GetEncText()
        {
            if (EncRichTextEditor.InvokeRequired)
            {
                return (string)EncRichTextEditor.Invoke(new Func<string>(() => EncRichTextEditor.Text));
            }
            else
            {
                return EncRichTextEditor.Text;
            }
        }


        private void EncText_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}