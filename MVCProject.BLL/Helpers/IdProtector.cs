using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Helpers
{
    public class IdProtector
    {
        private readonly IDataProtector _protector;

        public IdProtector(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("DoctorIdProtection");
        }

        public string Protect(string id)
        {
            return _protector.Protect(id);
        }

        public string Unprotect(string protectedId)
        {
            return _protector.Unprotect(protectedId);
        }
    }
}