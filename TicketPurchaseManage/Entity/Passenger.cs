using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchaseManage.Entity
{
    public class Passenger
    {
        public HashSet<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

        public Passenger(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
