 /*****
 * -- DMTeam: Represnets a team. --
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
using FC.Subspace;
using subSpace = FC.Subspace.Subspace;

namespace FC.RocketDM
{
	public class DMTeam
	{
		string dmTeamName;
		
		int dmTotalTeamKills;
		int  dmTotalTeamDeaths;
		
		List<string> dmRivalTeams;
		
		List<string> dmFriendlyTeams;
		
		List<DMPlayer> dmTeamMembers;
		
		#region CONSTRUCTORS
		
		public DMTeam(string _teamName)
		{
			dmTeamName = _teamName;
			
			dmRivalTeams = new List<string>();
			
			dmFriendlyTeams = new List<string>();
			
			dmTeamMembers = new List<DMPlayer>();
		}
		
		public DMTeam(string _teamName, List<string> _rivalTeams, List<string> _friendlyTeams )
		{
			dmTeamName = _teamName;
			
			dmRivalTeams = _rivalTeams;
			
			dmFriendlyTeams = _friendlyTeams;
			
			dmTeamMembers = new List<DMPlayer>();
		}
		
		public DMTeam(string _teamName, List<string> _rivalTeams, List<string> _friendlyTeams, List<DMPlayer> _teamMembers)
		{
			dmTeamName = _teamName;
			
			dmRivalTeams = _rivalTeams;
			
			dmFriendlyTeams = _friendlyTeams;
			
			dmTeamMembers = _teamMembers;
		}
		
		#endregion
		
		#region SETTERS
		
		public void SetTeamName(string _teamName)
		{
			SubspaceMessage teamNameChangeMessage = new SubspaceMessage("rdmTeamNameChange");
			
			teamNameChangeMessage.AddToInstructionList(dmTeamName);
			teamNameChangeMessage.AddToInstructionList(_teamName);
			teamNameChangeMessage.SetMessageCode(DMSubspaceMessageCodes.TEAM_NAME_CHANGE);
			
			subSpace.SendSubspaceMessage(subSpace.GetChannelFromName("rocketdm"), teamNameChangeMessage); //Send message to inform anyone who needs to know that the team name has changed.
			
			dmTeamName = _teamName;
		}
		
		public void IncrementTeamKills()
		{
			dmTotalTeamKills+=1;
		}
		
		public void DecrementTeamKills()
		{
			dmTotalTeamKills-=1;
		}
		
		public void IncreaseTeamKills(int _teamKillIncrease)
		{
			dmTotalTeamKills = dmTotalTeamKills + _teamKillIncrease;
		}
		
		public void DecreaseTeamKills(int _teamKillDecrease)
		{
			dmTotalTeamKills = dmTotalTeamKills - _teamKillDecrease;
		}
		
		public void IncrementTeamDeaths()
		{
			dmTotalTeamDeaths+=1;
		}
		
		public void DecrementTeamDeaths()
		{
			dmTotalTeamDeaths-=1;
		}
		
		public void IncreaseTeamDeaths(int _teamDeathIncrease)
		{
			dmTotalTeamDeaths = dmTotalTeamDeaths + _teamDeathIncrease;
		}
		
		public void DecreaseTeamDeaths(int _teamDeathDecrease)
		{
			dmTotalTeamDeaths = dmTotalTeamDeaths = _teamDeathDecrease;
		}
		
		#endregion
		
		#region GETTERS
		
		public string GetTeamName()
		{
			return dmTeamName;
		}
		
		public int GetTeamKills()
		{
			return dmTotalTeamKills;
		}
		
		public int GetTeamDeaths()
		{
			return dmTotalTeamDeaths;
		}
		
		public List<string> GetRivalTeams()
		{
			return dmRivalTeams;
		}
		
		public List<string> GetFriendlyTeams()
		{
			return dmFriendlyTeams;
		}
		
		public List<DMPlayer> GetTeamMembers()
		{
			return dmTeamMembers;
		}
		
		public int GetTeamMemberCount()
		{
			return dmTeamMembers.Count;
		}
		
		#endregion
	}
}
