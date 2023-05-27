using Microsoft.AspNetCore.Mvc;
using QuizMaster3000.Models;
using QuizMaster3000.Providers;

namespace QuizMaster3000.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizProvider provider;

        public QuizController(QuizProvider quizProvider)
        {
            provider = quizProvider;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetQuizzes()
        {
            return Ok(await provider.GetQuizzes());
        }

        [HttpGet]
        [Route("random/{amount}")]
        public async Task<IActionResult> GetRandomQuizzes([FromRoute] int amount)
        {
            Random random = new Random();
            Thread.Sleep(random.Next(500, 5000));
            return Ok(await provider.GenerateQuizzes(amount));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostQuiz() //momentalne jen testovaci data, pozdeji asi bude nejake ui
        {
            return Ok(await provider.PostQuiz(10, 2, RoomState.InLobby));
        }

	}
}