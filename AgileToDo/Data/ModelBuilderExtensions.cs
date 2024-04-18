using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AgileToDo.Models;

namespace AgileToDo.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var password = "Test@123";
            var passwordHasher = new PasswordHasher<IdentityUser>();


            // seed roles 
            var adminRole = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
            var managerRole = new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" };
            var csRole = new IdentityRole { Name = "CS", NormalizedName = "CS" };
            var userRole = new IdentityRole { Name = "User", NormalizedName = "USER" };

            List<IdentityRole> roles = [adminRole, managerRole, csRole, userRole];
            
            
            
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // seed users
            var adminUser = new IdentityUser
            {
                UserName = "admin@agiletodo.com",
                Email = "admin@agiletodo.com",
                EmailConfirmed = true,
            };
            
            var managerUser = new IdentityUser
            {
                UserName = "manager@agiletodo.com",
                Email = "manager@agiletodo.com",
                EmailConfirmed = true,
            };
     
            var csUser = new IdentityUser
            {
                UserName = "cs@agiletodo.com",
                Email = "cs@agiletodo.com",
                EmailConfirmed = true,
            };
    
            var userUser = new IdentityUser
            {
                UserName = "user@agiletodo.com",
                Email = "user@agiletodo.com",
                EmailConfirmed = true,
            };
            
            List<IdentityUser> users = [adminUser, managerUser, csUser, userUser];

            foreach (var user in users)
            {
                user.NormalizedUserName = user.UserName?.ToUpper();
                user.NormalizedEmail = user.Email?.ToUpper();
                user.PasswordHash = passwordHasher.HashPassword(user, password);
            }

            modelBuilder.Entity<IdentityUser>().HasData(users);



            // seed userroles
            var adminUserRole = new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };

            var managerUserRole = new IdentityUserRole<string>
            {
                UserId = managerUser.Id,
                RoleId = managerRole.Id
            };

            var csUserRole = new IdentityUserRole<string>
            {
                UserId = csUser.Id,
                RoleId = csRole.Id
            };

            var userUserRole = new IdentityUserRole<string>
            {
                UserId = userUser.Id,
                RoleId = userRole.Id
            };

            List<IdentityUserRole<string>> userRoles = [adminUserRole, managerUserRole, csUserRole, userUserRole];

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);


            // seed tickets
            List<IssueModel> tickets = [
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Software Installation Failure",
                    Description = "User encounters errors or issues while trying to install new software on their computer. This could be due to compatibility issues, insufficient disk space, or corrupted installation files.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Email Configuration Problems",
                    Description = "User is having trouble setting up their email account on their computer or mobile device. They may be experiencing issues with incoming or outgoing mail, authentication errors, or incorrect server settings.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Data Loss or Corruption",
                    Description = "User's files or documents have gone missing or become corrupted. This could be due to accidental deletion, hardware failure, or malware infection.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Blue Screen of Death (BSOD)",
                    Description = "Computer crashes and displays a blue screen error message, indicating a serious system error. This could be caused by hardware issues, driver conflicts, or software bugs.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Web Browser Issues",
                    Description = "User is experiencing problems with their web browser, such as slow performance, frequent crashes, or unexpected behavior (e.g., pop-up ads, redirects).",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Security Breach or Virus Infection",
                    Description = "Computer or network has been compromised by malware, ransomware, or a security breach. Users may notice unusual behavior, unauthorized access, or files being encrypted.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Hardware Failure",
                    Description = "Component of the computer hardware (e.g., hard drive, RAM, graphics card) has failed, resulting in system instability, data loss, or inability to boot up.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Password Reset Request",
                    Description = "User requests a password reset for their account due to forgetting their current password or security concerns.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Network Connectivity Issues",
                    Description = "User is experiencing problems with network connectivity, such as intermittent disconnections, slow speeds, or limited access to network resources.",
                    Resolved = false
                },
                new IssueModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Application Crashes",
                    Description = "User's application keeps crashing or freezing during use, making it difficult to work efficiently.",
                    Resolved = false
                }
                ];


            DateTime start = DateTime.Now.AddDays(-14);
            Random random = new Random();
            
            foreach (var ticket in tickets)
                {
                var createdAt = start.AddDays(random.Next(14)).AddHours(random.Next(24)).AddMinutes(random.Next(60));
                var deadline = createdAt.AddDays(random.Next(14)).AddHours(random.Next(24)).AddMinutes(random.Next(60));

                ticket.CreatedAt = createdAt;
                ticket.Deadline = deadline;
                }

            modelBuilder.Entity<IssueModel>().HasData(tickets);
        }
    }
}





