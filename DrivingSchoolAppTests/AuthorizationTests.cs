using System;
using NUnit.Framework;
using DrivingSchoolApp.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace Tests
{
    [TestFixture]
    public class AuthorizationTests
    {
        [Test]
        public void AdminControllerHasAttributeWithAdminRole()
        {
            var authorizeAttribute = typeof(AdminController).GetCustomAttributes(typeof(AuthorizeAttribute), true).Cast<AuthorizeAttribute>().FirstOrDefault();

            Assert.IsNotNull(authorizeAttribute);
            Assert.AreEqual("Admin", authorizeAttribute.Roles);
        }

        [Test]
        public void AttendanceControllerTeacherCanAccess()
        {
            var authorizeAttribute = typeof(AttendanceController).GetCustomAttributes(typeof(AuthorizeAttribute), true).Cast<AuthorizeAttribute>().FirstOrDefault();

            Assert.IsNotNull(authorizeAttribute);
            Assert.AreEqual("Teacher, Admin", authorizeAttribute.Roles);
        }

        [Test]
        public void ApplicationControllerHasAttributeWithAdminRole()
        {
            var authorizeAttribute = typeof(ApplicationController).GetCustomAttributes(typeof(AuthorizeAttribute), true).Cast<AuthorizeAttribute>().FirstOrDefault();

            Assert.IsNotNull(authorizeAttribute);
            Assert.AreEqual("Admin", authorizeAttribute.Roles);
        }

        [Test]
        public void LessonControllerHasAttributeWithAdminAndTeacherRoles()
        {
            var authorizeAttribute = typeof(LessonController).GetCustomAttributes(typeof(AuthorizeAttribute), true).Cast<AuthorizeAttribute>().FirstOrDefault();

            Assert.IsNotNull(authorizeAttribute);
            Assert.AreEqual("Admin, Teacher", authorizeAttribute.Roles);
        }
    }
}
