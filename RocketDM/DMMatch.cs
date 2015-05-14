﻿/*****
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
using logger = Rocket.Logging.Logger;

namespace FC.RocketDM
{
	public class DMMatch
	{
		LogHelper logHelper = RocketDM.logHelper;
		
		string dmMatchTitle;
		
		private int dmMatchTimeLimitSeconds;
		private int dmTimeRemainingSeconds;
		private int dmKillLimit;
		private Vector3 dmMatchLocation;
		
		private Dictionary<string, Vector3> dmMatchSpawnPoints;
		private List<ushort> dmAutoSpawnIDs; //Keep track of auto generated IDs so we do not generate the same one twice.
		
		private bool dmTeamPlayEnabled;
		private bool dmFriendlyFireEnabled;
		private bool dmTimeLimitEnabled;
		private bool dmKillLimitEnabled;
		private bool dmMatchLive;
		private bool dmHardcoreModeEnabled;
		
		private List<DMTeam> dmActiveTeamList;
		
		public DMMatch(string _matchTitle)
		{
			dmMatchTitle = _matchTitle;
		}
		
		#region PUBLIC METHODS
		
		public void UpdateMatch()
		{
			
		}
		
		public void StartMatch()
		{
			
		}
		
		public void EndMatch()
		{
			
		}
		
		#endregion
		
		#region PRIVATE METHODS

		/*
		 * Gets an unused spawn ID.
		 */
		private ushort GetRandomSpawnID()
		{
			ushort tempSpawnID;
			
			while (true) //Keep going until we find a free ID.
			{
				tempSpawnID = (ushort) RocketDM.random.Next(1, ushort.MaxValue); //ID 0 is reserved for errors in parsing.
				
				if (dmAutoSpawnIDs.Contains(tempSpawnID) == false) //If the spawnID is not in the list then we can return it as free.
				{
					return tempSpawnID;
				}
			}
		}
		
		private string SpawnIDUShortToString(ushort _spawnID)
		{
			return _spawnID.ToString();
		}
		
		private ushort SpawnIDStringToUShort(string _spawnIDString)
		{
			try
			{
				return ushort.Parse(_spawnIDString);
			}
			catch (InvalidCastException ex)
			{
				logger.LogException(ex);
				return 0;
			}
		}
		
		private bool IsSpawnIDAutogenerated(string _spawnIDString)
		{
			ushort spawnID;
			
			try
			{
				spawnID = SpawnIDStringToUShort(_spawnIDString);
				
				if (dmAutoSpawnIDs.Contains(spawnID)) { return true; }
				
				return false;
			}
			catch (InvalidCastException ex)
			{
				return false;
			}
		}
		
		#endregion
		
		#region SETTERS
		
		public void SetMatchLocation(Vector3 _location)
		{
			dmMatchLocation = _location;
		}
		
		public void SetMatchTimeLimitInSeconds(ushort _timeInSeconds)
		{
			dmMatchTimeLimitSeconds = _timeInSeconds;
		}
		
		public void SetMatchTimeLimitInMinutes(ushort _timeInMinutes)
		{
			dmMatchTimeLimitSeconds = _timeInMinutes * 60;
		}
		
		public void SetMatchKillLimit(ushort _killLimit)
		{
			dmKillLimit = _killLimit;
		}
		
		public bool AddToSpawnList(Vector3 _spawnLocation)
		{
			dmMatchSpawnPoints.Add(SpawnIDUShortToString(GetRandomSpawnID()), _spawnLocation);
			return true;
		}
		
		public bool AddToSpawnList(string _spawnIDString, Vector3 _spawnLocation)
		{
			try
			{
				dmMatchSpawnPoints.Add(_spawnIDString, _spawnLocation);
				return true;
			}
			catch (ArgumentException ex)
			{
				return false; //Return false if the same name is already in the Spawn dictionary.
			}
		}
		
		public bool RemoveFromSpawnList(string _spawnIDString)
		{
			if (IsSpawnIDAutogenerated(_spawnIDString)) //Remove ID from auto ID list if it exists.
				dmAutoSpawnIDs.Remove(SpawnIDStringToUShort(_spawnIDString));
			
			foreach (string spawnIDString in dmMatchSpawnPoints.Keys) //If the string is in the list remove it.
			{
				if (spawnIDString.Equals(_spawnIDString))
				{
					dmMatchSpawnPoints.Remove(_spawnIDString);
					return true;
				}
			}
			
			return false;
		}
		
		public void SetMatchLocation(Vector3 _matchLocation)
		{
			dmMatchLocation = _matchLocation;
		}
		
		#endregion
		
		
		
	}
}
