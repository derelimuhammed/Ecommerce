using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ConfirmEmailDTO : IDto
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
