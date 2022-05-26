using BugTracker.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models {
    public static class SeedData {
        public static async Task Initialize(IServiceProvider serviceProvider) {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            List<string> roles = new() {
                "Admin",
                "Project Manager",
                "Developer",
                "Submitter"
            };

            if (!context.Roles.Any()) {
                foreach (var role in roles) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any()) {
                User admin = new() {
                    UserName = "admin@bug-tracker.com",
                    Email = "admin@bug-tracker.com",
                    NormalizedEmail = "ADMIN@BUG-TRACKER.COM",
                    NormalizedUserName = "ADMIN@BUG-TRACKER.COM",
                    EmailConfirmed = true
                };

                User projectManager = new() {
                    UserName = "projectmanager@bug-tracker.com",
                    Email = "projectmanager@bug-tracker.com",
                    NormalizedEmail = "PROJECTMANAGER@BUG-TRACKER.COM",
                    NormalizedUserName = "PROJECTMANAGER@BUG-TRACKER.COM",
                    EmailConfirmed = true
                };

                User developer = new() {
                    UserName = "developer@bug-tracker.com",
                    Email = "developer@bug-tracker.com",
                    NormalizedEmail = "DEVELOPER@BUG-TRACKER.COM",
                    NormalizedUserName = "DEVELOPER@BUG-TRACKER.COM",
                    EmailConfirmed = true
                };

                User submitter = new() {
                    UserName = "submitter@bug-tracker.com",
                    Email = "submitter@bug-tracker.com",
                    NormalizedEmail = "SUBMITTER@BUG-TRACKER.COM",
                    NormalizedUserName = "SUBMITTER@BUG-TRACKER.COM",
                    EmailConfirmed = true
                };

                User guestUser = new() {
                    UserName = "guest@bug-tracker.com",
                    Email = "guest@bug-tracker.com",
                    NormalizedEmail = "GUEST@BUG-TRACKER.COM",
                    NormalizedUserName = "GUEST@BUG-TRACKER.COM",
                    EmailConfirmed = true
                };

                var passwordHasher = new PasswordHasher<User>();
                var adminPassword = passwordHasher.HashPassword(admin, "Password1!");
                admin.PasswordHash = adminPassword;

                var projectManagerPassword = passwordHasher.HashPassword(projectManager, "Password1!");
                projectManager.PasswordHash = projectManagerPassword;

                var developerPassword = passwordHasher.HashPassword(developer, "Password1!");
                developer.PasswordHash = developerPassword;

                var submitterPassword = passwordHasher.HashPassword(submitter, "Password1!");
                submitter.PasswordHash = submitterPassword;

                var guestPassword = passwordHasher.HashPassword(guestUser, "");
                guestUser.PasswordHash = guestPassword;

                await userManager.CreateAsync(admin);
                await userManager.CreateAsync(projectManager);
                await userManager.CreateAsync(developer);
                await userManager.CreateAsync(submitter);
                await userManager.CreateAsync(guestUser);

                await userManager.AddToRoleAsync(admin, "Admin");
                await userManager.AddToRoleAsync(guestUser, "Admin");
                await userManager.AddToRoleAsync(projectManager, "Project Manager");
                await userManager.AddToRoleAsync(developer, "Developer");
                await userManager.AddToRoleAsync(submitter, "Submitter");
            }

            if (!context.TicketPriorities.Any()) {
                TicketPriority low = new() {
                    Name = TicketPriorityName.Low
                };

                TicketPriority medium = new() {
                    Name = TicketPriorityName.Medium
                };

                TicketPriority high = new() {
                    Name = TicketPriorityName.High
                };

                await context.TicketPriorities.AddAsync(low);
                await context.TicketPriorities.AddAsync(medium);
                await context.TicketPriorities.AddAsync(high);
            }

            if (!context.TicketStatuses.Any()) {
                TicketStatus unassigned = new() {
                    Name = TicketStatusName.Unassigned
                };

                TicketStatus assigned = new() {
                    Name = TicketStatusName.Assigned
                };

                TicketStatus inProgress = new() {
                    Name = TicketStatusName.InProgress
                };

                TicketStatus completed = new() {
                    Name = TicketStatusName.Completed
                };

                await context.TicketStatuses.AddAsync(unassigned);
                await context.TicketStatuses.AddAsync(assigned);
                await context.TicketStatuses.AddAsync(inProgress);
                await context.TicketStatuses.AddAsync(completed);
            }

            if (!context.TicketTypes.Any()) {
                TicketType incident = new() {
                    Name = TicketTypeName.Incident
                };

                TicketType serviceRequest = new() {
                    Name = TicketTypeName.ServiceRequest
                };

                TicketType informationRequest = new() {
                    Name = TicketTypeName.InformationRequest
                };

                await context.TicketTypes.AddAsync(incident);
                await context.TicketTypes.AddAsync(serviceRequest);
                await context.TicketTypes.AddAsync(informationRequest);
            }

            await context.SaveChangesAsync();
        }
    }
}
