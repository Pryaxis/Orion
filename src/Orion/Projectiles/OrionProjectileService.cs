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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Xna.Framework;
using Orion.Events;
using Orion.Events.Extensions;
using Orion.Events.Projectiles;
using OTAPI;

namespace Orion.Projectiles {
    internal sealed class OrionProjectileService : OrionService, IProjectileService {
        private readonly IList<Terraria.Projectile> _terrariaProjectiles;
        private readonly IList<OrionProjectile> _projectiles;

        [ExcludeFromCodeCoverage] public override string Author => "Pryaxis";

        // Subtract 1 from the count. This is because Terraria has an extra slot.
        public int Count => _projectiles.Count - 1;

        public IProjectile this[int index] {
            get {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

                if (_projectiles[index]?.Wrapped != _terrariaProjectiles[index]) {
                    _projectiles[index] = new OrionProjectile(_terrariaProjectiles[index]);
                }

                Debug.Assert(_projectiles[index] != null, "_projectiles[index] != null");
                return _projectiles[index];
            }
        }

        public EventHandlerCollection<ProjectileSetDefaultsEventArgs>? ProjectileSetDefaults { get; set; }
        public EventHandlerCollection<ProjectileUpdateEventArgs>? ProjectileUpdate { get; set; }
        public EventHandlerCollection<ProjectileRemoveEventArgs>? ProjectileRemove { get; set; }

        public OrionProjectileService() {
            Debug.Assert(Terraria.Main.projectile != null, "Terraria.Main.projectile != null");
            Debug.Assert(Terraria.Main.projectile.All(p => p != null), "Terraria.Main.projectile.All(p => p != null)");

            _terrariaProjectiles = Terraria.Main.projectile;
            _projectiles = new OrionProjectile[_terrariaProjectiles.Count];

            Hooks.Projectile.PreSetDefaultsById = PreSetDefaultsByIdHandler;
            Hooks.Projectile.PreUpdate = PreUpdateHandler;
            Hooks.Projectile.PreKill = PreKillHandler;
        }

        protected override void Dispose(bool disposeManaged) {
            if (!disposeManaged) return;
            
            Hooks.Projectile.PreSetDefaultsById = null;
            Hooks.Projectile.PreUpdate = null;
            Hooks.Projectile.PreKill = null;
        }

        public IEnumerator<IProjectile> GetEnumerator() {
            for (var i = 0; i < Count; ++i) {
                yield return this[i];
            }
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IProjectile? SpawnProjectile(ProjectileType projectileType, Vector2 position, Vector2 velocity,
                                            int damage, float knockback, float[]? aiValues = null) {
            if (aiValues != null && aiValues.Length != Terraria.Projectile.maxAI) {
                throw new ArgumentException($"Array does not have length {Terraria.Projectile.maxAI}.",
                                            nameof(aiValues));
            }

            var ai0 = aiValues?[0] ?? 0;
            var ai1 = aiValues?[1] ?? 0;
            var projectileIndex =
                Terraria.Projectile.NewProjectile(position, velocity, (int)projectileType, damage, knockback, 255, ai0,
                                                  ai1);
            return projectileIndex >= 0 && projectileIndex < Count ? this[projectileIndex] : null;
        }

        private HookResult PreSetDefaultsByIdHandler(Terraria.Projectile terrariaProjectile, ref int projectileType) {
            Debug.Assert(terrariaProjectile != null, "terrariaProjectile != null");

            var projectile = new OrionProjectile(terrariaProjectile);
            var args = new ProjectileSetDefaultsEventArgs(projectile, (ProjectileType)projectileType);
            ProjectileSetDefaults?.Invoke(this, args);
            if (args.IsCanceled()) return HookResult.Cancel;

            projectileType = (int)args.ProjectileType;
            return HookResult.Continue;
        }

        private HookResult PreUpdateHandler(Terraria.Projectile terrariaProjectile, ref int projectileIndex) {
            Debug.Assert(terrariaProjectile != null, "terrariaProjectile != null");

            var projectile = new OrionProjectile(terrariaProjectile);
            var args = new ProjectileUpdateEventArgs(projectile);
            ProjectileUpdate?.Invoke(this, args);
            return args.IsCanceled() ? HookResult.Cancel : HookResult.Continue;
        }

        private HookResult PreKillHandler(Terraria.Projectile terrariaProjectile) {
            Debug.Assert(terrariaProjectile != null, "terrariaProjectile != null");

            var projectile = new OrionProjectile(terrariaProjectile);
            var args = new ProjectileRemoveEventArgs(projectile);
            ProjectileRemove?.Invoke(this, args);
            return args.IsCanceled() ? HookResult.Cancel : HookResult.Continue;
        }
    }
}