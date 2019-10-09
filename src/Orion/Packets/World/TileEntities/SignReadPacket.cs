﻿// Copyright (c) 2019 Pryaxis & Orion Contributors
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

namespace Orion.Packets.World.TileEntities {
    /// <summary>
    /// Packet sent from the client to the server to read a sign.
    /// </summary>
    public sealed class SignReadPacket : Packet {
        private short _signX;
        private short _signY;

        /// <inheritdoc/>
        public override PacketType Type => PacketType.SignRead;

        /// <summary>
        /// Gets or sets the sign's X coordinate.
        /// </summary>
        public short SignX {
            get => _signX;
            set {
                _signX = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the sign's Y coordinate.
        /// </summary>
        public short SignY {
            get => _signY;
            set {
                _signY = value;
                _isDirty = true;
            }
        }

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        public override string ToString() => $"{Type}[({SignX}, {SignY})]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            _signX = reader.ReadInt16();
            _signY = reader.ReadInt16();
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(_signX);
            writer.Write(_signY);
        }
    }
}
