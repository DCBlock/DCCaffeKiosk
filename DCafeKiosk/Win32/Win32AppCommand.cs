//
// Copyright (C) 2014-2015 St?hane Lenclud.
//
// This file is part of SharpLibWin32.
//
// SharpDisplayManager is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// SharpDisplayManager is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with SharpDisplayManager.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Runtime.InteropServices;

namespace SharpLib.Win32
{
    static public partial class Macro
    {
        public static int GET_APPCOMMAND_LPARAM(IntPtr lParam)
        {
            return ((short)HIWORD(lParam.ToInt32()) & ~Const.FAPPCOMMAND_MASK);
        }
    }
}