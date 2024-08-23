using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Abdal_Security_Group_App
{
    public partial class RawText : Telerik.WinControls.UI.RadForm
    {
        private string abdal_app_name = Assembly.GetExecutingAssembly().GetName().ToString().Split(',')[0];
        public RawText()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version!;
            Text = abdal_app_name + " " + version.Major + "." + version.Minor + " - Raw Text";
        }


        public  string GetRawText()
        {
            if (RawRichTextEditor.InvokeRequired)
            {
                return (string)RawRichTextEditor.Invoke(new Func<string>(() => RawRichTextEditor.Text));
            }
            else
            {
                return RawRichTextEditor.Text;
            }

        }

        public void SetDeCryptText(string DeCryptText)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { RawRichTextEditor.Text = DeCryptText; }));
            }
            else
            {
                RawRichTextEditor.Text = DeCryptText;
            }
        }


        private void RawText_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void RawText_Load(object sender, EventArgs e)
        {

        }
    }
}
