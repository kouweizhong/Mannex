#region License, Terms and Author(s)
//
// Mannex - Extension methods for .NET
// Copyright (c) 2009 Atif Aziz. All rights reserved.
//
//  Author(s):
//
//      Atif Aziz, http://www.raboof.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

namespace Mannex.IO
{
    #region Imports

    using System;
    using System.IO;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Array"/> sub-types.
    /// </summary>

    static partial class ArrayExtensions
    {
        /// <summary>
        /// Creates a read-only stream on top of the supplied byte array.
        /// </summary>
        
        public static Stream OpenRead(this byte[] buffer)
        {
            return OpenStream(buffer, null, null, false);
        }

        /// <summary>
        /// Creates a read-only stream on top of a section of supplied 
        /// byte array.
        /// </summary>

        public static Stream OpenRead(this byte[] buffer, int index, int count)
        {
            return OpenStream(buffer, index, count, false);
        }

        /// <summary>
        /// Creates a read-write stream on top of the supplied byte array.
        /// </summary>

        public static Stream OpenReadWrite(this byte[] buffer)
        {
            return OpenStream(buffer, null, null, true);
        }

        /// <summary>
        /// Creates a read-write stream on top of a section of supplied 
        /// byte array.
        /// </summary>

        public static Stream OpenReadWrite(this byte[] buffer, int index, int count)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            return OpenStream(buffer, index, count, true);
        }

        static Stream OpenStream(byte[] buffer, int? index, int? count, bool writeable)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            return new MemoryStream(buffer, index ?? 0, count ?? buffer.Length, writeable);
        }
    }
}
