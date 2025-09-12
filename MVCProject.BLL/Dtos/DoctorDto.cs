using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Dtos
{
    public record DoctorDTO(

          string Email,
        string Password,
        string FirstName,
        string LastName,
        string Specialization,
                string UserName


);
}
