namespace assignment;

public class Cinema
{
    private Ticket[] _tickets = new Ticket[20];
    public Ticket? this[int index]
    {
        get
        {
            if (index < 0 || index >= _tickets.Length)
                return null;
            return _tickets[index];
        }
        set
        {
            if (index < 0 || index >= _tickets.Length)
                return;
            _tickets[index] = value!;
        }
    }

    /*
    public Ticket? this[string movieName]
    {
        get
        {
            foreach (var ticket in _tickets)
            {
                if (ticket.MovieName == movieName)
                    return ticket;
            }

            return null;
        }
    }*/

    public Ticket? GetMovie (string movieName)
    {
        foreach (var ticket in _tickets)
        {
            if (ticket.MovieName == movieName)
                return ticket;
        }
        return null;
    }

    public bool AddTicket(Ticket? t)
    {
        for(int i = 0; i < _tickets.Length; i++)
        {
            if (t == null)
            {
                t = _tickets[i];
                return true;
            }
        }
        return false;
    }
}