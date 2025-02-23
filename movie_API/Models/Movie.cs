namespace movie_API.Models {
    public class Movie {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Year { get; set; }
        public required string Director { get; set; }
        public required string Poster { get; set; }
    }
}