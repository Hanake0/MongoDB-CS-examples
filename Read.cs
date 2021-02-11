// Cria um Filtro para encontrar um filme com esse título
var filter = Builders<Movie>.Filter.Eq(m => m.Title, "The Princess Bride");



// Utiliza find com o fltro para encontrar o filme (Async)
var movie = await _moviesCollection.Find<Movie>(betterFilter).FirstOrDefaultAsync();



// Também pode ser utilizado para encontrar mais de um resultado
var movies = await MoviesCollection
	.Find<Movie>(Builders<Movie>.Filter.Eq(m => m.Year, 2005))
	.ToListAsync();
