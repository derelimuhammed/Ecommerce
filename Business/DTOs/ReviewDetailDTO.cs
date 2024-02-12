using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ReviewDetailDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
        public UserDetailDTO User { get; set; }
        public byte RatingValue { get; set; }
    }
}
