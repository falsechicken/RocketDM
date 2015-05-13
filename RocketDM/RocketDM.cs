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
using subSpace = FC.Subspace.Subspace;

namespace FC.RocketDM
{

	public class RocketDM : RocketPlugin
	{
		
		private DMSubspaceReceiver sReceiver;
		
		private ushort rdmSubspaceEventChannel;
		
		public static readonly System.Random random = new System.Random();
		
		public static LogHelper logHelper = new LogHelper("RocketDM");
		
		protected override void Load()
		{
			
			subSpace.SetDebugMode(true);
			
			sReceiver = new DMSubspaceReceiver("rdmReceiver", this);
			
			rdmSubspaceEventChannel = subSpace.GetUnusedChannel();
			
			subSpace.CreateChannel("rocketdm", rdmSubspaceEventChannel);
			
			subSpace.SubscribeToChannel(rdmSubspaceEventChannel, sReceiver);
			
			RocketPlayerEvents.OnPlayerRevive += OnPlayerRespawn;
			RocketPlayerEvents.OnPlayerDeath += OnPlayerDeath;
			RocketServerEvents.OnPlayerConnected += OnPlayerConnect;
			
		}
		
		public void FixedUpdate()
		{
			
		}
		
		#region EVENT HANDLERS
		
		private void OnPlayerRespawn(RocketPlayer _player, Vector3 position, byte angle)
		{
			
		}
		
		private void OnPlayerConnect(RocketPlayer _rPlayer)
		{
			
		}
		
		private void OnPlayerDeath(RocketPlayer _player, EDeathCause _cause, ELimb _limb, CSteamID _murderer)
		{
			var deathMessage = CreateDeathSubspaceMessage(_player, _cause, _limb, _murderer);
			
			subSpace.SendSubspaceMessage(SubspaceReservedChannels.STATS, deathMessage);
			                            
			subSpace.SendSubspaceMessage(rdmSubspaceEventChannel, deathMessage);
		}
		
		private bool WasDeathAMurder(EDeathCause _cause, CSteamID _murderer)
		{
			if (RocketPlayer.FromCSteamID(_murderer) == null) //He we have no murdering player then it was not a kill.
				return false;
			
			return true;
		}
		
		private SubspaceMessage CreateDeathSubspaceMessage(RocketPlayer _player, EDeathCause _cause, ELimb _limb, CSteamID _murderer)
		{
			var deathMessage = new SubspaceMessage("rdmDeathEvent");
			
			deathMessage.SetMessageCode(DMSubspaceMessageCodes.PLAYER_KILLED);
			deathMessage.AddToPlayerList(_player);
			deathMessage.AddToPlayerList(RocketPlayer.FromCSteamID(_murderer));
			deathMessage.AddToInstructionList(_cause.ToString());
			deathMessage.SetBoolean(WasDeathAMurder(_cause, _murderer)); //If the death was a murder or not.
			
			return deathMessage;
		
		}
		#endregion
		
	}
}