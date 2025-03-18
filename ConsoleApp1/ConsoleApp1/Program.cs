namespace ConsoleApp1
{
    internal class Program
    {
        class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public double Rating { get; set; }

            public Product(string name, decimal price, double rating)
            {
                Name = name;
                Price = price;
                Rating = rating;
            }

            public override string ToString()
            {
                return $"{Name} - {Price} $., Рейтинг: {Rating}";
            }
        }

        class Category
        {
            public string Name { get; set; }
            public List<Product> Products { get; set; }

            public Category(string name)
            {
                Name = name;
                Products = new List<Product>();
            }

            public void Productsdisp()
            {
                Console.WriteLine($"Категория: {Name}");
                foreach (var product in Products)
                {
                    Console.WriteLine(product);
                }
            }
        }

        class Cart
        {
            public List<Product> Productspush { get; private set; }

            public event Action Productadd;

            public Cart()
            {
                Productspush = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                Productspush.Add(product);
                Productadd?.Invoke();
            }
            public void DisplayCart()
            {
                Console.WriteLine("Товары в корзине:");
                foreach (var product in Productspush)
                {
                    Console.WriteLine(product);
                }
            }
        }

        class User
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public Cart UserCart { get; set; }

            public User(string login, string password)
            {
                Login = login;
                Password = password;
                UserCart = new Cart();
            }
        }

        class Vivod
        {
            static void Main()
            {
                var electrniks = new Category("Электроника");
                electrniks.Products.Add(new Product("Смартфон", 500, 4.7));
                electrniks.Products.Add(new Product("Ноутбук", 1500, 4.8));

                var clothing = new Category("Одежда");
                clothing.Products.Add(new Product("Футболка", 20, 4.5));
                clothing.Products.Add(new Product("Джинсы", 15, 4.6));

                electrniks.Productsdisp();
                clothing.Productsdisp();

                var user = new User("User123", "password12345");
                user.UserCart.Productadd += () =>
                {
                    Console.WriteLine("Товар добавлен в корзину: ");
                    user.UserCart.DisplayCart();
                };

                user.UserCart.AddProduct(electrniks.Products[0]);
                user.UserCart.AddProduct(clothing.Products[1]);
            }
        }
    }
}
