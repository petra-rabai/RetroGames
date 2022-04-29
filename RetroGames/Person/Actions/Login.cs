using RetroGames.Game.Actions;
using RetroGames.Person.Data;
using RetroGames.Person.Security;
using System.IO;
using System.Text;
using System.Xml;

namespace RetroGames.Person.Actions
{
	public class Login : ILogin
	{

		public bool IsLoggedIn { get; set; } = false;
		public string LoginName { get; set; }
		public string LoginPassword { get; set; }

		public void Start()
		{
			
		}
		
	}
}