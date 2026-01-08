namespace DrivingSchoolApp.Models
{
    public class StudentGradesViewModel
    {
        public string StudentName {  get; set; }
        public List<int> Grades { get; set; } = new List<int>();
        public double AverageGrade { get; set; }
    }
}
