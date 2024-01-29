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
    internal class TripEntityMap : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.HasOne(_ => _.Bus)
                .WithMany(_ => _.Trips)
                .HasForeignKey(_ => _.BusId);
        }
    }
}
