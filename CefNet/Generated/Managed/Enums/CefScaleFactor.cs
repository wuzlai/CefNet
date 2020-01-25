﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/internal/cef_types.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using CefNet.WinApi;

namespace CefNet
{
	/// <summary>
	/// Supported UI scale factors for the platform. SCALE_FACTOR_NONE is used for
	/// density independent resources such as string, html/js files or an image that
	/// can be used for any scale factors (such as wallpapers).
	/// </summary>
	public enum CefScaleFactor
	{
		SCALE_FACTOR_NONE = 0,

		SCALE_FACTOR_100P = 1,

		SCALE_FACTOR_125P = 2,

		SCALE_FACTOR_133P = 3,

		SCALE_FACTOR_140P = 4,

		SCALE_FACTOR_150P = 5,

		SCALE_FACTOR_180P = 6,

		SCALE_FACTOR_200P = 7,

		SCALE_FACTOR_250P = 8,

		SCALE_FACTOR_300P = 9,
	}
}
