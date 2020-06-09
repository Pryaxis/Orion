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
using System.Text;
using Orion.Packets.DataStructures;

namespace Orion.Packets.Server {
    /// <summary>
    /// A packet sent from the server to the client to disconnect the client.
    /// </summary>
    public struct ServerDisconnectPacket : IPacket {
        private NetworkText? _reason;

        /// <summary>
        /// Gets or sets the disconnect reason.
        /// </summary>
        /// <value>The disconnect reason.</value>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        public NetworkText Reason {
            get => _reason ?? NetworkText.Empty;
            set => _reason = value ?? throw new ArgumentNullException(nameof(value));
        }

        PacketId IPacket.Id => PacketId.ServerDisconnect;

        /// <inheritdoc/>
        public int Read(Span<byte> span, PacketContext context) => span.Read(Encoding.UTF8, out _reason);

        /// <inheritdoc/>
        public int Write(Span<byte> span, PacketContext context) => span.Write(Reason, Encoding.UTF8);
    }
}