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

	public async Task<List<Quiz>> GenerateQuizzes(int amount)
	{
		QuizList.Clear();
		for (int i = 0; i < amount; i++)
		{
			Random random = new Random();
			var roomStates = (RoomState[])Enum.GetValues(typeof(RoomState));

			var maxPlayerCount = random.Next(1, 20);
			var currentPlayerCount= maxPlayerCount-random.Next(0, maxPlayerCount);
			var roomState = roomStates[random.Next(0, roomStates.Length)];

			var quiz = new Quiz(maxPlayerCount, currentPlayerCount, roomState);
			QuizList.Add(quiz);
		}

		return QuizList;
	}
}