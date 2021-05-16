namespace BookCatalogue.Application.BookRegistration.Query
{
    public class SearchCatalogueQuery 
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
    }

}
