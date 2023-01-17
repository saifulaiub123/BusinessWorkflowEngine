namespace BWE.Domain.Constant
{
    public static class Message
    {
        //Authentication
        public static string USER_REGISTRATION_SUCCESS = "Successflly Registered";
        public static string USER_REGISTRATION_FAILED = "Failed to register User";



        //OTP
        public static string OTP_VERIFIED = "OTP verified";
        public static string OTP_EXPIRED = "OTP expired";
        public static string OTP_VERIFICATION_FAILED = "Failed to verify OTP";



        //Throw Exception
        public static string RecordNotFound = "Record not found";

        //User Related
        public const string UserIdCannotBeNull = "User id cannot be null.";
        public const string EmailNotFound = "Email not found";


    }
}
