﻿using System;
using System.IO;
using Orion.Networking.Packets.Extensions;

namespace Orion.Networking.Packets.Connections {
    /// <summary>
    /// Packet sent from the server to the client to disconnect it.
    /// </summary>
    public sealed class DisconnectPacket : Packet {
        private Terraria.Localization.NetworkText _reason = Terraria.Localization.NetworkText.Empty;

        /// <summary>
        /// Gets or sets the disconnection reason.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        public Terraria.Localization.NetworkText Reason {
            get => _reason;
            set => _reason = value ?? throw new ArgumentNullException(nameof(value));
        }

        private protected override PacketType Type => PacketType.Disconnect;

        private protected override void ReadFromReader(BinaryReader reader, ushort packetLength) {
            _reason = reader.ReadNetworkText();
        }

        private protected override void WriteToWriter(BinaryWriter writer) {
            writer.Write(Reason);
        }
    }
}