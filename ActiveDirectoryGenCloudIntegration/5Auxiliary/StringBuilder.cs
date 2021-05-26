using System;
using System.Collections.Generic;
using System.Text;

namespace CircleK_GenesysCloudUpdate._5Auxiliary
{
    class StringBuilder
    {
        // Builds random string for use in externalID
        public static string runsStringBuilder()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[4];
            Random random = new Random();


            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(stringChars);

            return finalString;
        }
    }
}
