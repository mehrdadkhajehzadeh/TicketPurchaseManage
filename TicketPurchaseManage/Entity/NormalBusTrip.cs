using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchaseManage.EntityMaps;

namespace TicketPurchaseManage.Entity
{
    public class NormalBusTrip : Trip
    {
        public NormalBusTrip(string tripOrigin, string tripDestination, decimal ticketPrice, int capacity, int emptySeat, int busId) : base(tripOrigin, tripDestination, ticketPrice, capacity, emptySeat, busId)
        {
        }

        public override void BookTicket()
        {
            throw new NotImplementedException();
        }

        public override void BuyTicket()
        {
            throw new NotImplementedException();
        }

        public override void ShowTripDetails()
        {
            Console.WriteLine($"" +
             $"Type of Bus {Bus.TypeOfBus}, " +
             $"Name of Bus {Bus.BusName}, " +
             $"Origin : {TripOrigin}, " +
             $"Destination : {TripDestination}, " +
             $"price of trip : {TicketPrice}");
        }
        public override void ShowSeat()
        {
            var seatNumber = 1;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (seatNumber == 22 || seatNumber == 24)
                    {
                        Console.Write(seatNumber + " ");
                        seatNumber++;
                        Console.WriteLine();
                    }
                    else
                    {
                        if (j == 3 && seatNumber != 23 && seatNumber != 25)
                        {
                            Console.Write("  ");
                        }
                        if (seatNumber < 10)
                        {
                            Console.Write("0" + seatNumber + " ");
                            seatNumber++;
                        }
                        else
                        {
                            Console.Write(seatNumber + " ");
                            seatNumber++;
                        }
                    }
                }
                Console.WriteLine();
            }
        } 

    }
}
