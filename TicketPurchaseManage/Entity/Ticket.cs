using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchaseManage.Entity
{
    public class Ticket
    {
        public Ticket(int passengerId, TicketType ticketType)
        {
            PassengerId = passengerId;
            this.ticketType = ticketType;
        }

        public HashSet<Seat> seats { get; set; }=new HashSet<Seat>();
        public int Id { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public Passenger Passenger { get; set;}
        public int PassengerId { get; set; }
        public TicketType ticketType { get; set; }
        public void AddSeat(Seat seat)
        {
            seats.Add(seat);
        }
    }
    public enum TicketType
    {
        Reserved=1,
        Boughth,
    }
}
