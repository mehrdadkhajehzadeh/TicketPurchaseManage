using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchaseManage.EntityMaps;

namespace TicketPurchaseManage.Entity
{
    public class Bus
    {
        public HashSet<Trip> Trips = new HashSet<Trip>();

       

        public int Id { get; set; }
        public string BusName { get; set; }
        public TypeOfBus TypeOfBus { get; set; }
        public static void AddBus(string busname, TypeOfBus bustype)
        {
            var dbContext = new EFDataContext();

            var bus = new Bus()
            {
                BusName = busname,
                TypeOfBus = bustype,

            };
            dbContext.Buses.Add(bus);
            dbContext.SaveChanges();
        }

    }
    public enum TypeOfBus
    {
        vip = 1,
        normal = 2
    }
}
