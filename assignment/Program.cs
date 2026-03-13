namespace assignment;
public class Program{
	public static void Main(string[] args)
	{
	//Q1-----------------------------------------------------------------------------------------------------------------------
		/*
		(a) Identify at least two problems with this design from an encapsulation perspective.
			=> fields are public not private, no validation so we can set Balance to be negative for example
		(b) Describe how you would fix this class to follow proper encapsulation principles. You do not need to write the full code.
			=> by making fields private, balance => readonly, use properties with validation to access fields, add validation to Withdraw method
		(c) Explain why exposing fields directly (as public) is considered a bad practice in OOP.
			=> we can set Balance to be negative for example, no encapsulation, no validation, not safe
		 */
		
	// Q2-----------------------------------------------------------------------------------------------------------------------
		/*
		 => field is a variable that stores data direct in a class
		 => property makes validation to a field using get and set
		 => yes, property can contain logic (validation)
	// code-----------------------
		public class BankAccount
		{
			private double _balance;
			private double _interest;
			
			public string Owner { get; set; } = null! ;
			public double Balance { get; } = 0;
			public double Interest { get => (_balance * 5) / 100;} 
			
			public void Withdraw(double amount)
			{
				if (amount < 0 || amount > _balance)
					return;
				_balance -= amount;
			}
		}
		 */
		
	// Q3-----------------------------------------------------------------------------------------------------------------------
		/*
		a) What is `this[int index]` called? Explain its purpose
			=> it is called indexer, to use index on class object like arrays
		b) What happens if someone writes `register[10] = "Ali";` ? How would you make the indexer safer?
			=> IndexOutOfRangeException because the array size is only 5
			=> to make the indexer safer we can make conditions, validation in get, set
		c) Can a class have more than one indexer? If yes, give an example of when that would be useful.
			=> yes, a class can have more than one indexer
			=> This is useful when we want to access object by different parameters

// example----------
		public class StudentRegister{
			private string[] names = new string[5];

			public string this[int index]
			{
				get { return names[index]; }
				set { names[index] = value; }
			}
			public string this[string name]
			{
				get
				{
					foreach (var item in names)
					{
						if (string.Equals(item, name, StringComparison.OrdinalIgnoreCase))
							return item;
					}
					return null;
				}
			}	
		}
		 */
	// Q4-----------------------------------------------------------------------------------------------------------------------
	
		/*
		 public class Order
		{

		public static int TotalOrders = 0; 
		public string Item;

		public Order(string item)
		{
		Item = item;
		TotalOrders++;
		}}

		a) What does the `static` keyword mean on `TotalOrders`? How is it different from the `Item` field?
			=> static keyword means that TotalOrders belongs to the class not tO any object
			=> TotalOrders is static (shared / call on class direct)
			=> Item is instance (needs an object), each object has its own value

		b) Can a static method inside `Order` access the `Item` field directly? Why or why not?
			=> no, static method can't access the Item field directly
			=> Item is an instance field, static methods belong to the class, not to objects

		 */
	
	
	// Q5-----------------------------------------------------------------------------------------------------------------------
	
	
	/*
a. Ask the user to enter data for 3 tickets
 (movie name, ticket type, seat row, seat number, price). 
 Create each Ticket and add it to the Cinema .
 
b. Print all 3 tickets (access by index 0, 1, 2) showing: 
TicketId, MovieName, Type, Seat, Price, and PriceAfterTax.
c. Ask the user for a movie name and search for it. Print the result or a "not found" message.
d. Print the total tickets sold using the method.
e. Generate and print 2 booking references .
f. Calculate and print the group discount for a group of 5 tickets at 80 EGP each of them.

	 */ 
	Console.WriteLine("========= Ticket Booking =========");
	Cinema cinema = new Cinema();
	
	for (int i = 0; i < 3; i++)
	{
		Console.WriteLine($"\nEnter data for Ticket {i+1}: ");
		Console.Write("Movie Name: ");
		string movie = Console.ReadLine();
		
		Console.Write("Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
		int typeNumber = int.Parse(Console.ReadLine());
		TicketType type = (TicketType)typeNumber;
      
		Console.Write("Seat Row (A-Z): ");
		char row = char.Parse(Console.ReadLine());
		// char row = Console.ReadLine()![0];
      
		Console.Write("Seat Number: ");
		int seatNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

		Console.Write("Price: ");
		double price = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
		
		SeatLocation seat = new SeatLocation(row, seatNumber);
		Ticket ticket = new Ticket(movie, type, seat, price);
		
		cinema[i] = ticket;
	}
	
	Console.WriteLine("\n========= All Tickets =========\n");
	for (int i = 0; i < 3; i++)
	{
		Ticket ticket = cinema[i];
		Console.WriteLine( $"Ticket #{ticket.TicketId} | {ticket.MovieName} | {ticket.Type} | Seat: {ticket.Seat} | Price: {ticket.Price} EGP | After Tax: {ticket.PriceAfterTax}");
	}
	
	Console.WriteLine("\n========= Search By Movie =========");
	Console.Write("Enter movie name to search: ");
	string search = Console.ReadLine();

	Ticket found = cinema.GetMovie(search);
	if (found != null)
		Console.WriteLine($"Found: Ticket #{found.TicketId} | {found.MovieName} | {found.Type} | Seat: {found.Seat} | Price: {found.Price} EGP");
	else Console.WriteLine("Movie not found");
	
	Console.WriteLine("\n========= Statistics =========");
	Console.WriteLine($"Total Tickets Sold: {Ticket.GetTotalTicketsSold()}");
	Console.WriteLine($"\nBooking Reference 1: {BookingHelper.GenerateBookingReference()}");
	Console.WriteLine($"Booking Reference 2: {BookingHelper.GenerateBookingReference()}");

	int numberOfTickets = 5;
	double pricePerTicket = 80;
	double discount = BookingHelper.CalcGroupDiscount(numberOfTickets, pricePerTicket);
	Console.WriteLine($"Group Discount ({numberOfTickets} tickets * {pricePerTicket} EGP): {discount} EGP (10% off applied)");



	/*
	Console.WriteLine( $" Ticket #{ticket.TicketId}");
	Console.WriteLine( $" {ticket.MovieName} ");
	Console.WriteLine( $"{ticket.Type} ");
	Console.WriteLine( $" Seat: {ticket.Seat} ");
	Console.WriteLine( $" Price: {ticket.Price}");
	Console.WriteLine( $"After Tax: {ticket.PriceAfterTax}");*/
	// Console.WriteLine( $" Ticket #{ticket.TicketId} |  {ticket.MovieName} | {ticket.Type} | Seat: {ticket.Seat} | Price: {ticket.Price} | After Tax: {ticket.PriceAfterTax}");


	/*
	Console.Write("Enter Movie Name: ");
	string movie = Console.ReadLine();*/
//--------------------------------------------
//test
	// Ticket defaultTicket = new Ticket(movie);

	/*
	Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
	int typeNumber = int.Parse(Console.ReadLine());
	TicketType type = (TicketType)typeNumber;

	Console.Write("Enter Seat Row (A, B, C ... ): ");
	char row = char.Parse(Console.ReadLine());

	Console.Write("Enter Seat Number: ");
	int seatNumber = int.Parse(Console.ReadLine());

	Console.Write("Enter Price: ");
	double price = double.Parse(Console.ReadLine());
	*/

	/*
	Console.Write("Enter Discount Amount: ");
	double discount = double.Parse(Console.ReadLine());
	Console.WriteLine();
	*/

	/*
	SeatLocation seat = new SeatLocation(row, seatNumber);
	Ticket ticket = new Ticket(movie, type, seat, price);

	ticket.PrintTicket(14);

	Console.WriteLine();
	ticket.ApplyDiscount(ref discount, 14);
	*/






	}
}
