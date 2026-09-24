namespace OOP_Assignment_1;

class Program
{
    static void Main(string[] args)
    {

        var guest = new Guest("Amr", "new phone");
        var room = new Room(1, RoomType.Double, 100);
        room.ChangeNightlyRate(200);
        Console.WriteLine(room.RoomId);
        guest.MakeReservation(room, new DateTime(2025, 10, 9), new DateTime(2025, 10, 12));
        guest.MakeReservation(room, new DateTime(2025, 10, 9), new DateTime(2025, 10, 12));
        foreach (ReservationItem item in guest.Reservations)
        {
            Console.WriteLine(item.Status);
        }
    }
}