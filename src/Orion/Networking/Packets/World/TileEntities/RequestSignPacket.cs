﻿using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Orion.Networking.Packets.World.TileEntities {
    /// <summary>
    /// Packet sent from the client to the server to request a sign.
    /// </summary>
    public sealed class RequestSignPacket : Packet {
        /// <summary>
        /// Gets or sets the sign's X coordinate.
        /// </summary>
        public short SignX { get; set; }

        /// <summary>
        /// Gets or sets the sign's Y coordinate.
        /// </summary>
        public short SignY { get; set; }

        private protected override PacketType Type => PacketType.RequestSign;

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() => $"{Type}[({SignX}, {SignY})]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            SignX = reader.ReadInt16();
            SignY = reader.ReadInt16();
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(SignX);
            writer.Write(SignY);
        }
    }
}
