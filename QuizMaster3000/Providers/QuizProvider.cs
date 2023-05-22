using QuizMaster3000.Models;

namespace QuizMaster3000.Providers;

public class QuizProvider
{
	private static List<Quiz> QuizList = new List<Quiz>();

	public QuizProvider()
	{

	}
	public async Task<List<Quiz>> GetQuizzes()
	{
		return QuizList;
	}

	public async Task<Quiz> PostQuiz(int maxPlayerCount, int currentPlayerCount, RoomState roomState)
	{
		Quiz quiz = new Quiz(maxPlayerCount, currentPlayerCount, roomState);
		QuizList.Add(quiz);
		return quiz;
	}
}