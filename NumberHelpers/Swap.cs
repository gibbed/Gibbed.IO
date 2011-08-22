/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;

namespace Gibbed.IO
{
    public static partial class NumberHelpers
    {
        public static Int16 Swap(this Int16 value)
        {
            UInt16 uvalue = (UInt16)value;
            UInt16 swapped = (UInt16)((0x00FF) & (value >> 8) |
                                      (0xFF00) & (value << 8));
            return (Int16)swapped;
        }

        public static UInt16 Swap(this UInt16 value)
        {
            UInt16 swapped = (UInt16)((0x00FF) & (value >> 8) |
                                      (0xFF00) & (value << 8));
            return swapped;
        }

        public static Int32 Swap(this Int32 value)
        {
            UInt32 uvalue = (UInt32)value;
            UInt32 swapped = ((0x000000FF) & (uvalue >> 24) |
                              (0x0000FF00) & (uvalue >> 8) |
                              (0x00FF0000) & (uvalue << 8) |
                              (0xFF000000) & (uvalue << 24));
            return (Int32)swapped;
        }

        public static Int32 Swap24(this Int32 value)
        {
            Int32 swapped = ((0x000000FF) & (value >> 16) |
                              (0x0000FF00) & (value) |
                              (0x00FF0000) & (value << 16));
            return swapped;
        }

        public static UInt32 Swap(this UInt32 value)
        {
            UInt32 swapped = ((0x000000FF) & (value >> 24) |
                              (0x0000FF00) & (value >> 8) |
                              (0x00FF0000) & (value << 8) |
                              (0xFF000000) & (value << 24));
            return swapped;
        }

        public static UInt32 Swap24(this UInt32 value)
        {
            UInt32 swapped = ((0x000000FF) & (value >> 16) |
                              (0x0000FF00) & (value) |
                              (0x00FF0000) & (value << 16));
            return swapped;
        }

        public static Int64 Swap(this Int64 value)
        {
            UInt64 uvalue = (UInt64)value;
            UInt64 swapped = ((0x00000000000000FF) & (uvalue >> 56) |
                              (0x000000000000FF00) & (uvalue >> 40) |
                              (0x0000000000FF0000) & (uvalue >> 24) |
                              (0x00000000FF000000) & (uvalue >> 8) |
                              (0x000000FF00000000) & (uvalue << 8) |
                              (0x0000FF0000000000) & (uvalue << 24) |
                              (0x00FF000000000000) & (uvalue << 40) |
                              (0xFF00000000000000) & (uvalue << 56));
            return (Int64)swapped;
        }

        public static UInt64 Swap(this UInt64 value)
        {
            UInt64 swapped = ((0x00000000000000FF) & (value >> 56) |
                              (0x000000000000FF00) & (value >> 40) |
                              (0x0000000000FF0000) & (value >> 24) |
                              (0x00000000FF000000) & (value >> 8) |
                              (0x000000FF00000000) & (value << 8) |
                              (0x0000FF0000000000) & (value << 24) |
                              (0x00FF000000000000) & (value << 40) |
                              (0xFF00000000000000) & (value << 56));
            return swapped;
        }
    }
}
