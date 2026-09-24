namespace OOP_Assignment_1;

public class Room
{
    public Guid RoomId { get; } = Guid.NewGuid();
    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }

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

    public override string ToString()
    {
        return $"Room {RoomNumber} {RoomId}";
    }
}
