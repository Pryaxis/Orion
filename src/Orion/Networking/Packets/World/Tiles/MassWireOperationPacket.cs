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
using Orion.Networking.World.Tiles;

namespace Orion.Networking.Packets.World.Tiles {
    /// <summary>
    /// Packet sent from the client to the server to perform a mass wire operation.
    /// </summary>
    public sealed class MassWireOperationPacket : Packet {
        private short _startTileX;
        private short _startTileY;
        private short _endTileX;
        private short _endTileY;
        private MassWireOperations _massWireOperations;

        /// <inheritdoc />
        public override PacketType Type => PacketType.MassWireOperation;

        /// <summary>
        /// Gets or sets the starting tile's X position.
        /// </summary>
        public short StartTileX {
            get => _startTileX;
            set {
                _startTileX = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the starting tile's Y position.
        /// </summary>
        public short StartTileY {
            get => _startTileY;
            set {
                _startTileY = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the ending tile's X position.
        /// </summary>
        public short EndTileX {
            get => _endTileX;
            set {
                _endTileX = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the ending tile's X position.
        /// </summary>
        public short EndTileY {
            get => _endTileY;
            set {
                _endTileY = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the mass wire operations.
        /// </summary>
        public MassWireOperations MassWireOperations {
            get => _massWireOperations;
            set {
                _massWireOperations = value;
                _isDirty = true;
            }
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() =>
            $"{Type}[{MassWireOperations:F} from ({StartTileX}, {StartTileY}) to ({EndTileX}, {EndTileY})]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            StartTileX = reader.ReadInt16();
            StartTileY = reader.ReadInt16();
            EndTileX = reader.ReadInt16();
            EndTileY = reader.ReadInt16();
            MassWireOperations = (MassWireOperations)reader.ReadByte();
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(StartTileX);
            writer.Write(StartTileY);
            writer.Write(EndTileX);
            writer.Write(EndTileY);
            writer.Write((byte)MassWireOperations);
        }
    }
}