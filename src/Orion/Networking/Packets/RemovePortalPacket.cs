﻿using System.IO;

namespace Orion.Networking.Packets {
    /// <summary>
    /// Packet sent to the server to remove a portal.
    /// </summary>
    public sealed class RemovePortalPacket : Packet {
        /// <summary>
        /// Gets or sets the portal's projectile index.
        /// </summary>
        public short PortalProjectileIndex { get; set; }

        private protected override void ReadFromReader(BinaryReader reader, ushort packetLength) =>
            PortalProjectileIndex = reader.ReadInt16();

        private protected override void WriteToWriter(BinaryWriter writer) => writer.Write(PortalProjectileIndex);
    }
}