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
    internal class TicketEntityMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.HasOne(_ => _.Passenger)
                .WithMany(_ => _.Tickets)
                .HasForeignKey(_ => _.PassengerId);

        }
    }
}
