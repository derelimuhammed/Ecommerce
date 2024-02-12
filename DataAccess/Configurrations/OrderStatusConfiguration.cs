using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.Property(x => x.Status).IsRequired();
            builder.HasData(new OrderStatus { Id = Guid.NewGuid(), OderStatus = "Processing",CreatedBy="system",CreatedDate=DateTime.Now }, new OrderStatus { Id = Guid.NewGuid(), OderStatus = "Shipped",CreatedBy="system",CreatedDate=DateTime.Now }, new OrderStatus { Id = Guid.NewGuid(), OderStatus = "Completed",CreatedBy="system",CreatedDate=DateTime.Now });
        }
    }
}
