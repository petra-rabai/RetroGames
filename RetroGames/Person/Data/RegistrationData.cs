using System;

namespace RetroGames
{
	public class RegistrationData : IRegistrationData
	{
		public RegistrationData()
		{
			string Name = String.Empty;
			string LoginName = String.Empty;
			string Password = String.Empty;
			string Email = String.Empty;
		}
		public string Name { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
