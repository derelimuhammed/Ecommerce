using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class UserWithRolesDTO : IDto
    {
        public UserDTO User { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
