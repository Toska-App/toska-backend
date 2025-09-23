namespace Toska.Exceptions
{
    public static class ErrorCodes
    {
        // General
        public const string ValidationError = "VALIDATION_ERROR";
        public const string ConcurrencyError = "CONCURRENCY_ERROR";
        public const string InternalServerError = "INTERNAL_SERVER_ERROR";

        // User-related
        public const string DuplicateEmail = "DUPLICATE_EMAIL";
    }
}
