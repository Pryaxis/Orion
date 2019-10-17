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
using System.Diagnostics.Contracts;
using System.IO;
using Orion.Items;
using Orion.Utils;
using TerrariaChest = Terraria.Chest;

namespace Orion.Packets.World {
    /// <summary>
    /// Packet sent from the server to the client to set the traveling merchant's shop.
    /// </summary>
    public sealed class TravelingMerchantShopPacket : Packet {
        private DirtiableArray<ItemType> _shopItemTypes = new DirtiableArray<ItemType>(TerrariaChest.maxItems);

        /// <inheritdoc/>
        public override bool IsDirty => base.IsDirty || _shopItemTypes.IsDirty;

        /// <inheritdoc/>
        public override PacketType Type => PacketType.TravelingMerchantShop;

        /// <summary>
        /// Gets the shop's item types.
        /// </summary>
        public IArray<ItemType> ShopItemTypes => _shopItemTypes;

        /// <inheritdoc/>
        [Pure, ExcludeFromCodeCoverage]
        public override string ToString() => $"{Type}[...]";

        /// <inheritdoc/>
        public override void Clean() {
            base.Clean();
            _shopItemTypes.Clean();
        }

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            var shopItemTypes = new ItemType[_shopItemTypes.Count];
            for (var i = 0; i < _shopItemTypes.Count; ++i) {
                shopItemTypes[i] = (ItemType)reader.ReadInt16();
            }

            _shopItemTypes = new DirtiableArray<ItemType>(shopItemTypes);
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            foreach (var itemType in _shopItemTypes) {
                writer.Write((short)itemType);
            }
        }
    }
}
