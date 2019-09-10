﻿using System.Diagnostics.CodeAnalysis;
using System.IO;
using Orion.World.Tiles;

namespace Orion.Networking.Packets.World {
    /// <summary>
    /// Packet sent to paint a block.
    /// </summary>
    public sealed class PaintBlockPacket : Packet {
        /// <summary>
        /// Gets or sets the tile's X coordinate.
        /// </summary>
        public short TileX { get; set; }

        /// <summary>
        /// Gets or sets the tile's Y coordinate.
        /// </summary>
        public short TileY { get; set; }

        /// <summary>
        /// Gets or sets the block color.
        /// </summary>
        public PaintColor BlockColor { get; set; }

        private protected override PacketType Type => PacketType.PaintBlock;

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() => $"{Type}[{BlockColor} @ ({TileX}, {TileY})]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            TileX = reader.ReadInt16();
            TileY = reader.ReadInt16();
            BlockColor = (PaintColor)reader.ReadByte();
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(TileX);
            writer.Write(TileY);
            writer.Write((byte)BlockColor);
        }
    }
}
