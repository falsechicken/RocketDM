 /*****
 * -- <TITLE>  --
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
using FC.Subspace;
using Rocket.RocketAPI;
using Rocket.Logging;

using subSpace = FC.Subspace.Subspace;
using subspaceMessageCodes = FC.RocketDM.DMSubspaceMessageCodes;

namespace FC.RocketDM
{
	public class DMSubspaceReceiver : SubspaceReceiver
	{
		RocketDM parent;
		
		public DMSubspaceReceiver(string _receiverID, RocketDM _parent) : base(_receiverID)
		{
			parent = _parent;
		}
		
		public override void ReceiveMessage(SubspaceMessage _message)
		{
			Logger.Log(receiverID + " has received message " + _message.GetTitle());
		}
	}
}
