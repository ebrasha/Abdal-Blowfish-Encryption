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

namespace Abdal_Security_Group_App
{
    public partial class Abdal_AES_Encryption : Telerik.WinControls.UI.RadForm
    {
        public Abdal_AES_Encryption()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "Abdal Blowfish Encryption" + " " + version.Major + "." + version.Minor; //change form title
        }

        
        

        private void EncDecButton_Click(object sender, EventArgs e)
        {


            try{

                if (StringTextEditor.Text != "")
                {

                    Chilkat.Crypt2 crypt = new Chilkat.Crypt2();

                    if(hashModeMenu.Text == "ebrasha1")
                    {
                        crypt.HashAlgorithm = "md5";
                        crypt.EncodingMode = "hex";
                        crypt.Charset = "utf-8";
                        string hashVal1 = crypt.HashStringENC(StringTextEditor.Text);
                        crypt.HashAlgorithm = "sha1";
                        string hashVal2 = crypt.HashStringENC(StringTextEditor.Text);
                        crypt.HashAlgorithm = "sha512";
                        string hashVal3 = crypt.HashStringENC(StringTextEditor.Text);
                        crypt.HashAlgorithm = "md2";
                        string hashVal4 = crypt.HashStringENC(StringTextEditor.Text);

                        string hashVal5 = hashVal1 + hashVal2 + hashVal3 + hashVal4;
                        radBarcode1.Value = hashVal5;

                       
                        radRadialGauge1.Value = hashVal5.Length;
                        radRadialGauge2.Value = hashVal5.Length;
                        hashTextBoxResult.Text = hashVal5;

                    }
                    else if (hashModeMenu.Text == "haval")
                    {
                        crypt.EncodingMode = "hex";
                        crypt.Charset = "utf-8";
                        crypt.HashAlgorithm = "haval";
                        crypt.HavalRounds = 5;
                        crypt.KeyLength = 256;
                        string hashVal = crypt.HashStringENC(StringTextEditor.Text);
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;

                    }
                    else if(hashModeMenu.Text == "sha1" || hashModeMenu.Text == "sha1" || hashModeMenu.Text == "md2" || hashModeMenu.Text == "md4" || hashModeMenu.Text == "md5" || hashModeMenu.Text == "sha256" || hashModeMenu.Text == "sha384" || hashModeMenu.Text == "sha512" || hashModeMenu.Text == "ripemd128" || hashModeMenu.Text == "ripemd160" || hashModeMenu.Text == "ripemd256" || hashModeMenu.Text == "ripemd320")
                    {

                        crypt.HashAlgorithm = hashModeMenu.Text;
                        crypt.EncodingMode = "hex";
                        crypt.Charset = "utf-8";
                        // Other possible EncodingMode settings are: 
                        // "quoted-printable", "base64","url", and many more..

                        string hashVal = crypt.HashStringENC(StringTextEditor.Text);
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }else if (hashModeMenu.Text == "SHA-224")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA224);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }else if (hashModeMenu.Text == "SHA-256")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA256);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "SHA-384")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA384);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "SHA-512")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA512);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "MD5SHA1")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haMD5SHA1);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "HMAC-MD5")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haHMACMD5);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "HMAC-SHA1")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haHMACSHA1);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "HMAC-SHA224")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haHMACSHA224);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "HMAC-SHA256")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haHMACSHA256);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "HMAC-SHA384")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haHMACSHA384);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "HMAC-SHA512")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haHMACSHA512);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "HMAC-RIPEMD-160")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haHMACRIPEMD160);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "SHA-3-224")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA3_224);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "SHA-3-256")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA3_256);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "SHA-3-384")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA3_384);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;

                    }
                    else if (hashModeMenu.Text == "SHA-3-512")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA3_512);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "SHA-512/224")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA512_224);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else if (hashModeMenu.Text == "SHA-512/256")
                    {
                        hash1.Reset();
                        hash1.Algorithm = (HashAlgorithms.haSHA512_256);
                        hash1.EncodeHash = true;
                        hash1.InputMessage = StringTextEditor.Text;
                        hash1.ComputeHash();
                        string hashVal = hash1.HashValue;
                        radRadialGauge1.Value = hashVal.Length;
                        radRadialGauge2.Value = hashVal.Length;
                        hashTextBoxResult.Text = hashVal;
                        radBarcode1.Value = hashVal;


                    }
                    else
                    {
                        MessageBox.Show("The algorithm is not specified");

                    }
                    

                   

                }
                else
                {
                    MessageBox.Show("The String field must be filled");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            
           

            


        }

        private void Abdal_2Key_Triple_DES_Builder_Load(object sender, EventArgs e)
        {
            // Call Global Chilkat Unlock
            Abdal_Security_Group_App.GlobalUnlockChilkat GlobalUnlock = new Abdal_Security_Group_App.GlobalUnlockChilkat();
            GlobalUnlock.unlock();

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
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hashTextBoxResult.Text);
            MessageBox.Show("The hash value has copied to the clipboard");
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Png (*.png)|*.png";
            saveFileDialog1.FileName = "QRCode By Abdal Hash Builder";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = this.radBarcode1.ExportToImage();
                img.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
