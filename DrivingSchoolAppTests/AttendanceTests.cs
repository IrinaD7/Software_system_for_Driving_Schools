using NUnit.Framework;
using DrivingSchoolApp.Models;
using System;

namespace Tests
{
    [TestFixture]
    public class AttendanceTests
    {
        [Test]
        public void CountMissedLessons()
        {
            var student = new Student
            {
                Surname = "Алексеев",
                Name = "Алексей"
            };

            var attendances = new List<Attendance>
            {
                new Attendance {
                    Student = student,
                    IsPresent = true
                },
                new Attendance {
                    Student = student,
                    IsPresent = false
                },
                new Attendance {
                    Student = student, 
                    IsPresent = false
                }
            };

            int missed = attendances.Where(a => a.Student == student && !a.IsPresent).Count();

            Assert.AreEqual(2, missed);
        }

        [Test]
        public void AttendanceSavedCorrectly()
        {
            var student = new Student
            {
                Surname = "Георгиев",
                Name = "Георгий"
            };

            var lesson = new Lesson();

            var attendance = new Attendance
            {
                Student = student,
                Lesson = lesson,
                IsPresent = false
            };

            Assert.IsFalse(attendance.IsPresent);
            Assert.AreEqual(student, attendance.Student);
        }

        [Test]
        public void AttendanceReportByGroup()
        {
            var group1 = new StudyGroup
            {
                Id = 1,
                Name = "A",
            };

            var group2 = new StudyGroup
            {
                Id = 2,
                Name = "B"
            };

            var student1 = new Student
            {
                Group = group1
            };

            var student2 = new Student
            {
                Group = group2
            };

            var attendances = new List<Attendance>
            {
                new Attendance {
                    Student = student1,
                    IsPresent = true
                },
                new Attendance {
                    Student = student1,
                    IsPresent = false
                },
                new Attendance {
                    Student = student2,
                    IsPresent = false
                }
            };

            var reportForGroup1 = attendances.Where(a => a.Student.Group == group1).ToList();

            Assert.AreEqual(2, reportForGroup1.Count());
        }
    }
}
