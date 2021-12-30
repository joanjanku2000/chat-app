
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Chat_application_with_windows_forms.Security
{
    class PasswordHash
    {
		private static string GetRandomSalt()
		{
			return BCrypt.Net.BCrypt.GenerateSalt(12);
		}

		public static string HashPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
		}

		public static bool ValidatePassword(string password, string correctHash)
		{
			Console.WriteLine("Got psw from db {0}", correctHash);
			Console.WriteLine("GIven psw is {0}", password);
			return BCrypt.Net.BCrypt.Verify(password, correctHash);
		}
	}
}
