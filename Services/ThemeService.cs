namespace SimpleLearningDashboard.Services
{
    public class ThemeService
    {
        public bool IsDark { get; private set; }

        public event Action? OnThemeChanged;

        public void ToggleTheme()
        {
            IsDark = !IsDark;
            OnThemeChanged?.Invoke();
        }
    }
}
