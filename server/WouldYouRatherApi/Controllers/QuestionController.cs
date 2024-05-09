using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WouldYouRatherApi.Models;
using WouldYouRatherApi.Services;

namespace WouldYouRatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;
        public QuestionController(QuestionService questionService) => _questionService = questionService;

        [HttpGet]
        public async Task<Question> GetRandomQuestion() => await _questionService.GetRandomQuestion();

        [HttpPost]
        public async Task CreateAsync(string firstQuestion, string secondQuestion){
            await _questionService.CreateAsync(new Question(firstQuestion, secondQuestion));
        }

        [HttpPut("{id}/{option}")]
        public async Task<IActionResult> PutVote(string id, int option)
        {

            var question = await _questionService.GetAsync(id);

            if (question == null)
                return NotFound("Question not found");

            if(option == 1){
                question.FirstQuestionVotes++;
            }else if(option == 2){
                question.SecondQuestionVotes++;
            }
            await _questionService.UpdateAsync(id, question);
            return Ok(question.CalculateVotes());
        }
    }

}
