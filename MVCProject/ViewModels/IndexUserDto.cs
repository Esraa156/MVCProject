namespace MVCProject.pl.ViewModels
{
    public class IndexUserDto
    {
            public string Id { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }

            // role-specific fields
            public string? Specialization { get; set; }   // Doctor only
            public string? OfficeNumber { get; set; }     // Secretary only
        }
}
