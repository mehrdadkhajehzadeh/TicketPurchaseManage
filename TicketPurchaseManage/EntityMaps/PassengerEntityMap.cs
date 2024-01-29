using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchaseManage.Entity;

namespace TicketPurchaseManage.EntityMaps
{
    internal class PassengerEntityMap : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(_ => _.LastName)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        }
    }
}
