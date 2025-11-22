using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    public class CartItem
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public double SubTotal => UnitPrice * Quantity;
    }

    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddItem(string name, double price, int qty)
        {
            var existing = items.Find(i => i.ProductName == name);
            if (existing != null)
            {
                existing.Quantity += qty;
            }
            else
            {
                items.Add(new CartItem
                {
                    ProductName = name,
                    UnitPrice = price,
                    Quantity = qty
                });
            }
        }

        public void RemoveItem(string productName)
        {
            items.RemoveAll(i => i.ProductName == productName);
        }

        public void UpdateQuantity(string productName, int newQuantity)
        {
            var item = items.Find(i => i.ProductName == productName);
            if (item != null)
            {
                item.Quantity = newQuantity;
            }
        }

        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (var i in items)
                {
                    total += i.SubTotal;
                }
                return total;
            }
        }

        public void PrintCart()
        {
            Console.WriteLine("\n--- CART ITEMS ---");
            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
            }
            else
            {
                foreach (var i in items)
                {
                    Console.WriteLine($"{i.ProductName} | Qty: {i.Quantity} | Unit: {i.UnitPrice} | Subtotal: {i.SubTotal}");
                }
            }
            Console.WriteLine("Total Price: " + TotalPrice);
            Console.WriteLine("-------------------\n");
        }
    }

    // ---------------- INVENTORY CLASS ----------------

    public class InventoryManager
    {
        private Dictionary<int, int> stock = new Dictionary<int, int>();

        public void AddOrUpdateProduct(int productId, int stockCount)
        {
            if (stock.ContainsKey(productId))
            {
                stock[productId] = stockCount;
            }
            else
            {
                stock.Add(productId, stockCount);
            }
        }

        public void PrintStock()
        {
            Console.WriteLine("\n--- INVENTORY STOCK ---");
            if (stock.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
            }
            else
            {
                foreach (var kv in stock)
                {
                    Console.WriteLine($"ProductID: {kv.Key} | Stock: {kv.Value}");
                }
            }
            Console.WriteLine("------------------------\n");
        }

        // Strict version using exceptions – never allow negative stock
        public void ReduceStockStrict(int productId, int qty)
        {
            if (!stock.ContainsKey(productId))
                throw new Exception("Invalid product ID");

            if (qty < 0)
                throw new Exception("Quantity cannot be negative.");

            if (stock[productId] < qty)
                throw new Exception("Stock cannot go negative! Insufficient stock.");

            stock[productId] -= qty;
        }

        // Safe version without exceptions – returns bool + message
        public bool TryReduceStock(int productId, int qty, out string message)
        {
            message = "";

            if (!stock.ContainsKey(productId))
            {
                message = "Product not found.";
                return false;
            }

            if (qty < 0)
            {
                message = "Quantity cannot be negative.";
                return false;
            }

            if (stock[productId] < qty)
            {
                message = "Not enough stock. Operation blocked.";
                return false;
            }

            stock[productId] -= qty;
            message = "Stock updated successfully.";
            return true;
        }
    }

    internal class Product_id
    {
        static int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            int longest = 0;

            foreach (int x in nums)
            {
                if (!set.Contains(x - 1))
                {
                    int current = x;
                    int length = 1;

                    while (set.Contains(current + 1))
                    {
                        current++;
                        length++;
                    }

                    if (length > longest)
                        longest = length;
                }
            }

            return longest;
        }

        // 2️⃣ Detect Loop in Path (U, D, L, R)
        static bool HasLoop(string moves)
        {
            int x = 0, y = 0;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            visited.Add((x, y));

            foreach (char c in moves)
            {
                switch (c)
                {
                    case 'U': y++; break;
                    case 'D': y--; break;
                    case 'L': x--; break;
                    case 'R': x++; break;
                    default:
                        continue;
                }

                var current = (x, y);

                if (visited.Contains(current))
                    return true;

                visited.Add(current);
            }

            return false;
        }

        // 3️⃣ Cart Menu
        static void CartMenu()
        {
            Cart cart = new Cart();
            bool running = true;

            while (running)
            {
                Console.WriteLine("=== CART MENU ===");
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. Remove item");
                Console.WriteLine("3. Update quantity");
                Console.WriteLine("4. View cart");
                Console.WriteLine("5. Back to main menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter unit price: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Enter quantity: ");
                        int qty = int.Parse(Console.ReadLine());

                        cart.AddItem(name, price, qty);
                        cart.PrintCart();
                        break;

                    case "2":
                        Console.Write("Enter product name to remove: ");
                        string removeName = Console.ReadLine();
                        cart.RemoveItem(removeName);
                        cart.PrintCart();
                        break;

                    case "3":
                        Console.Write("Enter product name to update: ");
                        string updateName = Console.ReadLine();

                        Console.Write("Enter new quantity: ");
                        int newQty = int.Parse(Console.ReadLine());

                        cart.UpdateQuantity(updateName, newQty);
                        cart.PrintCart();
                        break;

                    case "4":
                        cart.PrintCart();
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.\n");
                        break;
                }
            }
        }

        // 4️⃣ Inventory Menu
        static void InventoryMenu()
        {
            InventoryManager inventory = new InventoryManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("=== INVENTORY MENU ===");
                Console.WriteLine("1. Add/Update product stock");
                Console.WriteLine("2. Reduce stock (Strict - exception)");
                Console.WriteLine("3. Reduce stock (Safe Try method)");
                Console.WriteLine("4. View stock");
                Console.WriteLine("5. Back to main menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Product ID (int): ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Enter stock count: ");
                            int stockCount = int.Parse(Console.ReadLine());

                            inventory.AddOrUpdateProduct(id, stockCount);
                            inventory.PrintStock();
                            break;

                        case "2":
                            Console.Write("Enter Product ID to reduce stock: ");
                            int rid = int.Parse(Console.ReadLine());

                            Console.Write("Enter quantity to reduce: ");
                            int rqty = int.Parse(Console.ReadLine());

                            inventory.ReduceStockStrict(rid, rqty);
                            Console.WriteLine("Stock reduced successfully.\n");
                            inventory.PrintStock();
                            break;

                        case "3":
                            Console.Write("Enter Product ID to reduce stock: ");
                            int tid = int.Parse(Console.ReadLine());

                            Console.Write("Enter quantity to reduce: ");
                            int tqty = int.Parse(Console.ReadLine());

                            string msg;
                            bool ok = inventory.TryReduceStock(tid, tqty, out msg);
                            Console.WriteLine(msg + "\n");
                            inventory.PrintStock();
                            break;

                        case "4":
                            inventory.PrintStock();
                            break;

                        case "5":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Try again.\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message + "\n");
                }
            }
        }

        static void Main()
        {
            bool appRunning = true;

            while (appRunning)
            {
                Console.WriteLine("===== MAIN MENU =====");
                Console.WriteLine("1. Longest Consecutive Sequence");
                Console.WriteLine("2. Detect Loop in Path");
                Console.WriteLine("3. Dynamic Cart with Auto Total");
                Console.WriteLine("4. Inventory with Stock Dictionary");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter number of elements: ");
                        int n = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the elements (space-separated):");
                        string[] parts = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        int[] nums = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            nums[i] = int.Parse(parts[i]);
                        }

                        int longest = LongestConsecutive(nums);
                        Console.WriteLine("Longest Consecutive Sequence Length: " + longest + "\n");
                        break;

                    case "2":
                        Console.WriteLine("Enter path using U, D, L, R (e.g., UURDDL):");
                        string path = Console.ReadLine().Trim().ToUpper();

                        bool hasLoop = HasLoop(path);
                        if (hasLoop)
                            Console.WriteLine("The path contains a loop (revisited a coordinate).\n");
                        else
                            Console.WriteLine("The path does NOT contain a loop.\n");
                        break;

                    case "3":
                        CartMenu();
                        break;

                    case "4":
                        InventoryMenu();
                        break;

                    case "5":
                        appRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.\n");
                        break;
                }
            }

            Console.WriteLine("Exiting program. Goodbye!");
        }
    }
}
