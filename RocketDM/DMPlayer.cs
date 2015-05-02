 /*****
 * -- DMPlayer -- 
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
using Rocket.RocketAPI;

namespace RocketDM
{
	public class DMPlayer
	{
		
		RocketPlayer rPlayer;
		string pTeam;
		string pClass;
		string pClanTag;
		int pkills;
		int pTeamKills;
		int pScore;
		
		public DMPlayer(RocketPlayer _rPlayer)
		{
			rPlayer = _rPlayer;
		}
		
		public DMPlayer(RocketPlayer _rPlayer, string _pTeam, string _pClass)
		{
			rPlayer = _rPlayer;
			pTeam = _pTeam;
			pClass = _pClass;
		}
		
		#region GETTERS
		
		public RocketPlayer GetRocketPlayer()
		{
			return rPlayer;
		}
		
		public string GetTeam()
		{
			return pTeam;
		}
		
		public string GetClass()
		{
			return pClass;
		}
		
		public string GetClanTag()
		{
			return pClanTag;
		}
		
		public int GetKills()
		{
			return pkills;
		}
		
		public int GetTeamKills()
		{
			return pTeamKills;
		}
		
		public int GetScore()
		{
			return pScore;
		}
		
		#endregion
		
		#region SETTERS
		
		public void SetTeam(string _team)
		{
			pTeam = _team;
		}
		
		public void SetClass(string _class)
		{
			pClass = _class;
		}
		
		public void SetClanTag(string _clanTag)
		{
			pClanTag = _clanTag;
		}
		
		public void SetKills(int _kills)
		{
			pkills = _kills;
		}
		
		public void SetTeamKills(int _teamKills)
		{
			pTeamKills = _teamKills;
		}
		
		public void SetScore(int _score)
		{
			pScore = _score;
		}
		
		#endregion
		
		#region PUBLIC METHODS
		
		public void IncrementKills()
		{
			pkills+=1;
		}
		
		public void DecrementKills()
		{
			pkills-=1;
		}
		
		public void IncreaseKills(int _killsIncrease)
		{
			pkills = pkills + _killsIncrease;
		}
		
		public void DecreaseKills(int _killsDecrease)
		{
			pkills = pkills - _killsDecrease;
		}
		
		public void IncrementTeamKills()
		{
			pTeamKills+=1;
		}
		
		public void DecrementTeamKills()
		{
			pTeamKills-=1;
		}
		
		public void IncreaseTeamKills(int _teamKillsIncrease)
		{
			pTeamKills = pTeamKills + _teamKillsIncrease;
		}
		
		public void DecreaseTeamKills(int _teamKillsDecrease)
		{
			pTeamKills = pTeamKills - _teamKillsDecrease;
		}
		
		public void IncrementScore()
		{
			pScore+=1;
		}
		
		public void DecrementScore()
		{
			pScore-=1;
		}
		
		public void IncreaseScore(int _scoreIncrease)
		{
			pScore = pScore + _scoreIncrease;
		}
		
		public void DecreaseScore(int _scoreDecrease)
		{
			pScore = pScore - _scoreDecrease;
		}
		
		#endregion
	}
}
