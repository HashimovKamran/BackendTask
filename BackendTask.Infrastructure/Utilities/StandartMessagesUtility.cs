namespace BackendTask.Infrastructure.Utilities
{
    public static class StandartMessagesUtility
    {
        public static string DuplicateDetails { get { return "Duplicate country or city"; } }
        public static string NotFound { get { return "Not found country or city"; } }
        public static string Exception { get { return "Something went wrong"; } }
        public static string Added { get { return "Successfully added"; } }
        public static string Updated { get { return "Successfully updated"; } }
        public static string Deleted { get { return "Successfully deleted"; } }

        public static string DuplicateSignUpDetails { get { return "Duplicate email"; } }
        public static string SignIn { get { return "Successfully sign in"; } }
        public static string SignUp { get { return "Successfully sign up"; } }
        public static string InvalidCredentials { get { return "Email or password you entered is incorrect"; } }
    }
}
