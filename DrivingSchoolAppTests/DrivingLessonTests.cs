using NUnit.Framework;
using DrivingSchoolApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tests
{
    [TestFixture]
    public class DrivingLessonTests
    {
        [Test]
        public void CanAddDrivingLesson()
        {
            using var context = TestHelpers.TestDbContextFactory.Create();

            var student = new Student
            {
                Surname = "Сидоров",
                Name = "Владимир"
            };

            var instructor = new Instructor
            {
                Surname = "Смирнов",
                Name = "Иван",
                DriverLicense = "0123456789"
            };

            context.Students.Add(student);
            context.Instructors.Add(instructor);
            context.SaveChanges();

            var lesson = new DrivingLesson
            {
                StudentId = student.Id,
                InstructorId = instructor.Id,
                Date = DateTime.Now,
                Grade = 4
            };

            context.DrivingLessons.Add(lesson);
            context.SaveChanges();

            var savedLesson = context.DrivingLessons.First();

            Assert.AreEqual(student.Id, savedLesson.StudentId);
            Assert.AreEqual(instructor.Id, savedLesson.InstructorId);
        }

        [Test]
        public void GradeMustBeInRange()
        {
            var lesson = new DrivingLesson
            {
                Grade = 6
            };

            var validationContext = new ValidationContext(lesson);
            var results = new System.Collections.Generic.List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(lesson, validationContext, results, validateAllProperties: true);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void CollectAllStudentGrades()
        {
            var student = new Student
            {
                Surname = "Андреев",
                Name = "Андрей"
            };

            var lessons = new List<DrivingLesson>
            {
                new DrivingLesson{ Grade = 5 },
                new DrivingLesson{ Grade = 4 },
                new DrivingLesson{ Grade = 3 }
            }; 

            var grades = lessons.Where(l => l.Grade.HasValue).GroupBy(l => l.Student).First().Select(l => l.Grade.Value).ToList();

            Assert.AreEqual(3, grades.Count);
            CollectionAssert.AreEquivalent(new[] {5, 4, 3}, grades);
        }

        [Test]
        public void CalculateAverage()
        {
            var student = new Student
            {
                Surname = "Александров",
                Name = "Александр"
            };

            var lessons = new List<DrivingLesson>
            {
                new DrivingLesson{ Grade = 5 },
                new DrivingLesson{ Grade = 4 },
                new DrivingLesson{ Grade = 3 }
            };

            var average = lessons.Where(l => l.Grade.HasValue).GroupBy(l => l.Student).First().Average(l => l.Grade.Value);

            Assert.AreEqual(4.0, average);
        }
    }
}
