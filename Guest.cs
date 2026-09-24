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

    public void AddReservation(ReservationItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _reservations.Add(item);
    }

    public override string ToString()
    {
        return $"Guest {FullName} is created";
    }
}
