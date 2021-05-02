using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsoftware.IPWorksEncrypt;
using Telerik.WinControls.UI;

namespace Abdal_Security_Group_App
{
    public partial class Abdal_Blowfish_Encryption : Telerik.WinControls.UI.RadForm
    {
        public Abdal_Blowfish_Encryption()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "Abdal Blowfish Encryption" + " " + version.Major + "." + version.Minor; //change form title
        }

        private void EncryptToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (EncryptToggleSwitch.Value == true)
            {
                DecryptToggleSwitch.Value = false;
            }
            else
            {
                DecryptToggleSwitch.Value = true;
            }
        }

        private void DecryptToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (DecryptToggleSwitch.Value == true)
            {
                EncryptToggleSwitch.Value = false;
            }
            else
            {
                EncryptToggleSwitch.Value = true;
            }
        }

        private void EncDecButton_Click(object sender, EventArgs e)
        {


            try{

                if (StringTextEditor.Text != "" && passwordTextBox.Text != "")
                {

                   

                    if (EncryptToggleSwitch.Value == true)
                    {
                        // Encrypt
                        ezcrypt1.Reset();
                        ezcrypt1.CipherMode = (EzcryptCipherModes)cipherModeMenu.SelectedIndex;
                        ezcrypt1.PaddingMode = (EzcryptPaddingModes)PaddingModeDropDownList.SelectedIndex;
                        ezcrypt1.KeyPassword = passwordTextBox.Text;
                        ezcrypt1.Key = secret_key_1_TextBox.Text;
                        var myBufferKeyB = new byte[20];
                        myBufferKeyB = ASCIIEncoding.ASCII.GetBytes(secret_key_2_TextBox.Text.Substring(3));
                        ezcrypt1.KeyB = myBufferKeyB;
                        ezcrypt1.UseHex = true;


                        ezcrypt1.InputMessage = StringTextEditor.Text;
                        ezcrypt1.Encrypt();
                        string encblowfish = ezcrypt1.OutputMessage;
                        ResultTextEditor.Text = encblowfish;



                        this.radDesktopAlert1.CaptionText = "Abdal Blowfish Encryption";
                        this.radDesktopAlert1.ContentText = "Encryption has been successful.";
                        this.radDesktopAlert1.Show();


                    }
                    else
                    {
                        // Now decrypt:

                        // Encrypt
                        ezcrypt1.Reset();
                        ezcrypt1.CipherMode = (EzcryptCipherModes)cipherModeMenu.SelectedIndex;
                        ezcrypt1.PaddingMode = (EzcryptPaddingModes)PaddingModeDropDownList.SelectedIndex;
                        ezcrypt1.KeyPassword = passwordTextBox.Text;
                        ezcrypt1.Key = secret_key_1_TextBox.Text;
                        var myBufferKeyB = new byte[20];
                        myBufferKeyB = ASCIIEncoding.ASCII.GetBytes(secret_key_2_TextBox.Text.Substring(3));
                        ezcrypt1.KeyB = myBufferKeyB;
                        ezcrypt1.UseHex = true;


                        ezcrypt1.InputMessage = StringTextEditor.Text;
                        ezcrypt1.Decrypt();
                        string encblowfish = ezcrypt1.OutputMessage;
                        ResultTextEditor.Text = encblowfish;

                        this.radDesktopAlert1.CaptionText = "Abdal Blowfish Encryption";
                        this.radDesktopAlert1.ContentText = "Decryption has been successful.";
                        this.radDesktopAlert1.Show();

                    }

                }
                else
                {
                    MessageBox.Show("The String and Secret Password fields must be filled");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            
           

            


        }

        private void Abdal_2Key_Triple_DES_Builder_Load(object sender, EventArgs e)
        {
            
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string IvRandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private void randButton_Click(object sender, EventArgs e)
        {

            passwordTextBox.Text = "Pass-"+RandomString(25);

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            secret_key_1_TextBox.Text = "Key1-" + RandomString(25);
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            secret_key_2_TextBox.Text = "Key2-" + RandomString(25);
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton4_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(ResultTextEditor.Text);
            MessageBox.Show("The result value has copied to the clipboard");
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            // Encrypt
            ezcrypt1.Reset();
            ezcrypt1.CipherMode = EzcryptCipherModes.cmCBC;
            ezcrypt1.PaddingMode = EzcryptPaddingModes.pmPKCS7;
            ezcrypt1.KeyPassword = RandomString(25) ;
            ezcrypt1.Key = RandomString(35);
            var myBufferKeyB = new byte[20];
            myBufferKeyB = ASCIIEncoding.ASCII.GetBytes(RandomString(25).Substring(3));
            ezcrypt1.KeyB = myBufferKeyB;
            ezcrypt1.UseHex = true;


            ezcrypt1.InputMessage = RandomString(25);
            ezcrypt1.Encrypt();
            string encblowfish = ezcrypt1.OutputMessage;
            ResultTextEditor.Text = "$2y$10$" + encblowfish.ToLower();



            this.radDesktopAlert1.CaptionText = "Abdal Blowfish Encryption";
            this.radDesktopAlert1.ContentText = "Your Random Blowfish Salt has been created.";
            this.radDesktopAlert1.Show();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

         
    }
}
