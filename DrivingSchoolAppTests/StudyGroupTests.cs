using System;
using NUnit.Framework;
using DrivingSchoolApp.Models;
using Tests.TestHelpers;

namespace Tests
{
    [TestFixture]
    public class StudyGroupTests
    {
        [Test]
        public void GroupContainsStudents()
        {
            using var context = TestHelpers.TestDbContextFactory.Create();

            var group = new StudyGroup
            {
                Name = "Группа А"
            };

            var student1 = new Student
            {
                Surname = "Иванов",
                Name = "Иван"
            };

            var student2 = new Student
            {
                Surname = "Петров",
                Name = "Пётр"
            };

            group.Students.Add(student1);
            group.Students.Add(student2);   

            context.StudyGroups.Add(group);
            context.SaveChanges();

            var savedGroup = context.StudyGroups.First();

            Assert.AreEqual(2,savedGroup.Students.Count());
        }
    }
}
