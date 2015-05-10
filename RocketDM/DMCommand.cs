 /*****
 * -- DMCommand -- 
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
using Rocket.Logging;
using FC.Subspace;
using subSpace = FC.Subspace.Subspace;

namespace FC.RocketDM
{
    public class DMCommand : IRocketCommand
    {
        public bool RunFromConsole
        {
            get { return true; }
        }

        public string Name
        {
            get { return "rdm"; }
        }

        public string Help
        {
            get { return "Root RDM Command.";}
        }

        public void Execute(RocketPlayer caller, string command)
        {
        	string[] cmds = command.Split(null);
        	
        	bool isServer;
        	
        	bool isAdmin;
        	
        	string charName;
        	
        	try { charName = caller.CharacterName; isServer = false; isAdmin = caller.IsAdmin; } //Mainly to fix exceptions when user is typing commands from the server console.
        	catch (NullReferenceException n) { charName = "Server"; isServer = true; isAdmin = true; }
        	
        	if (cmds[0].ToLower().Equals("match") && isAdmin) { 
        		ProcessMatchCommand(caller, cmds);
        		return;
        	}
            
        }
        
        private void ProcessMatchCommand(RocketPlayer _caller, string[] _cmds)
        {
        	var matchMessage = new SubspaceMessage("rdmMatchCommand");
        	
        	subSpace.SendSubspaceMessage(subSpace.GetChannelFromName("rocketdm"), matchMessage);
        	subSpace.SendSubspaceMessage(SubspaceReservedChannels.STATS, matchMessage);
        }
        
        private void ProcessStartCommand(RocketPlayer _caller, string[] _cmds)
        {
        	
        }
    }
}
