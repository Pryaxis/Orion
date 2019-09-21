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

using System;
using System.IO;
using System.Text;
using Orion.Events;
using Orion.Utils;

namespace Orion.Networking.Packets.Modules {
    /// <summary>
    /// Represents a module. This is sent in a <see cref="ModulePacket"/>.
    /// </summary>
    public abstract class Module : IDirtiable {
        private static readonly Func<Module>[] Constructors = {() => new LiquidsModule(), () => new ChatModule()};
        private protected bool _isDirty;

        /// <inheritdoc />
        public virtual bool IsDirty => _isDirty;

        /// <summary>
        /// Gets the module's type.
        /// </summary>
        public abstract ModuleType Type { get; }

        // Prevent outside inheritance.
        private protected Module() { }

        /// <summary>
        /// Reads and returns a module from the given stream with the specified context.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="context">The context with which to read the module from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <c>null</c>.</exception>
        /// <returns>The resulting <see cref="Module"/> instance.</returns>
        public static Module ReadFromStream(Stream stream, PacketContext context) {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (var reader = new BinaryReader(stream, Encoding.UTF8, true)) {
                var moduleType = ModuleType.FromId(reader.ReadUInt16()) ??
                                 throw new PacketException("Module type is invalid.");
                var module = Constructors[moduleType.Id]();
                module.ReadFromReader(reader, context);
                return module;
            }
        }

        /// <inheritdoc />
        public virtual void Clean() {
            _isDirty = false;
        }

        /// <summary>
        /// Writes the module to the given stream with the specified context.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="context">The context with which to write the packet to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <c>null</c>.</exception>
        public void WriteToStream(Stream stream, PacketContext context) {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true)) {
                writer.Write(Type.Id);
                WriteToWriter(writer, context);
            }
        }

        private protected abstract void ReadFromReader(BinaryReader reader, PacketContext context);
        private protected abstract void WriteToWriter(BinaryWriter writer, PacketContext context);
    }
}
