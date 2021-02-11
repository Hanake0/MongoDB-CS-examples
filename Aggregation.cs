// Limita os filmes aos que tenham "Rob Reiner" como diretor
var matchStage = new BsonDocument("$match",
	new BsonDocument("directors", "Rob Reiner"));

// Organiza os filmes em ordem decrescente em relação ao número de reviews
var sortStage = new BsonDocument("$sort",
	new BsonDocument("tomatoes.viewer.numReviews", -1));

// Cria uma projeção para incluir apenas os campos desejados
var projectionStage = new BsonDocument("$project",
	new BsonDocument
		{
			{ "_id", 0 },
			{ "Movie Title", "$title" },
			{ "Year", "$year" },
			{ "Average User Rating", "$tomatoes.viewer.rating" }
		});

/* We now put the stages together in a pipeline. Note that a
 * pipeline definition requires us to specify the input and output
 * types. In this case, the input is of type Movie, but because
 * we are using a Projection with custom fields, our output is
 * a generic BsonDocument object. To be really cool, we could
 * create a mapping class for the output type, which is what we've
 * done for you in the MFlix application.
 */

// Cria a pipeline com todos os estágios
var pipeline = PipelineDefinition<Movie, BsonDocument>
	.Create(new BsonDocument[] {
		matchStage,
		sortStage,
		projectionStage
	});

// Entrega os resultados numa lista
var result = await MoviesCollection.Aggregate(pipeline).ToListAsync();
