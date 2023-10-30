﻿namespace OQPATE.API.common
{
    public static class Common
    {
        
    }

    public static class Utility
    {
        public static string GetSalt()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(1000000, 9999999);
            return myRandomNo.ToString("X").ToLower();
        }

        public static string HashString(string text, string salt = "")
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            // Uses SHA256 to create the hash
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
    }
}