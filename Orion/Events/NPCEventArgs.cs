﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Events
{
	public class NPCEventArgs : EventArgs
	{
		public Terraria.NPC NPC { get; set; }
	}
}