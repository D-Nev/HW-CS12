using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    internal class Program
    {
        
    }

    public record Book
    {
        private string _title;
        private string _description;

        public string Title
        {
            get => _title;
            set => _title = Replaces(value);
        }

        public string Description
        {
            get => _description;
            set => _description = RemoveExtr(value);
        }

        public string Author { get; init; }
        public int Year { get; init; }

        public Book(string title, string description, string author, int year)
        {
            Title = title;
            Description = description;
            Author = author;
            Year = year;
        }
       private string Replaces(string input)
        {
            return Regex.Replace(input, @"\d", match =>
            {
                return match.Value switch
                {
                    "0" => "zero",
                    "1" => "one",
                    "2" => "two",
                    "3" => "three",
                    "4" => "four",
                    "5" => "five",
                    "6" => "six",
                    "7" => "seven",
                    "8" => "eight",
                    "9" => "nine",
                    _=> match.Value
                };
            });
        }

        private string RemoveExtr(string input)
        {
            return Regex.Replace(input, @" {2,}", " ");
        }

        public override string ToString()
        {
            return $"{Title}, {Author}, {Year}: {Description}";
        }
    }

    class Programs
    {
        static void Main(string[] args)
        {
            var book = new Book(
                "My Book 2023",
                "This is description with extra spaces.",
                "John Doe",
                2023
            );

            Console.WriteLine(book);
        }
    }
}
