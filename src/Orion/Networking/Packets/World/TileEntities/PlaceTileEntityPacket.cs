﻿using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Orion.Networking.Packets.World.TileEntities {
    /// <summary>
    /// Packet sent from the client to the server to place a tile entity.
    /// </summary>
    public sealed class PlaceTileEntityPacket : Packet {
        /// <summary>
        /// Gets or sets the tile entity's X coordinate.
        /// </summary>
        public short TileEntityX { get; set; }

        /// <summary>
        /// Gets or sets the tile entity's Y coordinate.
        /// </summary>
        public short TileEntityY { get; set; }

        /// <summary>
        /// Gets or sets the tile entity type.
        /// </summary>
        public TileEntityType TileEntityType { get; set; }

        private protected override PacketType Type => PacketType.PlaceTileEntity;

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() => $"{Type}[{TileEntityType} @ ({TileEntityX}, {TileEntityY})]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            TileEntityX = reader.ReadInt16();
            TileEntityY = reader.ReadInt16();
            TileEntityType = (TileEntityType)reader.ReadByte();
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(TileEntityX);
            writer.Write(TileEntityY);
            writer.Write((byte)TileEntityType);
        }
    }
}
