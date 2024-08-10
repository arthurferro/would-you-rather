using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WouldYouRatherApi.Models;
using WouldYouRatherApi.Services;

namespace WouldYouRatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;
        public QuestionController(QuestionService questionService) => _questionService = questionService;

        [HttpGet]
        public async Task<Question> GetRandomQuestionAsync() => await _questionService.GetAsync();

        [HttpPost]
        public async Task CreateRandomQuestionAsync(string firstQuestion, string secondQuestion) => await _questionService.CreateAsync(new Question(firstQuestion, secondQuestion));

        [HttpPut("{id}/{option}")]
        public async Task<IActionResult> PutVoteQuestionAsync(string id, int option)
        {
            var question = await _questionService.GetAsync(id);

            if (question == null)
                return NotFound("Question not found");
            else if (option < 1 || option > 2)
                return BadRequest("Invalid option");

            question.AddVote(option);

            await _questionService.UpdateAsync(id, question);
            return Ok(question.CalculateVotes());
        }
    }

}
