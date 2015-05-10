 /*****
 * -- DMMatch -- 
 *
 * Copyright (C) 2015 False_Chicken
 * Contact: jmdevsupport@gmail.com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, Get it here: https://www.gnu.org/licenses/gpl-2.0.html
 *****/
 
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FC.RocketDM
{
	public class DMMatch
	{
		string dmMatchTitle;
		
		public int dmMatchTimeLimitSeconds;
		public int dmTimeRemainingSeconds;
		public int dmKillLimit;
		public Vector3 dmMatchLocation;
		
		public List<Vector3> dmMatchSpawnPoints;
		
		public bool dmTeamPlayEnabled;
		public bool dmFriendlyFireEnabled;
		public bool dmTimeLimitEnabled;
		public bool dmKillLimitEnabled;
		public bool dmMatchLive;
		public bool dmHardcoreModeEnabled;
		
		public List<DMTeam> dmActiveTeamList;
		
		public DMMatch(string _matchTitle)
		{
			dmMatchTitle = _matchTitle;
		}
		
		#region PUBLIC METHODS
		
		public void SetMatchLocation(Vector3 _location)
		{
			dmMatchLocation = _location;
		}
		
		
		#region SETTERS
		
		
		#endregion
		
	}
}
