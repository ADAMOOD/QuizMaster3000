using QuizMaster3000.Models;

namespace QuizMaster3000.Providers
{
	public class QuizProvider
	{
		private static List<Quiz> QuizList = new List<Quiz>();

		public QuizProvider()
		{

		}
		public List<Quiz> GetQuizzes()
		{
			return QuizList;
		}

		public async Task<Quiz> PostQuiz(int maxPlayerCount, int currentPlayerCount, RoomState roomState,List<Player> players)
		{
			Quiz quiz = new Quiz(maxPlayerCount, currentPlayerCount, roomState,players);
			QuizList.Add(quiz);
			return quiz;
		}

		public async Task<List<Quiz>> GenerateQuizzesAsync(int amount)
		{
			QuizList.Clear();
			for (int i = 0; i < amount; i++)
			{
				Random random = new Random();
				var roomStates = (RoomState[])Enum.GetValues(typeof(RoomState));

				var maxPlayerCount = random.Next(1, 20);
				var currentPlayerCount = maxPlayerCount - random.Next(0, maxPlayerCount);
				var roomState = roomStates[random.Next(0, roomStates.Length)];
				var quiz = new Quiz(maxPlayerCount, currentPlayerCount, roomState,GeneratePlayers(currentPlayerCount));
				QuizList.Add(quiz);
			}

			return QuizList;
		}

		public Task<string> GetQuizDataAsync()
		{
			return File.ReadAllTextAsync(@"C:\Users\Kijonka\source\repos\QuizMaster3000\README.md");
		}

		private List<Player> GeneratePlayers(int min = 10, int max = 20)
		{
			Random rand = new Random();
			int randomNum=rand.Next(min, max);
			List<Player> playerList=new List<Player>();
			int id;
			for (int i = 0; i < randomNum; i++)
			{
				id=rand.Next();
				playerList.Add(new Player(id,"hroch","hrosi rank","hrochov"));
			}
			return playerList;
		}
		private List<Player> GeneratePlayers(int playersAmount)
		{
			Random rand = new Random();
			List<Player> playerList = new List<Player>();
			int id;
			for (int i = 0; i < playersAmount; i++)
			{
				id = rand.Next();
				playerList.Add(new Player(id, "hroch", "hrosi rank", "hrochov"));
			}
			return playerList;
		}
	}
}