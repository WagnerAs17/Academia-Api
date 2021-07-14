using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademiaMW.Business.Helpers
{
    public static class PasswordHelper
    {
        private const int tamanhoSenha = 8; 
        public static string[] RandomChars = new string[]
        {
            PasswordCharacteristic.UpperCase,
            PasswordCharacteristic.LowerCase,
            PasswordCharacteristic.Numbers,
            PasswordCharacteristic.SpecialCharacter
        };

        public static string[] ValidationMessages = new string[]
        {
            PasswordValidateMessages.UpperCaseMessage,
            PasswordValidateMessages.LowerCaseMessage,
            PasswordValidateMessages.NumbersMessage,
            PasswordValidateMessages.SpecialCharacterMessage,
        };

        public static string GerarSenhaAutomatica()
        {
            var chars = new List<char>();
            var random = new Random(Environment.TickCount);

            for (int position = 0; position < RandomChars.Length; position++)
            {
                InsertStrongPasswordCharacteristic(chars, random, position);
            }

            for (int index = chars.Count; index < tamanhoSenha
                || chars.Distinct().Count() < 1; index++)
            {
                string rcs = RandomChars[random.Next(0, RandomChars.Length)];
                chars.Insert(random.Next(0, chars.Count),
                    rcs[random.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        private static void InsertStrongPasswordCharacteristic(List<char> chars, Random random, int position)
        {
            chars.Insert(random.Next(0, chars.Count),
                       RandomChars[position]
                       [random.Next(0, RandomChars[position].Length)]);
        }
    }
}
