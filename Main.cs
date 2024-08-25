using Abdal_Security_Group_App.Core;
using System.Diagnostics;
using System.Reflection;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace Abdal_Security_Group_App
{
    public partial class Main : Telerik.WinControls.UI.RadForm
    {
        private bool stop_op_status = false;
        private string abdal_app_name = Assembly.GetExecutingAssembly().GetName().ToString().Split(',')[0];
        private AbdalSoundPlayer ab_player = new AbdalSoundPlayer();

        private string abdal_app_name_for_url = Assembly.GetExecutingAssembly().GetName().ToString().Split(',')[0]
            .ToLower().Replace(' ', '-');

        private RawText RawtextForm = new RawText();
        private EncText EncTextForm = new EncText();


        public Main()
        {
            InitializeComponent();
            //change form title
            Version version = Assembly.GetExecutingAssembly().GetName().Version!;
            Text = abdal_app_name + " " + version.Major + "." + version.Minor;

            // Call Global Chilkat Unlock
            ChilkatMng.UnlockChilkat();
        }

        #region Dragable Form Start

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        #endregion

        private async void Main_Load(object sender, EventArgs e)
        {
            // change KeyLengthList items

            if (EncryptionAlgorithmList.SelectedItem.Text == "blowfish2")
            {
                KeyLengthList.Items.Clear();
                for (int i = 32; i <= 448; i += 8)
                {
                    KeyLengthList.Items.Add(i.ToString());
                    KeyLengthList.Text = i.ToString();
                }
            }
            else
            {
                KeyLengthList.Items.Clear();
                // KeyLengthList.Items.Add("128");
                // KeyLengthList.Items.Add("192");
                KeyLengthList.Items.Add("256");
                KeyLengthList.Text = "256";
            }


            await UpdateChecker.CheckForUpdateAsync();
        }

        private void menuItem_github_Click(object sender, EventArgs e)
        {
            ab_player.sPlayer("checkbox");
            Process.Start(new ProcessStartInfo("https://github.com/ebrasha/" + abdal_app_name_for_url)
                { UseShellExecute = true });
        }

        private void menuItem_gitlab_Click(object sender, EventArgs e)
        {
            ab_player.sPlayer("checkbox");
            Process.Start(new ProcessStartInfo("https://gitlab.com/Prof.Shafiei/" + abdal_app_name_for_url)
                { UseShellExecute = true });
        }

        private void menuItem_donate_Click(object sender, EventArgs e)
        {
        }

        private void menuItem_about_us_Click(object sender, EventArgs e)
        {
            ab_player.sPlayer("checkbox");
            about_us about_form = new Abdal_Security_Group_App.about_us();
            about_form.ShowDialog();
            about_form.TopMost = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ab_player.sPlayer("checkbox");
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }

        private void bg_worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.desk_alert.CaptionText = abdal_app_name;
                this.desk_alert.ContentText = "Canceled Process By User!";
                this.desk_alert.Show();
                ab_player.sPlayer("cancel");
            }
            else if (e.Error != null)
            {
                this.desk_alert.CaptionText = abdal_app_name;
                this.desk_alert.ContentText = e.Error.Message;
                this.desk_alert.Show();


                ab_player.sPlayer("error");
            }
            else
            {
                this.desk_alert.CaptionText = abdal_app_name;
                this.desk_alert.ContentText = "Done!";
                this.desk_alert.Show();

                if (stop_op_status)
                {
                    ab_player.sPlayerSync("cancel");
                }
                else
                {
                    ab_player.sPlayerSync("op-com");
                }

                ab_player.sPlayer("done");
            }
        }

        public bool ValidateInputs()
        {
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(EncryptionAlgorithmList.Text))
            {
                MessageBox.Show("Encryption Algorithm must not be empty.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(EncodingModeList.Text))
            {
                MessageBox.Show("Encoding Mode must not be empty.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(KeyLengthList.Text))
            {
                MessageBox.Show("Key Length must not be empty.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(CipherModeList.Text))
            {
                MessageBox.Show("Cipher Mode must not be empty.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(SecretKeyTextBox.Text))
            {
                MessageBox.Show("Secret Key must not be empty.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                hasError = true;
            }

            if (SwitchOperation.Value)
            {
                if (string.IsNullOrWhiteSpace(RawtextForm.GetRawText()))
                {
                    MessageBox.Show("Raw Text must not be empty.", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    hasError = true;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(EncTextForm.GetEncText()))
                {
                    MessageBox.Show("Raw Text must not be empty.", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }


            return hasError;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                if (bg_worker.IsBusy != true)
                {
                    bg_worker.RunWorkerAsync();
                }
            }
            else
            {
                ab_player.sPlayer("error");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void irDonationBtn_Click(object sender, EventArgs e)
        {
            ab_player.sPlayer("coin");
            Process.Start(new ProcessStartInfo("https://alphajet.ir/abdal-donation") { UseShellExecute = true });
        }

        private void EnDonationBtn_Click(object sender, EventArgs e)
        {
            ab_player.sPlayer("coin");
            Process.Start(new ProcessStartInfo("https://ebrasha.com/abdal-donation") { UseShellExecute = true });
        }

        private void EncryptionAlgorithmList_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void EncryptionAlgorithmList_SelectedIndexChanged(object sender,
            Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (EncryptionAlgorithmList.SelectedItem.Text == "blowfish2")
            {
                KeyLengthList.Items.Clear();
                for (int i = 32; i <= 448; i += 8)
                {
                    KeyLengthList.Items.Add(i.ToString());
                    KeyLengthList.Text = i.ToString();
                }
            }
            else
            {
                KeyLengthList.Items.Clear();
                // KeyLengthList.Items.Add("128");
                // KeyLengthList.Items.Add("192");
                KeyLengthList.Items.Add("256");
                KeyLengthList.Text = "256";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (EncryptionAlgorithmList.Text == "blowfish2")
            {
                SecretKeyTextBox.Text = SecurityToolkit.GeneratePassword(20);
                ab_player.sPlayer("checkbox");
                CopyToClipboard(SecretKeyTextBox.Text);
            }
            else
            {
                SecretKeyTextBox.Text =
                    SecurityToolkit.GenerateTwofishEncryptionKey(
                        int.Parse(KeyLengthList.Text),
                        true,
                        true,
                        true,
                        false);
                ab_player.sPlayer("checkbox");
                CopyToClipboard(SecretKeyTextBox.Text);
            }
        }


        public static void CopyToClipboard(string text)
        {
            try
            {
                // Copy text to clipboard
                Clipboard.SetText(text);

                // Show a message box to inform the user
                MessageBox.Show("Secret Key has been copied to clipboard.", "Clipboard Copy", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Open the new form
            ab_player.sPlayer("checkbox");
            RawtextForm.Show();

            // Now, assume this code runs when the button is clicked again
            if (RawtextForm != null && RawtextForm.Visible)
            {
                RawtextForm.BringToFront(); // Brings the form to the front
                RawtextForm.Activate(); // Activates the form (puts it on top of other forms)
            }
            else
            {
                RawtextForm = new RawText();
                RawtextForm.Show();
            }
        }

        private void bg_worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            crypt.CryptAlgorithm = EncryptionAlgorithmList.Text;
            crypt.CipherMode = CipherModeList.Text;
            crypt.KeyLength = int.Parse(KeyLengthList.Text);
            crypt.PaddingScheme = 0;
            crypt.EncodingMode = EncodingModeList.Text;
            string ivHex = "";

            if (EncryptionAlgorithmList.Text == "blowfish2")
            {
                ivHex = "0001020304050607";
            }
            else
            {
                ivHex = "000102030405060708090A0B0C0D0E0F";
            }

            crypt.SetEncodedIV(ivHex, "hex");
            string keyHex = SecretKeyTextBox.Text;
            crypt.SetEncodedKey(keyHex, "hex");

            if (SwitchOperation.Value)
            {
                // User is trying to encrypt something
                string rawText = RawtextForm.GetRawText();

                // Convert the string to a byte array using UTF-8 encoding
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(rawText);

                // Encrypt the byte array
                byte[] encryptedBytes = crypt.EncryptBytes(inputBytes);

                // Convert the encrypted bytes to a hex string for display/storage
                string encStr = crypt.Encode(encryptedBytes, "hex");
                SendEncTextToForm(encStr);
            }
            else
            {
                // User is trying to decrypt something
                string encStr = EncTextForm.GetEncText();

                // Convert the hex string back to byte array
                byte[] encryptedBytes = crypt.Decode(encStr, "hex");

                // Decrypt the byte array
                byte[] decryptedBytes = crypt.DecryptBytes(encryptedBytes);

                // Convert the decrypted byte array back to a string
                string decStr = System.Text.Encoding.UTF8.GetString(decryptedBytes);
                SetDeCryptTextToForm(decStr);
            }
        }


        public void SendEncTextToForm(string EncText)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SendEncTextToForm), new object[] { EncText });
                return;
            }

            EncTextForm.Show();
            EncTextForm.SetEncText(EncText);
        }

        public void SetDeCryptTextToForm(string RawText)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetDeCryptTextToForm), new object[] { RawText });
                return;
            }

            RawtextForm.Show();
            RawtextForm.SetDeCryptText(RawText);
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Open the new form
            ab_player.sPlayer("checkbox");
            EncTextForm.Show();

            // Now, assume this code runs when the button is clicked again
            if (EncTextForm != null && EncTextForm.Visible)
            {
                EncTextForm.BringToFront(); // Brings the form to the front
                EncTextForm.Activate(); // Activates the form (puts it on top of other forms)
            }
            else
            {
                EncTextForm = new EncText();
                EncTextForm.Show();
            }
        }
    }
}