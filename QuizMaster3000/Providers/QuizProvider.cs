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

		public async Task<Quiz> PostQuizAsync(int maxPlayerCount, int currentPlayerCount, RoomState roomState,List<Player> players)
		{
			var quiz = new Quiz(maxPlayerCount, currentPlayerCount, roomState,players);
			QuizList.Add(quiz);
			return quiz;
		}

		public async Task<List<Quiz>> GenerateQuizzesAsync(int amount)
		{
			QuizList.Clear();
			for (var i = 0; i < amount; i++)
			{
				var random = new Random();
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
			var rand = new Random();
			var randomNum=rand.Next(min, max);
			var playerList=new List<Player>();
			for (var i = 0; i < randomNum; i++)
			{
				var id = rand.Next();
				playerList.Add(new Player(id,"hroch","hrosi rank","hrochov"));
			}
			return playerList;
		}
		private List<Player> GeneratePlayers(int playersAmount)
		{
			var rand = new Random();
			var playerList = new List<Player>();
			for (var i = 0; i < playersAmount; i++)
			{
				var id = rand.Next();
				playerList.Add(new Player(id, "hroch", "hrosi rank", "hrochov"));
			}
			return playerList;
		}
	}
}