namespace OOP_Assignment_1;

public class Guest(string fullName, string phoneNumber)
{
    public Guid GuestId { get; } = new Guid();
    public string FullName { get; } = fullName;
    public string PhoneNumber { get; } = phoneNumber;

    private readonly List<ReservationItem> _reservations = [];
    public IReadOnlyList<ReservationItem> Reservations => _reservations;

    public List<ReservationItem> AddReservation(ReservationItem item)
    {
        _reservations.Add(item);

        return _reservations;
    }

    public override string ToString()
    {
        return $"Guest {FullName} is created";
    }
}