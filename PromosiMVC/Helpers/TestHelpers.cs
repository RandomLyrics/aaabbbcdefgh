using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PromosiMVC.Helpers
{
    public static class TestHelpers
    {
        private static Random rnd = new Random();
        public static string GenerateCode(int size)
        {
           // Random rnd = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = input[rnd.Next(0, input.Length)];
                if (rnd.Next(0, 1) == 0)
                    Char.ToUpper(ch);
                else
                    char.ToLower(ch);
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static string GenerateText(int size)
        {
            //Random rnd = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz         ";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = input[rnd.Next(0, input.Length)];
                if (i == 0)
                    Char.ToUpper(ch);
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}