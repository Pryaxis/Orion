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
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Orion.Utils {
    /// <summary>
    /// Provides the base class for an object implementing <see cref="IAnnotatable"/>.
    /// </summary>
    public class AnnotatableObject : IAnnotatable {
        private readonly IDictionary<string, object?> _annotations = new Dictionary<string, object?>();

        /// <inheritdoc/>
        [Pure]
        public T GetAnnotationOrDefault<T>(string key, T defaultValue = default, bool createIfNotExists = false) {
            if (key is null) {
                throw new ArgumentNullException(nameof(key));
            }

            if (_annotations.TryGetValue(key, out var value)) {
                return (T)value!;
            }

            return createIfNotExists ? (T)(_annotations[key] = defaultValue)! : defaultValue;
        }

        /// <inheritdoc/>
        public void SetAnnotation<T>(string key, T value) {
            if (key is null) {
                throw new ArgumentNullException(nameof(key));
            }

            _annotations[key] = value;
        }

        /// <inheritdoc/>
        public bool RemoveAnnotation(string key) {
            if (key is null) {
                throw new ArgumentNullException(nameof(key));
            }

            return _annotations.Remove(key);
        }
    }
}
