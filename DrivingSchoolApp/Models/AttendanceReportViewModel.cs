namespace DrivingSchoolApp.Models
{
    public class AttendanceReportViewModel
    {
        public int GroupId { get; set; }
        public string GroupName {  get; set; }
        public List<StudentAttendanceSummary> Students { get; set; } = new();
    }

    public class StudentAttendanceSummary
    {
        public string StudentName { get; set; }
        public int MissedCount { get; set; }
    }
}
