using BugTracker.DAL;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker_UnitTesting
{
    [TestClass]
    public class UserBLL_UnitTesting
    {
        [TestMethod]
        public void TestMethod1()
        {

            var data = new List<User> {
                new() {
                    UserName = "admin@bug-tracker.com",
                    Email = "admin@bug-tracker.com",
                    NormalizedEmail = "ADMIN@BUG-TRACKER.COM",
                    NormalizedUserName = "ADMIN@BUG-TRACKER.COM",
                    EmailConfirmed = true
                },
                new() {
                    UserName = "projectmanager@bug-tracker.com",
                    Email = "projectmanager@bug-tracker.com",
                    NormalizedEmail = "PROJECTMANAGER@BUG-TRACKER.COM",
                    NormalizedUserName = "PROJECTMANAGER@BUG-TRACKER.COM",
                    EmailConfirmed = true
                }, new() {
                    UserName = "developer@bug-tracker.com",
                    Email = "developer@bug-tracker.com",
                    NormalizedEmail = "DEVELOPER@BUG-TRACKER.COM",
                    NormalizedUserName = "DEVELOPER@BUG-TRACKER.COM",
                    EmailConfirmed = true
                }, new() {
                    UserName = "submitter@bug-tracker.com",
                    Email = "submitter@bug-tracker.com",
                    NormalizedEmail = "SUBMITTER@BUG-TRACKER.COM",
                    NormalizedUserName = "SUBMITTER@BUG-TRACKER.COM",
                    EmailConfirmed = true
                }, new() {
                    UserName = "guest@bug-tracker.com",
                    Email = "guest@bug-tracker.com",
                    NormalizedEmail = "GUEST@BUG-TRACKER.COM",
                    NormalizedUserName = "GUEST@BUG-TRACKER.COM",
                    EmailConfirmed = true
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var userRepository = new Mock<IRepository<User>>();
            userRepository.Setup(x => x.GetList(_ => true)).Returns((List<User>)data);

            // var service = new UserBusinessLogicLayer(userRepository);
        }
    }
}
