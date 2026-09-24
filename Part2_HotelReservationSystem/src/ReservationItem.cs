namespace OOP_Assignment_1;

public class ReservationItem
{
    public Guid ReservationId { get; } = Guid.NewGuid();
    public Room Room { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;
    public decimal Cost => (CheckOutDate - CheckInDate).Days * Room.NightlyRate;
    public bool IsActive => Status is not (ReservationStatus.Canceled or ReservationStatus.CheckedOut);

    internal ReservationItem(Room room, DateTime checkInDate, DateTime checkOutDate)
    {
        ArgumentNullException.ThrowIfNull(room);
        if (checkInDate.Date >= checkOutDate.Date) throw new ArgumentException("Check-out must be after check-in.", nameof(checkOutDate));
        if (room.IsUnderMaintenance) throw new InvalidOperationException($"Room {room.RoomNumber} is under maintenance and cannot be booked.");
        if (!room.IsAvailable(checkInDate, checkOutDate))
            throw new InvalidOperationException($"Room {room.RoomNumber} is already booked for those dates.");
        Room = room;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        room.Register(this);

    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
            throw new InvalidOperationException($"Cannot confirm a {Status} reservation.");
        Status = ReservationStatus.Confirmed;
    }

    public void CheckIn()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException($"Cannot check in a {Status} reservation.");
        Status = ReservationStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
            throw new InvalidOperationException($"Cannot check out a {Status} reservation.");
        Status = ReservationStatus.CheckedOut;
    }
    public void Cancel()
    {
        if (Status is not (ReservationStatus.Pending or ReservationStatus.Confirmed))
            throw new InvalidOperationException($"Cannot cancel a {Status} reservation.");
        Status = ReservationStatus.Canceled;
    }

    public override string ToString()
    {
        return $"Room {Room} is reserved from {CheckInDate} to {CheckOutDate}";
    }
}