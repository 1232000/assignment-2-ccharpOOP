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












/*
//----------------------------------------------------------------------
namespace assignment;

public class Ticket
{
    private string movieName;
    private TicketType type;
    private SeatLocation seat;
    private double price;
// property-----------------------------------
    public double Price { get{return price;} set{price = value;} }
// constractor-----------------------------------
    public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
    {
        this.movieName = movieName;
        this.type = type;
        this.seat = seat;
        this.price = price;
    }
// constractor-----------------------------------
SeatLocation defaultSeat = new SeatLocation('A', 1);

    public Ticket(string movieName)
    {
        this.movieName = movieName;
        type = TicketType.Standard;
        seat = defaultSeat;
        Price = 50;
    }
// CalcTotal-----------------------------------
    public double CalcTotal(double taxPercent)
    {
        double totalPrice = price + ((price * taxPercent) / 100);
        return totalPrice ;
    }
// ApplyDiscount-----------------------------------
    public void ApplyDiscount(ref double discountAmount, double taxPercent)
    {
        Console.WriteLine("===== After Discount =====");
        Console.WriteLine($"Discount Before : {discountAmount}");

        if (discountAmount > 0 && discountAmount <= Price)
        {
            price -= discountAmount;
            discountAmount = 0.00;
        }

        Console.WriteLine($"Discount After : {discountAmount}");
        Console.WriteLine($"Movie    : {movieName}");
        Console.WriteLine($"Type     :  {type}");
        Console.WriteLine($"Seat     : {seat.row}{seat.number}");
        Console.WriteLine($"Price    : {price}");
        Console.WriteLine($"Total ({taxPercent}% tax) : {CalcTotal(taxPercent)}");
    }
// PrintTicket-----------------------------------
    public void PrintTicket(double taxPercent)
    {
        Console.WriteLine("===== Ticket Info =====");
        Console.WriteLine($"Movie : {movieName}");
        Console.WriteLine($"Type  :  {type}");
        Console.WriteLine($"Seat  : {seat.row}{seat.number}");
        Console.WriteLine($"Price : {price}");
        Console.WriteLine($"Total ({taxPercent}% tax) : {CalcTotal(taxPercent)}");
    }
}
// TicketType-----------------------------------
public enum TicketType
{
    Standard, VIP, IMAX
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
        getSeat(row, number);
    }
    public string getSeat(char row, int number)
    {
        return $"{row}{number}";
    }
    
}
*/