using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _repository;

        public QuestionController(IQuestionRepository repository) => _repository = repository;

        [HttpGet]
        [Route("/GetQuestions")]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _repository.GetQuestions();
            return questions.Any() ? Ok(questions) : NoContent();
        }

        [HttpGet]
        [Route("/GetRandomQuestion")]
        public async Task<Question> GetRandomQuestion()
        {
            return await _repository.GetRandomQuestion();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var question = await _repository.FindQuestion(id);
            return question != null ? Ok(question) : NotFound("Question not found.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(string firstOption, string secondOption)
        {
            _repository.AddQuestion(new Question(firstOption, secondOption));
            return await _repository.SaveChangesAsync() ? Ok("Question added!") : BadRequest("Failed to add question.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Question question)
        {
            var questionDb = await _repository.FindQuestion(id);
            if (questionDb == null) return NotFound("Question not found.");

            questionDb.FirstOptionCount = question.FirstOptionCount;
            questionDb.SecondOptionCount = question.SecondOptionCount;
            questionDb.FirstOption = question.FirstOption;
            questionDb.SecondOption = question.SecondOption;
            _repository.updateQuestion(questionDb);

            return await _repository.SaveChangesAsync() ? Ok("Question updated!") : BadRequest("Failed to update question.");
        }

        [HttpPut("{id}/{option}")]
        public async Task<IActionResult> PutVote(int id, int option)
        {
            var questionDb = await _repository.FindQuestion(id);
            if (questionDb == null) return NotFound("Question not found.");
            if (option == 1)
            {
                questionDb.FirstOptionCount++;
            }
            if (option == 2)
            {
                questionDb.SecondOptionCount++;
            }
            _repository.updateQuestion(questionDb);
            return await _repository.SaveChangesAsync() ? Ok(questionDb.CalculatePercentage()) : BadRequest("Failed to vote question.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var questionDb = await _repository.FindQuestion(id);
            if (questionDb == null) return NotFound("Question not found.");
            _repository.DeleteQuestion(questionDb);
            return await _repository.SaveChangesAsync() ? Ok("Question deleted!") : BadRequest("Failed to delete question.");
        }

    }
}