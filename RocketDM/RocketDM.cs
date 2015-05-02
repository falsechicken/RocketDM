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
using System.Collections.Generic;
using Rocket.RocketAPI;

namespace FC.RocketDM
{

	public class RocketDM : RocketPlugin
	{
		
		Dictionary<string, List<RocketPlayer>> teamRegistry; //Store the teams and a list of players on said team.
		
		
		
		
		protected override void Load()
		{
			teamRegistry = new Dictionary<string, List<RocketPlayer>>();
		}
		
		public void FixedUpdate()
		{
			
		}
	}
}