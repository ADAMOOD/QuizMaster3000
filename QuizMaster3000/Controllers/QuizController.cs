using Microsoft.AspNetCore.Mvc;
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
	}
}