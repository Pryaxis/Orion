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

using System.IO;
using Orion.World.TileEntities;

namespace Orion.Packets.World.TileEntities {
    /// <summary>
    /// Represents a logic sensor that is transmitted over the network.
    /// </summary>
    public sealed class NetworkLogicSensor : NetworkTileEntity, ILogicSensor {
        private LogicSensorType _logicSensorType;
        private bool _isActivated;

        /// <inheritdoc />
        public override TileEntityType Type => TileEntityType.LogicSensor;

        /// <inheritdoc />
        public LogicSensorType LogicSensorType {
            get => _logicSensorType;
            set {
                _logicSensorType = value;
                IsDirty = true;
            }
        }

        /// <inheritdoc />
        public bool IsActivated {
            get => _isActivated;
            set {
                _isActivated = value;
                IsDirty = true;
            }
        }

        private protected override void ReadFromReaderImpl(BinaryReader reader) {
            _logicSensorType = (LogicSensorType)reader.ReadByte();
            _isActivated = reader.ReadBoolean();
        }

        private protected override void WriteToWriterImpl(BinaryWriter writer) {
            writer.Write((byte)_logicSensorType);
            writer.Write(_isActivated);
        }
    }
}