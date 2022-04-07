using System.IO;
using System.Text;
using System.Xml;

namespace RetroGames
{
	public class Login : ILogin
	{
		private IGameFile gameFile;
		private IStringCryptographer stringCryptographer;

		public Login(IGameFile gameFile, IStringCryptographer stringCryptographer)
		{
			this.gameFile = gameFile;
			this.stringCryptographer = stringCryptographer;
		}

		public bool IsLoggedIn { get; set; } = false;
		public string LoginName { get; set; }
		public string LoginPassword { get; set; }

		public void GetLoginDataFromXML()
		{
			gameFile.CheckGameFilesCreated();
			ReadLoginData();
		}

		private void ReadLoginData()
		{
			XmlDocument loginData = new XmlDocument();
			
			StreamReader loginDataReader = new StreamReader(gameFile.UserFilePath, Encoding.UTF8);
			string loginDataContent = loginDataReader.ReadToEnd();
			loginData.LoadXml(loginDataContent);
			XmlNodeList loginDataList = loginData.GetElementsByTagName("RegistrationData");
			
			foreach (XmlNode loginNode in loginDataList)
			{
				
				for (int i = 0; i < loginNode.ChildNodes.Count; i++)
				{
					if (loginNode.ChildNodes.Item(i).Name == "LoginName")
					{
						LoginName = loginNode.ChildNodes.Item(i).InnerText;
					}
					else if (loginNode.ChildNodes.Item(i).Name == "Password")
					{
						LoginPassword = stringCryptographer.Decrypt(loginNode.ChildNodes.Item(i).InnerText);
					}	
				}

			}

		}


	}
}
