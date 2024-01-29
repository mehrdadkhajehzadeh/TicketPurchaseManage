using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchaseManage.Entity
{
    public class Seat
    {
        public Seat(int seatNumber,int ticketId)
        {
            SeatNumber = seatNumber;
            TicketId = ticketId;
        }

        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
