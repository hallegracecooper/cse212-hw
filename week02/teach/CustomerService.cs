/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Test 1
        // Scenario: Test constructor with invalid size (should default to 10)
        // Expected Result: maxSize should be 10
        Console.WriteLine("Test 1 - Constructor with invalid size");
        var cs1 = new CustomerService(-5);
        Console.WriteLine($"MaxSize = {cs1}");
        // Verify maxSize is 10 by filling the queue
        for (int i = 1; i <= 10; i++)
        {
            var customer = new Customer($"Test{i}", $"A{i}", "Test Problem");
            cs1._queue.Add(customer);
        }
        Console.WriteLine($"Queue after adding 10 customers: {cs1}");
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Test AddNewCustomer with room in queue
        // Expected Result: Customer should be added successfully
        Console.WriteLine("Test 2 - Add customer to non-full queue");
        var cs2 = new CustomerService(3);
        var customer2 = new Customer("John Doe", "A123", "Test Problem");
        cs2._queue.Add(customer2);
        Console.WriteLine($"Queue after adding one customer: {cs2}");
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Test AddNewCustomer with full queue
        // Expected Result: Error message should be displayed
        Console.WriteLine("Test 3 - Add customer to full queue");
        var cs3 = new CustomerService(2);
        cs3._queue.Add(new Customer("Customer1", "B1", "Problem1"));
        cs3._queue.Add(new Customer("Customer2", "B2", "Problem2"));
        // Try to add one more customer to full queue
        cs3.AddNewCustomer(); // Should display error
        Console.WriteLine($"Queue after attempting to add to full queue: {cs3}");
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Test ServeCustomer with customers in queue
        // Expected Result: First customer should be removed and displayed
        Console.WriteLine("Test 4 - Serve customer from non-empty queue");
        var cs4 = new CustomerService(3);
        cs4._queue.Add(new Customer("Alice", "C1", "Problem1"));
        cs4._queue.Add(new Customer("Bob", "C2", "Problem2"));
        Console.WriteLine($"Queue before serving: {cs4}");
        cs4.ServeCustomer();
        Console.WriteLine($"Queue after serving: {cs4}");
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Test ServeCustomer with empty queue
        // Expected Result: Error message should be displayed
        Console.WriteLine("Test 5 - Serve customer from empty queue");
        var cs5 = new CustomerService(3);
        cs5.ServeCustomer(); // Should display error
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}