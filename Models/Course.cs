namespace SimpleLearningDashboard.Models
{
    public class Course
    {
        // Existing fields (DO NOT REMOVE)
        public string Name { get; set; } = "";
        public string UserEmail { get; set; } = "";

        public string NewLesson { get; set; } = "";
        public List<Lesson> Lessons { get; set; } = new();

        // ✅ NEW FIELDS (for dashboard & progress)
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public bool IsCompleted { get; set; }
    }
}
