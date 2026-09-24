namespace OOP_Assignment_1;

public class Guest
{
    public Guid GuestId { get; } = Guid.NewGuid();
    public string FullName { get; }
    public string PhoneNumber { get; }

    private readonly List<ReservationItem> _reservations = [];
    public IReadOnlyList<ReservationItem> Reservations => _reservations;

    public Guest(string fullName, string phoneNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    public ReservationItem MakeReservation(Room room, DateTime checkInDate, DateTime checkOutDate)
    {
        ArgumentNullException.ThrowIfNull(room);
        var reservation = new ReservationItem(room, checkInDate, checkOutDate);
        _reservations.Add(reservation);
        return reservation;
    }

    public override string ToString()
    {
        return $"Guest {FullName} is created";
    }
}
