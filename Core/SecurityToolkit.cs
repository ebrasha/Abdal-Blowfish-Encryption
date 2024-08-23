using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abdal_Security_Group_App.Core
{
    internal class SecurityToolkit
    {
        public static string GeneratePassword(
            int length = 25,
            bool includeUppercase = true,
            bool includeLowercase = true,
            bool includeNumbers = true,
            bool includeSpecialCharacters = true)
        {
            try
            {
                if (length <= 0)
                    throw new ArgumentException("Length must be greater than zero.");

                string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lowercase = "abcdefghijklmnopqrstuvwxyz";
                string numbers = "0123456789";
                string specialCharacters = "!@#$%^&*()_-+=<>?";

                StringBuilder characterSet = new StringBuilder();

                if (includeUppercase)
                    characterSet.Append(uppercase);
                if (includeLowercase)
                    characterSet.Append(lowercase);
                if (includeNumbers)
                    characterSet.Append(numbers);
                if (includeSpecialCharacters)
                    characterSet.Append(specialCharacters);

                if (characterSet.Length == 0)
                    throw new ArgumentException("At least one character type must be selected.");

                StringBuilder password = new StringBuilder();
                Random random = new Random();

                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(characterSet.Length);
                    password.Append(characterSet[index]);
                }

                return password.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }


        public static string GenerateTwofishEncryptionKey(
            int bitLength = 256,
            bool includeUppercase = true,
            bool includeLowercase = true,
            bool includeNumbers = true,
            bool includeSpecialCharacters = true)
        {
            try
            {
                // Validate bitLength to be either 128, 192, or 256
                if (bitLength != 128 && bitLength != 192 && bitLength != 256)
                    throw new ArgumentException("Bit length must be 128, 192, or 256.");

                // Calculate the number of bytes based on the bit length
                int byteLength = bitLength / 8;

                string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lowercase = "abcdefghijklmnopqrstuvwxyz";
                string numbers = "0123456789";
                string specialCharacters = "!@#$%^&*()_-+=<>?";

                StringBuilder characterSet = new StringBuilder();

                if (includeUppercase)
                    characterSet.Append(uppercase);
                if (includeLowercase)
                    characterSet.Append(lowercase);
                if (includeNumbers)
                    characterSet.Append(numbers);
                if (includeSpecialCharacters)
                    characterSet.Append(specialCharacters);

                if (characterSet.Length == 0)
                    throw new ArgumentException("At least one character type must be selected.");

                StringBuilder encryptionKey = new StringBuilder();
                Random random = new Random();

                for (int i = 0; i < byteLength; i++)
                {
                    int index = random.Next(characterSet.Length);
                    encryptionKey.Append(characterSet[index]);
                }

                return encryptionKey.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

    }
}