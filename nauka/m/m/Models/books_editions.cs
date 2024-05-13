namespace m.Models;

public class BooksEditions
{
    private int Pk { get; }
    private int FkPublishingHouse { get;  }
    private int FkBook { get; }
    private string EditionTitle { get; set; }
    private DateTime ReleaseDate { get; set; }
}