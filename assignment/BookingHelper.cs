namespace assignment;

public static class BookingHelper
{
    private static int _counter = 0;
    
    public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
    {
        var total = pricePerTicket * numberOfTickets;
        if(numberOfTickets >= 5)
            total *= 0.9;
        return total;
    }

    public static string GenerateBookingReference()
    {
        _counter++;
        return $"BK-{_counter}";
    }
}