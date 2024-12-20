public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Year { get; private set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"\"{Title}\" - {Author} ({Year})";
    }
}

public class Library
{
    public List<Book> books = new List<Book>();

    public void add_book(Book book)
    {
        books.Add(book);
    }

    public bool delete_book(int index)
    {
        if (index >= 0 && index < books.Count)
        {
            books.RemoveAt(index);
            return true;
        }
        return false;
    }

    public void show_all_books()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
        }
        else
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool is_running = true;

        while (is_running)
        {
            Console.WriteLine("\nДобро пожаловать в библиотеку!");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу");
            Console.WriteLine("3. Показать все книги");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите название книги: ");
                        string title = Console.ReadLine();

                        Console.Write("Введите автора книги: ");
                        string author = Console.ReadLine();

                        Console.Write("Введите год выпуска: ");
                        if (int.TryParse(Console.ReadLine(), out int year) && year > 0 && year <= DateTime.Now.Year)
                        {
                            library.add_book(new Book(title, author, year));
                            Console.WriteLine("Книга добавлена!\n");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: год выпуска некорректен. Попробуйте снова.\n");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Список книг:");
                        library.show_all_books();
                        Console.Write("Введите номер книги для удаления: ");

                        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= library.books.Count)
                        {
                            if (library.delete_book(index - 1))
                            {
                                Console.WriteLine("Книга успешно удалена!\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: некорректный номер.\n");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Список книг:");
                        library.show_all_books();
                        break;

                    case 4:
                        is_running = false;
                        Console.WriteLine("До свидания!");
                        break;

                    default:
                        Console.WriteLine("Ошибка: выбрано некорректное действие. Попробуйте снова.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введено не число. Попробуйте снова.\n");
            }
        }
    }
}
