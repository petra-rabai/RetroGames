using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RetroGames
{
	public class Login : ILogin
	{
		public bool IsLoggedIn { get; set; } = false;
		public string LoginName { get; set; }
		public string LoginPassword { get; set; }

		XmlReader dataReader;

		public void GetLoginDataFromXML(GameFile gameFile,Drive drive, GameDirectory gameDirectory, PasswordDeCrypter passwordDeCrypter)
		{
			gameFile.CheckGameFilesCreated(drive, gameDirectory);
			ReadLoginData(gameFile, passwordDeCrypter);
		}

		private void ReadLoginData(GameFile gameFile, PasswordDeCrypter passwordDeCrypter)
		{
			string filePath = gameFile.UserFilePath;
			dataReader = XmlReader.Create(filePath);

			while (dataReader.Read())
			{
				if (dataReader.IsStartElement())
				{
					switch (dataReader.Name.ToString())
					{
						case "LoginName":
							LoginName = dataReader.ReadString();
							break;
						case "Password":
							LoginPassword = passwordDeCrypter.DecryptPassword(dataReader.ReadString());
							break;
						default:
							break;
					}

				}
			}
		}



	}
}
