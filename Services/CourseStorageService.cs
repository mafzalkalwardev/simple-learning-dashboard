using System.Text.Json;
using SimpleLearningDashboard.Models;

namespace SimpleLearningDashboard.Services
{
    public class CourseStorageService
    {
        private readonly string filePath = "courses.json";

        // ======================
        // BASIC LOAD / SAVE
        // ======================

        public List<Course> Load()
        {
            if (!File.Exists(filePath))
                return new List<Course>();

            var json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Course>>(json)
                   ?? new List<Course>();
        }

        public void Save(List<Course> courses)
        {
            var json = JsonSerializer.Serialize(courses, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        // ======================
        // DASHBOARD HELPERS
        // ======================

        public int TotalCourses()
        {
            return Load().Count;
        }

        public int CompletedCourses()
        {
            return Load().Count(c => c.IsCompleted);
        }

        public int ProgressPercent()
        {
            int total = TotalCourses();
            if (total == 0)
                return 0;

            return (CompletedCourses() * 100) / total;
        }

        // ======================
        // COURSE ACTIONS
        // ======================

        public Course? GetById(int id)
        {
            return Load().FirstOrDefault(c => c.Id == id);
        }

        public void MarkCompleted(int id)
        {
            var courses = Load();
            var course = courses.FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                course.IsCompleted = true;
                Save(courses);
            }
        }

        public void ResetProgress()
        {
            var courses = Load();

            foreach (var c in courses)
                c.IsCompleted = false;

            Save(courses);
        }
    }
}
