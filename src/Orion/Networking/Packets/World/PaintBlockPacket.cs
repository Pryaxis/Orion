﻿// Copyright (c) 2015-2019 Pryaxis & Orion Contributors
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

using System.Diagnostics.CodeAnalysis;
using System.IO;
using Orion.World.Tiles;

namespace Orion.Networking.Packets.World {
    /// <summary>
    /// Packet sent to paint a block.
    /// </summary>
    public sealed class PaintBlockPacket : Packet {
        /// <summary>
        /// Gets or sets the block's X coordinate.
        /// </summary>
        public short BlockX { get; set; }

        /// <summary>
        /// Gets or sets the block's Y coordinate.
        /// </summary>
        public short BlockY { get; set; }

        /// <summary>
        /// Gets or sets the block color.
        /// </summary>
        public PaintColor BlockColor { get; set; }

        internal override PacketType Type => PacketType.PaintBlock;

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() => $"{Type}[{BlockColor} @ ({BlockX}, {BlockY})]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            BlockX = reader.ReadInt16();
            BlockY = reader.ReadInt16();
            BlockColor = (PaintColor)reader.ReadByte();
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(BlockX);
            writer.Write(BlockY);
            writer.Write((byte)BlockColor);
        }
    }
}
