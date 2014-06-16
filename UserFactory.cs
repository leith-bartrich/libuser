//Copyright (C) 2011, FIE LLC.

//See LICENSE.TXT for details.

using System;
using System.Collections.Generic;

namespace libuser
{
	public static class UserFactory
	{
		
        //internal cache makers sure we only ever have one user object per user per process.
		private static Dictionary<string, User> usersCache = new Dictionary<string, User>();
		
        /// <summary>
        /// Gets the current user.  Multiple calls will return a reference to the same object.
        /// </summary>
        /// <returns>The current user.</returns>
		public static User GetCurrentUser(){
			string username = System.Environment.UserName;
			if (!usersCache.ContainsKey(username)){
				User u = new CurrentUser(System.Environment.UserName);
				usersCache[username] = u;
			}
			return usersCache[username];
		}
		
	}
}

