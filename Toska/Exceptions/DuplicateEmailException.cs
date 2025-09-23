using Toska.Utility;

namespace Toska.Exceptions
{
    public class DuplicateEmailException : BusinessException
    {
        public string Email { get; }

        public DuplicateEmailException(string email) : 
            base(
                message:$"Email '{MaskingHelper.MaskEmail(email)}' is already in use.", 
                userMessage: "This email is already registered. Please try another.", 
                StatusCodes.Status400BadRequest, 
                ErrorCodes.DuplicateEmail)
        {
            Email = email;
        }
    }
}
