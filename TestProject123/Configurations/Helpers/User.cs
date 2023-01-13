namespace TestProject123.Configurations.Helpers
{
    public class User
    {
        public User()
        {
            Email = "gustavmanoell@gmail.com";
            EmailRegister = "gustavmanoell@gmail.com" + DateHelper.ReturnDateHours();
            InvalidEmail = "gustavotest@invalidlogin.com";
            Password = "123456";
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailRegister { get; set; }
        public string InvalidEmail { get; set; }
        public string Password { get; set; }
       //public string Name { get; internal set; }
    }
}