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
using Orion.Npcs;
using Orion.Utils;

namespace Orion.Events.Npcs {
    /// <summary>
    /// An event that occurs when an NPC is being damaged. This event can be canceled and modified.
    /// </summary>
    [Event("npc-damage")]
    public sealed class NpcDamageEvent : NpcEvent, ICancelable, IDirtiable {
        private int _damage;
        private float _knockback;
        private bool _hitDirection;
        private bool _isCriticalHit;

        /// <inheritdoc/>
        [NotLogged]
        public string? CancellationReason { get; set; }

        /// <inheritdoc/>
        [NotLogged]
        public bool IsDirty { get; private set; }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>The damage.</value>
        public int Damage {
            get => _damage;
            set {
                _damage = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the knockback.
        /// </summary>
        /// <value>The knockback.</value>
        public float Knockback {
            get => _knockback;
            set {
                _knockback = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the hit direction.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the hit is to the right; <see langword="false"/> if the hit is to the left.
        /// </value>
        public bool HitDirection {
            get => _hitDirection;
            set {
                _hitDirection = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the hit is critical.
        /// </summary>
        /// <value><see langword="true"/> if the hit is critical; otherwise, <see langword="false"/>.</value>
        /// <remarks>
        /// A critical hit doubles the damage dealt to the NPC after defense and other attributes are factored into the
        /// damage calculation.
        /// </remarks>
        public bool IsCriticalHit {
            get => _isCriticalHit;
            set {
                _isCriticalHit = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NpcDamageEvent"/> class with the specified NPC, damage,
        /// knockback, hit direction, and criticality.
        /// </summary>
        /// <param name="npc">The NPC.</param>
        /// <param name="damage">The damage.</param>
        /// <param name="knockback">The knockback.</param>
        /// <param name="hitDirection">
        /// <see langword="true"/> if the hit is to the right; <see langword="false"/> if the hit is to the left.
        /// </param>
        /// <param name="isCriticalHit">
        /// <see langword="true"/> if the hit is critical; otherwise, <see langword="false"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="npc"/> is <see langword="null"/>.</exception>
        public NpcDamageEvent(
                INpc npc, int damage, float knockback, bool hitDirection, bool isCriticalHit) : base(npc) {
            _damage = damage;
            _knockback = knockback;
            _hitDirection = hitDirection;
            _isCriticalHit = isCriticalHit;
        }

        /// <inheritdoc/>
        public void Clean() => IsDirty = false;
    }
}