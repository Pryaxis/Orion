﻿using System.IO;
using Microsoft.Xna.Framework;

namespace Orion.Networking.Packets.Extensions {
    /// <summary>
    /// Provides extension methods for the <see cref="BinaryReader"/> and <see cref="BinaryWriter"/> classes.
    /// </summary>
    internal static class BinaryExtensions {
        public static Color ReadColor(this BinaryReader reader) {
            byte red = reader.ReadByte();
            byte green = reader.ReadByte();
            byte blue = reader.ReadByte();
            return new Color(red, green, blue);
        }

        public static Terraria.Localization.NetworkText ReadNetworkText(this BinaryReader reader) {
            return Terraria.Localization.NetworkText.Deserialize(reader);
        }

        public static void Write(this BinaryWriter writer, Color color) {
            writer.Write(color.R);
            writer.Write(color.G);
            writer.Write(color.B);
        }

        public static void Write(this BinaryWriter writer, Terraria.Localization.NetworkText text) {
            text.Serialize(writer);
        }
    }
}