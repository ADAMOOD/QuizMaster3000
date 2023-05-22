namespace QuizMaster3000.Models
{
	public class Quiz
	{
		public int MaxPlayerCount { get; set; }
		public int CurrentPlayerCount { get; set; }
		public RoomState RoomState { get; set; }
		public DateTime CreatedAt { get; set; }


		public Quiz(int maxPlayerCount, int currentPlayerCount, RoomState roomState)
		{
			MaxPlayerCount = maxPlayerCount;
			CurrentPlayerCount = currentPlayerCount;
			CreatedAt = DateTime.Now;
			RoomState = roomState;
		}
	}
}
