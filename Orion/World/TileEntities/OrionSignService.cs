﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Orion.World.Tiles;

namespace Orion.World.TileEntities {
    internal sealed class OrionSignService : OrionService, ISignService {
        private readonly IList<Terraria.Sign> _terrariaSigns;
        private readonly IList<OrionSign> _signs;
        
        [ExcludeFromCodeCoverage]
        public override string Author => "Pryaxis";
        
        [ExcludeFromCodeCoverage]
        public override string Name => "Orion Sign Service";

        public int Count => _signs.Count;

        public ISign this[int index] {
            get {
                if (index < 0 || index >= Count) {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                
                /*
                 * Some signs in _terrariaSigns may be null, so we need to handle this properly by also returning null.
                 */
                if (_signs[index] == null || _signs[index].Wrapped != _terrariaSigns[index]) {
                    if (_terrariaSigns[index] == null) {
                        return null;
                    } else {
                        _signs[index] = new OrionSign(_terrariaSigns[index]);
                    }
                }

                var sign = _signs[index];
                Debug.Assert(sign != null, $"{nameof(sign)} should not be null.");
                Debug.Assert(sign.Wrapped != null, $"{nameof(sign.Wrapped)} should not be null.");
                return sign;
            }
        }

        public OrionSignService() {
            _terrariaSigns = Terraria.Main.sign;
            _signs = new OrionSign[_terrariaSigns.Count];
        }

        public IEnumerator<ISign> GetEnumerator() {
            for (var i = 0; i < Count; ++i) {
                yield return this[i];
            }
        }
        
        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ISign PlaceSign(int x, int y, BlockType type = BlockType.Signs, int style = 0) =>
            Terraria.WorldGen.PlaceSign(x, y, (ushort)type, style) ? GetSign(x, y) : null;

        public ISign GetSign(int x, int y) {
            var signIndex = Terraria.Sign.ReadSign(x, y);
            if (signIndex < 0) {
                return null;
            }

            Debug.Assert(signIndex < Count, $"{nameof(signIndex)} should be a valid index.");
            return this[signIndex];
        }

        public bool RemoveSign(ISign sign) {
            var signIndex = Terraria.Sign.ReadSign(sign.X, sign.Y, false);
            if (signIndex < 0) {
                return false;
            }

            Terraria.Sign.KillSign(sign.X, sign.Y);
            return true;
        }
    }
}