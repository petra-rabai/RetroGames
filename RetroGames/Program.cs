using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RetroGames
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Password password = new Password();
			
			password.GetPlayerPassword();
			
			Console.ReadLine();

		}
	}
}
