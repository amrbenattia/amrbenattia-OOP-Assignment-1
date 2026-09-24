namespace OOP_Assignment_1;

public class Room
{
    public Guid RoomId { get; } = Guid.NewGuid();
    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }
    private readonly List<ReservationItem> _reservations = [];

    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(roomNumber);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(nightlyRate);
        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
    }

    public void ChangeNightlyRate(decimal newRate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(newRate);
        NightlyRate = newRate;
    }

    public void StartMaintenance()
    {
        if (IsUnderMaintenance) throw new InvalidOperationException("already under maintaince.");
        IsUnderMaintenance = true;
    }
    public void EndMaintenance()
    {
        if (!IsUnderMaintenance) throw new InvalidOperationException("alrady maintaince is done.");
        IsUnderMaintenance = false;
    }


    public bool IsAvailable(DateTime checkIn, DateTime checkOut) =>
        !_reservations.Any(r => r.IsActive
                             && r.CheckInDate.Date < checkOut.Date
                             && checkIn.Date < r.CheckOutDate.Date);

    internal void Register(ReservationItem reservation) => _reservations.Add(reservation);
}
