namespace Toska.Utility
{
    public static class MaskingHelper
    {
        public static string MaskEmail(string email)
        {
            var parts = email.Split('@');
            if (parts.Length != 2) return email;

            var name = parts[0];
            var domain = parts[1];

            var maskedName = name.Length <= 2
                ? name[0] + "*"
                : name[0] + new string('*', name.Length - 2) + name[^1];
            return $"{maskedName}@{domain}";
        }
    }
}
