 /*****
  * -- RocketDM: Deathmatch Plugin For Rocket --
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
using Rocket.RocketAPI.Events;
using SDG;
using Steamworks;
using UnityEngine;
using FC.Subspace;
using fc.logman;
using subSpace = FC.Subspace.Subspace;

namespace FC.RocketDM
{

	public class RocketDM : SubspaceRocketPlugin
	{
		LogMan logMan = new LogMan();
		
		protected override void Load()
		{
			subSpace.CreateChannel("rocketdm", subSpace.GetUnusedChannel());
			subSpace.SubscribeToChannel(subSpace.GetChannelFromName("rocketdm"), this);
			
			RocketPlayerEvents.OnPlayerRevive += OnPlayerRespawn;
			RocketPlayerEvents.OnPlayerDeath += OnPlayerDeath;
			
			RocketServerEvents.OnPlayerConnected += OnPlayerConnect;
			
		}
		
		public void FixedUpdate()
		{
			
		}
		
		public override void ReceiveMessage(SubspaceMessage _message)
		{
			
		}
		
		private void OnPlayerRespawn(RocketPlayer _player, Vector3 position, byte angle)
		{
			
		}
		
		private void OnPlayerConnect(RocketPlayer _rPlayer)
		{
			
		}
		
		private void OnPlayerDeath(RocketPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
		{
			
		}
	}
}