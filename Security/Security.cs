namespace dog7.Security
{

    public class ChangePasswordModel
    {
        public string userId { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
    }//ec

    public class SignInModel
    {
        public string email { get; set; }

        public string password { get; set; }
        public bool rememberMe { get; set; }
    }//ec

}//en