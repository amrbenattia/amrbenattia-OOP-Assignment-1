namespace OOP_Assignment_1;

class Program
{
    static void Main(string[] args)
    {

        var guest = new Guest("Amr", "new phone");
        var room = new Room(1, RoomType.Double, 100);
        room.ChangeNightlyRate(200);
        Console.WriteLine(room.RoomId);

        var reservation = new ReservationItem(room, new DateTime(2025, 10, 13), new DateTime(2025, 10, 12));

        guest.AddReservation(reservation);

        foreach (ReservationItem item in guest.Reservations)
        {

            Console.WriteLine(item.Cost);
        }
    }
}