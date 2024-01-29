using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TicketPurchaseManage.Entity;
using TicketPurchaseManage.EntityMaps;
EFDataContext dbContext = new EFDataContext();
var exit = false;
while (!exit)
{
    Console.WriteLine("1.Add bus\n" +
                "2.Add travel\n" +
                "3.Preview available trips\n" +
                "4.Book ticket\n" +
                "5.Buy ticket\n" +
                "6.Cancel the ticket\n" +
                "7.A trip report\n" +
                "8.Exit\n");
    Console.Write("Choice Option : ");
    var option = Console.ReadLine();
    switch (option)
    {
        case "1":
            {

                Console.WriteLine("Enter name of Bus");
                var busName = Console.ReadLine();
                Console.WriteLine("Enter type of bus: 1.vip 2.normal");
                var busType = int.Parse(Console.ReadLine());
                Bus.AddBus(busName, (TypeOfBus)busType);
                break;
            }
        case "2":
            {
                Console.WriteLine("Enter kind of bus ");
                var tripType = Console.ReadLine()!.ToLower();
                Console.WriteLine("Enter name of bus");
                var busName = Console.ReadLine();
                var bus = dbContext.Buses.FirstOrDefault(_ => _.BusName == busName);
                if (bus == null)
                {
                    throw new Exception("bus not found");
                }
                var busId = bus.Id;
                Console.WriteLine("Enter origin");
                var origin = Console.ReadLine();
                Console.WriteLine("Enter destination");
                var destination = Console.ReadLine();
                Console.WriteLine("Enter price of trip");
                var price = decimal.Parse(Console.ReadLine()!);
                if (tripType == "normal")
                {

                    NormalBusTrip normalTrip = new NormalBusTrip(origin,destination,price,44,44,busId);

                    dbContext.Trips.Add(normalTrip);
                    dbContext.SaveChanges();
                }
                else if (tripType == "vip")
                {
                    var vipTrip = new VipBusTrip(origin, destination, price,30,30, busId);

                    dbContext.Trips.Add(vipTrip);
                    dbContext.SaveChanges();
                }
                break;
            }

        case "3":
            {
                //var trip=_db.Trips.ToList();
                var vipTrip = dbContext.Trips.OfType<VipBusTrip>().ToList();
                foreach (var item in vipTrip)
                    
                {
                    Console.WriteLine($"{item.Id} Type:VIP {item.TripDestination} {item.TripOrigin}  {item.TicketPrice} capacity: {item.Capacity}");
                }

                var normalTrip = dbContext.Trips.OfType<NormalBusTrip>().ToList();
                foreach (var item in normalTrip)

                {

                    Console.WriteLine($"{item.Id}  Type:Normal {item.TripDestination} {item.TripOrigin}  {item.TicketPrice} capacity: {item.Capacity}");
                }
                Console.WriteLine("PLease select A trip");
                var tripId=int.Parse(Console.ReadLine());
                var trip=dbContext.Trips.FirstOrDefault(_=>_.Id==tripId);
                trip.ShowSeat();//
                break;
            }
        case "4":
            {
                Console.WriteLine("PLease Enter PassengerId");
                var passengerId = int.Parse(Console.ReadLine());
                var passenger = dbContext.Passengers.FirstOrDefault(_ => _.Id == passengerId);
                if (passenger == null)
                {
                    Console.WriteLine("PLease Enter PassengerName");
                    var name = Console.ReadLine();
                    Console.WriteLine("PLease Enter PassengerFamily");
                    var family = Console.ReadLine();
                    dbContext.Passengers.Add(new Passenger(name, family));
                    dbContext.SaveChanges();
                }
                Console.WriteLine("PLease select A trip");
                var tripId = int.Parse(Console.ReadLine());
                var trip = dbContext.Trips.FirstOrDefault(_ => _.Id == tripId);
                trip.ShowSeat();//
                  var ticket = new Ticket(passengerId, TicketType.Boughth);
                trip.AddTicket(ticket);
                dbContext.SaveChanges();
                var choice = 1;
                while (choice==1)
                {
                    Console.WriteLine("PLease select a seat");
                    var seatNumber = int.Parse(Console.ReadLine());
                   var checkSeat= dbContext.Seats.FirstOrDefault(_ => _.SeatNumber == seatNumber);
                    if (checkSeat == null)
                    {

                    dbContext.Seats.Add(new Seat(seatNumber,ticket.Id));
                    dbContext.SaveChanges();
                    Console.WriteLine("Do you want to add More:1-Yes 2-No");
                    choice= int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        throw new Exception("seat has alredy booked");
                    }
                }
            }
            break;
        case "5":
            {
                Console.WriteLine("PLease Enter PassengerId");
                var passengerId = int.Parse(Console.ReadLine());
                var passenger = dbContext.Passengers.FirstOrDefault(_ => _.Id == passengerId);
                if (passenger == null)
                {
                    Console.WriteLine("PLease Enter PassengerName");
                    var name = Console.ReadLine();
                    Console.WriteLine("PLease Enter PassengerFamily");
                    var family = Console.ReadLine();
                    dbContext.Passengers.Add(new Passenger(name, family));
                    dbContext.SaveChanges();
                }
                Console.WriteLine("PLease select a trip");
                var tripId = int.Parse(Console.ReadLine());
                var trip = dbContext.Trips.FirstOrDefault(_ => _.Id == tripId);
                trip.ShowSeat();//
                var ticket = new Ticket(passengerId,TicketType.Boughth);
                trip.AddTicket(ticket);
                dbContext.SaveChanges();
                var choice = 1;
                while (choice == 1)
                {
                    Console.WriteLine("PLease select a seat");
                    var seatNumber = int.Parse(Console.ReadLine());
                    ticket.AddSeat(new Seat(seatNumber,ticket.Id));
                    dbContext.SaveChanges();
                    Console.WriteLine("Do you want to add More:1-Yes 2-No");
                    choice = int.Parse(Console.ReadLine());
                }
            }
            break;
        case "6":
            {
                Console.WriteLine("PLease Enter PassengerId");
                var passengerId = int.Parse(Console.ReadLine());
                var passenger = dbContext.Passengers.Include(t=>t.Tickets).ThenInclude(t=>t.Trip).FirstOrDefault(_ => _.Id == passengerId);
                foreach (var ticket in passenger.Tickets)
                {
                    Console.WriteLine($"Id={ticket.Id} type:{ticket.ticketType} origin:{ticket.Trip.TripOrigin} destination:{ticket.Trip.TripDestination}");
                }
                Console.WriteLine("PLease Enter TicketId");
                var ticketId = int.Parse(Console.ReadLine());
                var selectedTicket=dbContext.Tickets.FirstOrDefault(_ => _.Id == ticketId);
                var seats = dbContext.Seats.Where(_ => _.TicketId == ticketId);
                dbContext.Seats.RemoveRange(seats);
                dbContext.SaveChanges();

            }
            break;
        case "7":
            {
                var vipTrip = dbContext.Trips.OfType<VipBusTrip>().ToList();
                foreach (var item in vipTrip)

                {
                    Console.WriteLine($"{item.Id} Type:VIP {item.TripDestination} {item.TripOrigin}  {item.TicketPrice} capacity: {item.Capacity}");
                }

                var normalTrip = dbContext.Trips.OfType<NormalBusTrip>().ToList();
                foreach (var item in normalTrip)

                {

                    Console.WriteLine($"{item.Id}  Type:Normal {item.TripDestination} {item.TripOrigin}  {item.TicketPrice} capacity: {item.Capacity}");
                }
                List<Seat> TravelSeats=new List<Seat>();
                Console.WriteLine("Enter trip id");
                var tripId = int.Parse(Console.ReadLine());
                var trip=dbContext.Trips.Include(t=>t.Bus).First(t => t.Id == tripId);
                var tickets=dbContext.Tickets.Where(t=>t.TripId==tripId);
                foreach (var item in tickets)
                {
                    var TicketSeats=dbContext.Seats.Where(s=>s.TicketId==item.Id).ToList();
                    foreach(var seat in TicketSeats)
                    {
                        TravelSeats.Add(seat);
                    }
                }
                if (trip.Bus.TypeOfBus == TypeOfBus.vip)
                {
                    var empty=30-TravelSeats.Count;
                    Console.WriteLine($"EmptySeat:{empty}");
                }
                else
                {
                    var empty = 44 - TravelSeats.Count;
                    Console.WriteLine($"EmptySeat:{empty}");
                }
            }
            break;
        case "8":
            exit = true;
            break;
        default:
            Console.Clear();
            Console.WriteLine("You choose invalid Option");
            Console.ReadLine();
            Console.Clear();
            break;
    }


}