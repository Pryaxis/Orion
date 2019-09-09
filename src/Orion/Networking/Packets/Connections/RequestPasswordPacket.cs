﻿using System.IO;

namespace Orion.Networking.Packets.Connections {
    /// <summary>
    /// Packet sent from the server to the client to request a password. This may be sent in response to a
    /// <see cref="ConnectPacket"/>.
    /// </summary>
    public sealed class RequestPasswordPacket : Packet {
        private protected override PacketType Type => PacketType.RequestPassword;
        private protected override void ReadFromReader(BinaryReader reader, ushort packetLength) { }
        private protected override void WriteToWriter(BinaryWriter writer) { }
    }
}