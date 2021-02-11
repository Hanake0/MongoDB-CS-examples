// Cria um Filtro para encontrar um filme com esse título
var filter = Builders<Movie>.Filter.Eq(m => m.Title, "The Princess Bride");


// Utiliza find com o fltro para encontrar o filme (Async)
var movie = await MoviesCollection
	.Find<Movie>(filter)
	.FirstOrDefaultAsync();


// Também pode ser utilizado para encontrar mais de um resultado
var movies = await MoviesCollection
	.Find<Movie>(Builders<Movie>.Filter.Eq(m => m.Year, 2005)) // Encontra os filmes que foram produzidos em 2005
	.ToListAsync();                                            // Converte o resultado numa lista




// Para criar um sistema de paginação também é bem simples

int page = 3;
int moviesPerPage = 10

var movies = await MoviesCollection
	.Find(Builders<Movie>.Filter.Empty)                // Cria um filtro vazio para incluir todos os filmes
	.Sort(Builders<Movie>.Sort.Ascending(m => m.Year)  // Coloca os filmes em ordem crescente de acordo com o ano
	.Skip(page * moviesPerPage)                        // Pula o número de filmes para ir a página correta
	.Limit(moviesPerPage)                              // Limita a lista á quantidade de filmes definida por página
	.ToListAsync();                                    // Converte o resultado numa lista
