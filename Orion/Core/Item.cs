﻿using System;
using Microsoft.Xna.Framework;
using Orion.Interfaces;

namespace Orion.Core
{
	/// <summary>
	/// Wraps a Terraria item.
	/// </summary>
	public class Item : IItem
	{
		/// <summary>
		/// Gets the item's damage.
		/// </summary>
		public int Damage => WrappedItem.damage;

		/// <summary>
		/// Gets the item's maximum stack size.
		/// </summary>
		public int MaxStack => WrappedItem.maxStack;

		/// <summary>
		/// Gets the item's name.
		/// </summary>
		public string Name => WrappedItem.name;

		/// <summary>
		/// Gets or sets the item's position in the world.
		/// </summary>
		public Vector2 Position
		{
			get { return WrappedItem.position; }
			set { WrappedItem.position = value; }
		}

		/// <summary>
		/// Gets or sets the item's prefix.
		/// </summary>
		public byte Prefix
		{
			get { return WrappedItem.prefix; }
			set { WrappedItem.prefix = value; }
		}

		/// <summary>
		/// Gets or sets the item's stack size.
		/// </summary>
		public int Stack
		{
			get { return WrappedItem.stack; }
			set { WrappedItem.stack = value; }
		}

		/// <summary>
		/// Gets the item's type ID.
		/// </summary>
		public int Type => WrappedItem.netID;

		/// <summary>
		/// Gets or sets the item's velocity in the world.
		/// </summary>
		public Vector2 Velocity
		{
			get { return WrappedItem.velocity; }
			set { WrappedItem.velocity = value; }
		}

		/// <summary>
		/// Gets the wrapped Terraria item.
		/// </summary>
		public Terraria.Item WrappedItem { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Item"/> class wrapping the specified Terraria item.
		/// </summary>
		/// <param name="terrariaItem">The Terraria item to wrap.</param>
		/// <exception cref="ArgumentNullException"><paramref name="terrariaItem"/> was null.</exception>
		public Item(Terraria.Item terrariaItem)
		{
			if (terrariaItem == null)
			{
				throw new ArgumentNullException(nameof(terrariaItem));
			}

			WrappedItem = terrariaItem;
		}
	}
}