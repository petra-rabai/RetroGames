using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroGames.Player;

namespace RetroGames
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Playerx player = new Playerx();
			player.GetPlayerPassword();
			Console.ReadLine();
			PlayerFirstName playerFirstName = new PlayerFirstName();
			PlayerLastName playerLastName = new PlayerLastName();
			PlayerLoginName playerLoginName = new PlayerLoginName();
			PlayerPassword playerPassword = new PlayerPassword();
			PlayerEmail playerEmail = new PlayerEmail();
			PlayerRegistration playerRegistration = new PlayerRegistration();
			playerRegistration.Registration(playerFirstName,
								   playerLastName,
								   playerLoginName,
								   playerPassword,
								   playerEmail);
			


		}
	}
}
