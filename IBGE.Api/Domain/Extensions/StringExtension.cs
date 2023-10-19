namespace IBGE.Api.Domain.Extensions
{
    public static class StringExtension
    {
        public static bool IsNotNullOrEmpty(this string arg) => !string.IsNullOrEmpty(arg);
        public static bool IsEqual(this string arg, string arg2) => arg == arg2;
        public static bool IsDifferent(this string arg, string arg2) => arg != arg2;
    }
}
