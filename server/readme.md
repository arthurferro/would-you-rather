# QuestionController API

This ASP.NET Core Web API controller provides endpoints to manage questions.

## Model: Question

Represents a question entity with the following properties:

- `Id` (int): Unique identifier for the question.
- `FirstOption` (string): The first option of the question.
- `SecondOption` (string): The second option of the question.
- `FirstOptionCount` (int): The count of votes for the first option.
- `SecondOptionCount` (int): The count of votes for the second option.
- `CreatedDate` (DateTime): The date and time when the question was created.

### Methods

- `CalculatePercentage()`: Calculates the percentage of votes for each option and returns an object with the percentages.

## Endpoints

### GET /api/Question/GetQuestions

Retrieves all questions from the database.

### GET /api/Question/GetRandomQuestion

Retrieves a random question from the database.

### GET /api/Question/{id}

Retrieves a question by its ID.

### POST /api/Question

Adds a new question to the database. Requires parameters `firstOption` and `secondOption` in the request body.

### PUT /api/Question/{id}

Updates an existing question. Requires a JSON object representing the updated question in the request body.

### PUT /api/Question/{id}/{option}

Votes for an option (1 or 2) for a question.

### DELETE /api/Question/{id}

Deletes a question by its ID.

## Usage

1. Clone the repository.
2. Configure the database connection string in `appsettings.json`.
3. Run the application.
4. Use the provided endpoints to interact with the questions.

## CORS Configuration

This controller is configured to allow all headers in CORS requests.
