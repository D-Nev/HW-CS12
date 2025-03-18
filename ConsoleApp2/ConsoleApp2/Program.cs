namespace ConsoleApp2
{
    internal class Program
    {
        class Shelfbook
        {
            public int BookCount { get; private set; }

            public Shelfbook(int initialBooks)
            {
                if (initialBooks < 0)
                    throw new ArgumentException("Количество книг не может быть отрицательным ");
                BookCount = initialBooks;
                Console.WriteLine($"На полку добавлено {BookCount} книг ");
            }

            public void AddBooks(int count)
            {
                if (count < 0)
                    throw new ArgumentException("Количество добавляемых книг не может быть отрицательным ");
                BookCount += count;
                Console.WriteLine($"Событие: Добавлено {count} книг(и). На полке теперь {BookCount} книг ");
            }

            public void Removebook(int count)
            {
                if (count < 0)
                    throw new ArgumentException("Количество забираемых книг не может быть отрицательным ");
                BookCount -= count;
                Console.WriteLine($"Убрано {count} книг. На полке теперь {BookCount} книг ");
            }
        }
        class Vivod
        {
            static void Main()
            {
                try
                {
                    Console.WriteLine("Введите начальное кол-во книг: ");
                    int initialBooks = int.Parse(Console.ReadLine());
                    Shelfbook bookShelf = new Shelfbook(initialBooks);

                    bool running = true;
                    while (running)
                    {
                        Console.WriteLine("1 - Добавить книги");
                        Console.WriteLine("2 - Забрать книги");
                        Console.WriteLine("3 - Выйти");

                        try
                        {
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Сколько книг добавить?");
                                    int addCount = int.Parse(Console.ReadLine());
                                    bookShelf.AddBooks(addCount);
                                    break;
                                case 2:
                                    Console.WriteLine("Сколько книг забрать?");
                                    int removeCount = int.Parse(Console.ReadLine());
                                    bookShelf.Removebook(removeCount);
                                    break;
                                case 3:
                                    Console.WriteLine("Выход из программы...");
                                    running = false;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка: Попробуйте снова ");
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка: Введите число ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
