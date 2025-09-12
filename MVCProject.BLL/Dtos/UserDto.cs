using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Dtos
{
    public record UserDto
    (
        string Email,
        string Password,
        string UserName,
        string FirstName,
        string LastName,
        string Specialization
    );
}
