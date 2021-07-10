namespace AcademiaMW.Business.Helpers
{
    public static class PasswordHelper
    {
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
    }
}
