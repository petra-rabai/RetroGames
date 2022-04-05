using System;
using System.Collections.Generic;
using System.IO;
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

		public void GetLoginDataFromXML(GameFile gameFile, Drive drive, GameDirectory gameDirectory, StringCryptographer stringCryptographer)
		{
			gameFile.CheckGameFilesCreated(drive, gameDirectory);
			ReadLoginData(gameFile, stringCryptographer);
		}

		private void ReadLoginData(GameFile gameFile, StringCryptographer stringCryptographer)
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
