﻿using System;
using Orion.Interfaces;

namespace Orion.Events.Npc
{
	/// <summary>
	/// Provides data for the <see cref="INpcService.NpcSpawned"/> event.
	/// </summary>
	public class NpcSpawnedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the <see cref="INpc"/> that spawned.
		/// </summary>
		public INpc Npc { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="NpcSpawnedEventArgs"/> class.
		/// </summary>
		/// <param name="npc">The <see cref="INpc"/> that spawned.</param>
		/// <exception cref="ArgumentNullException"><paramref name="npc"/> was null.</exception>
		public NpcSpawnedEventArgs(INpc npc)
		{
			if (npc == null)
			{
				throw new ArgumentNullException(nameof(npc));
			}

			Npc = npc;
		}
	}
}