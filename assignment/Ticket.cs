namespace assignment;

public class Ticket
{
    private string _movieName ;
    private double _price;

    public static int TicketCounter = 0;
// property-----------------------------------
    public string MovieName
    {
        get => _movieName;
        set
        {
            if (string.IsNullOrEmpty(value))
                return;
            _movieName = value;
        }
    }
    public TicketType Type {get; set;}
    public SeatLocation Seat {get; set;} 
    public double Price 
    {
        get => _price;
        set
        {
            if (value <= 0)
                return;
            _price = value;
        }
    }
    public double PriceAfterTax => _price * 1.14;
    public int TicketId {get;}
// Get Total Tickets Sold-----------------------------------
    public static int GetTotalTicketsSold() => TicketCounter;
// constructor-----------------------------------
    public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
    {
        TicketCounter++;
        TicketId = TicketCounter;
        
        _movieName = movieName;
        Type = type;
        Seat = seat;
        _price = price;
    }
// default Seat constructor-----------------------------------
SeatLocation _defaultSeat = new SeatLocation('A', 1);

    public Ticket(string movieName)
    {
        _movieName = movieName;
        Type = TicketType.Standard;
        Seat = _defaultSeat;
        _price = 50;
    }
// Calc Total After Tax-----------------------------------
    public double CalcTotalAfterTax(double taxPercent)
    {
        double totalPrice = _price + ((_price * taxPercent) / 100);
        return totalPrice ;
    }
}
// TicketType-----------------------------------
public enum TicketType
{
    Standard, Vip, Imax
}
// SeatLocation-----------------------------------
public struct SeatLocation
{
    public char row;
    public int number;
    public SeatLocation(char row, int number)
    {
        this.row = row;
        this.number = number;
    }

    public override string ToString()
    {
        return $"{row}-{number}";
    }
}
