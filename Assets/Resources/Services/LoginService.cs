namespace Assets.Resources.Services
{
    public static class LoginService
    {
        public static bool Login(string username, string password)
        {
            // TODO: Write actual code for logging in
            if (username == "eric" && password == "password")
            {
                return true;
            }

            return false;
        }
    }
}
