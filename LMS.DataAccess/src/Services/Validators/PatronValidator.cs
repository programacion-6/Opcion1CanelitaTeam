using LMS.DataAccess.Systems.Entities.User;

namespace LMS.DataAccess.Services.Validators
{
    public class PatronValidator
    {
        private const int MIN_NAME_LENGTH = 3;
        private const int MAX_NAME_LENGTH = 50;
        private const int PHONE_NUMBER_LENGTH = 10;
        private const int MEMBERSHIP_NUMBER_LENGTH = 6;
        private const int MIN_PASSWORD_LENGTH = 6;

        public bool ValidatePatron(Patron patron)
        {
            return ValidateName(patron.getName()) &&
                   ValidateMembershipNumber(patron.getMemberShipNumber()) &&
                   ValidatePhoneNumber(patron.getPhoneNumber()) &&
                   ValidateDirection(patron.getDirection()) &&
                   ValidatePassword(patron.getPassword());
        }

        public bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= MIN_NAME_LENGTH && name.Length <= MAX_NAME_LENGTH;
        }

        public bool ValidateMembershipNumber(int membershipNumber)
        {
            return membershipNumber.ToString().Length == MEMBERSHIP_NUMBER_LENGTH && membershipNumber > 0;
        }

        public bool ValidatePhoneNumber(int phoneNumber)
        {
            return phoneNumber.ToString().Length == PHONE_NUMBER_LENGTH && phoneNumber > 0;
        }

        public bool ValidateDirection(string direction)
        {
            return !string.IsNullOrEmpty(direction);
        }

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < MIN_PASSWORD_LENGTH)
                return false;

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);

            return hasUpperCase && hasDigit;
        }

        public bool ValidateUpdateParameters(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
        {
            return ValidateName(name) &&
                   (newName == null || ValidateName(newName)) &&
                   (newMembershipNumber == null || ValidateMembershipNumber(newMembershipNumber.Value)) &&
                   (newPhoneNumber == null || ValidatePhoneNumber(newPhoneNumber.Value)) &&
                   (newDirection == null || ValidateDirection(newDirection)) &&
                   (newPassword == null || ValidatePassword(newPassword));
        }
    }
}
