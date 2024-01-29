using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchaseManage.Entity
{
    public abstract class Trip
    {
        protected Trip(string tripOrigin, string tripDestination, decimal ticketPrice,int capacity, int emptySeat , int busId)
        {
            TripOrigin = tripOrigin;
            TripDestination = tripDestination;
            TicketPrice = ticketPrice;
            BusId = busId;
            Capacity = capacity;
            EmptySeat = emptySeat;
        }

        public HashSet<Ticket> Tickets { get; set; }= new HashSet<Ticket>();


        public int Id { get; set; }
        public string TripOrigin { get; set; }
        public string TripDestination { get; set; }
        public decimal TicketPrice { get; set; }
        public int Capacity { get; set; }
        public int EmptySeat { get; set; }
        public Bus Bus { get; set; }
        public int BusId { get; set; }
        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public abstract void BookTicket();
        public abstract void BuyTicket();
        public abstract void ShowTripDetails();
        public virtual void CanceleTicket()
        {

        }
        public virtual void ShowSeat()
        { }



        }
}
