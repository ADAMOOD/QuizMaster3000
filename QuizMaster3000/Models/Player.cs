namespace QuizMaster3000.Models
{
	public class Player
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Rank { get; set; }
		public string Country { get; set; }

		public Player(int id, string name, string rank, string country)
		{
			Country = country;
			Id = id;
			Name = name;
			Rank = rank;
		}
	}
}