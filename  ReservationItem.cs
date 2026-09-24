namespace OOP_Assignment_1;

public class ReservationItem
{
    public Guid ReservationId { get; } = Guid.NewGuid();
    public Room Room { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public string Status { get; private set; } = null!;
    public decimal Cost => (CheckOutDate - CheckInDate).Days * Room.NightlyRate;

    public ReservationItem(Room room, DateTime checkInDate, DateTime checkOutDate)
    {
        ArgumentNullException.ThrowIfNull(room);
        if (checkInDate > checkOutDate) throw new ArgumentException("Check-out must be after check-in.", nameof(checkOutDate));
        Room = room;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
    }

    public override string ToString()
    {
        return $"Room {Room} is reserved from {CheckInDate} to {CheckOutDate}";
    }
}