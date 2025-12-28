namespace DrivingSchoolApp.Models
{
	public class AttendanceViewModel
	{
		public int LessonId { get; set; }

		public List<StudentAttendanceItem> Students { get; set; } = new();
	}

	public class StudentAttendanceItem
	{
		public int StudentId { get; set; }
		public string FullName { get; set; } = string.Empty;
		public bool IsPresent { get; set; }
	}
}