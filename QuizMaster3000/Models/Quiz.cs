namespace QuizMaster3000.Models
{
	public class Quiz
	{
		private int MaxPlayerCount { get; set; }
		private int CurrentPlayerCount { get; set; }
		private RoomState RoomState { get; set; }
		private DateTime CreatedAt { get; set; }


		public Quiz(int maxPlayerCount, int currentPlayerCount, RoomState roomState)
		{
			MaxPlayerCount = maxPlayerCount;
			CurrentPlayerCount = currentPlayerCount;
			CreatedAt = DateTime.Now;
			RoomState = roomState;
		}
	}
}
