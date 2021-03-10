namespace Bibliotheek.Models.Data
{
    public class Book : DataModelBase
    {
        public static string CollectionName => "books";
        public string Title { get; private set; }
        public string Author { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
