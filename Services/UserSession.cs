namespace SimpleLearningDashboard.Services
{
    public class UserSession   // ❗ NOT static
    {
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string Bio { get; set; } = "";
        public bool IsLoggedIn => !string.IsNullOrEmpty(Email);
    }
}
