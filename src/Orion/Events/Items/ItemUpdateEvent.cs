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

using System;
using Destructurama.Attributed;
using Orion.Items;

namespace Orion.Events.Items {
    /// <summary>
    /// An event that occurs when an item updates every tick. This event can be canceled.
    /// </summary>
    /// <remarks>An item update involves processing an item's physics.</remarks>
    [Event("item-update", IsVerbose = true)]
    public sealed class ItemUpdateEvent : ItemEvent, ICancelable {
        /// <inheritdoc/>
        [NotLogged]
        public string? CancellationReason { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemUpdateEvent"/> class with the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        public ItemUpdateEvent(IItem item) : base(item) { }
    }
}