﻿// Copyright (c) 2020 Pryaxis & Orion Contributors
// 
// This file is part of Orion.
// 
// Orion is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Orion is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Orion.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Runtime.InteropServices;
using Orion.Core.Utils;
using Orion.Core.World.Tiles;

namespace Orion.Core.Packets.World.Tiles
{
    /// <summary>
    /// A packet sent to set a tile's liquid.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct TileLiquid : IPacket
    {
        [FieldOffset(0)] private byte _bytes;  // Used to obtain an interior reference.

        /// <summary>
        /// Gets or sets the tile's X coordinate.
        /// </summary>
        /// <value>The tile's X coordinate.</value>
        [field: FieldOffset(0)] public short X { get; set; }

        /// <summary>
        /// Gets or sets the tile's Y coordinate.
        /// </summary>
        /// <value>The tile's Y coordinate.</value>
        [field: FieldOffset(2)] public short Y { get; set; }

        /// <summary>
        /// Gets or sets the tile's liquid amount. This ranges from <c>0</c> to <c>255</c>.
        /// </summary>
        /// <value>The tile's liquid amount.</value>
        [field: FieldOffset(4)] public byte Amount { get; set; }

        /// <summary>
        /// Gets or sets the tile's liquid type.
        /// </summary>
        /// <value>The tile's liquid type.</value>
        [field: FieldOffset(5)] public LiquidType Type { get; set; }

        PacketId IPacket.Id => PacketId.TileLiquid;

        int IPacket.ReadBody(Span<byte> span, PacketContext context) => span.Read(ref _bytes, 6);

        int IPacket.WriteBody(Span<byte> span, PacketContext context) => span.Write(ref _bytes, 6);
    }
}
