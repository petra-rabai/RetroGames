﻿using System.IO;
using System.Text;
using System.Xml;

namespace RetroGames.Person.Actions
{
	public class Login : ILogin
	{
		private IInstallation _installation;
		private IStringCryptographer _stringCryptographer;

		public Login(IInstallation installation, IStringCryptographer stringCryptographer)
		{
			_installation = installation;
			_stringCryptographer = stringCryptographer;
		}

		public bool IsLoggedIn { get; set; } = false;
		public string LoginName { get; set; }
		public string LoginPassword { get; set; }

		public void GetLoginDataFromXML()
		{
			_installation.CheckInstallationSuccess();

			ReadLoginData();
		}

		private void ReadLoginData()
		{
			XmlDocument loginData = new();

			StreamReader loginDataReader = new(_installation.UserFilePath, Encoding.UTF8);
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
						LoginPassword = _stringCryptographer.Decrypt(loginNode.ChildNodes.Item(i).InnerText);
					}
				}
			}
		}
	}
}