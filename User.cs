//Copyright (C) 2011, FIE LLC.

//See LICENSE.TXT for details.

using System;
using System.Collections.Generic;

namespace libuser
{
    /// <summary>
    /// Abstract baseclass for users.
    /// </summary>
	public abstract class User
	{
		internal User (string username)
		{
			this.username = username;
		}
		
		private string username;

		public string Username {
			get {
				return this.username;
			}
		}
		
		public abstract string GetHomeDir();
		public abstract string GetBzrBranchesDir();
	}
	
    /// <summary>
    /// Implementation of the Current User.
    /// </summary>
	public class CurrentUser : User{
		
		public Dictionary<string,string> GetEditors(){
			//todo: we really need to do this with a config file in the user directory.  not hard coded.
			Dictionary<string,string> ret = new Dictionary<string, string>();
			if (libplatform.CurrentPlatform.IsOSX()){
				ret["sln"] = "open -n -W";
			} else if (libplatform.CurrentPlatform.IsWindows()){
				ret["sln"] = "start /WAIT c:\\Program Files\\Microsoft Visual Studio 9.0\\Common7\\IDE\\devenv.exe";
			} else {
				//todo investigate and implement blocking mono dev calls here.
				throw new NotImplementedException();
			}
			return ret;
		}
		
		internal CurrentUser (string username) : base(username){
		}
		
		public override string GetHomeDir ()
		{
			return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		}

		public override string GetBzrBranchesDir ()
		{
			return System.IO.Path.Combine(GetHomeDir(),"bzr_branches");
		}
		
	}

    //TODO: consier implementing other users.
}

