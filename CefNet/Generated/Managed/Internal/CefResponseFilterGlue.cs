﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_response_filter_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using CefNet.WinApi;
using CefNet.CApi;
using CefNet.Internal;

namespace CefNet.Internal
{
	sealed partial class CefResponseFilterGlue: CefResponseFilter, ICefResponseFilterPrivate
	{
		private WebViewGlue _implementation;

		public CefResponseFilterGlue(WebViewGlue impl)
		{
			_implementation = impl;
		}

		public override bool InitFilter()
		{
			return _implementation.InitFilter();
		}

		bool ICefResponseFilterPrivate.AvoidFilter()
		{
			return _implementation.AvoidFilter();
		}

		public override CefResponseFilterStatus Filter(IntPtr dataIn, long dataInSize, ref long dataInRead, IntPtr dataOut, long dataOutSize, ref long dataOutWritten)
		{
			return _implementation.Filter(dataIn, dataInSize, ref dataInRead, dataOut, dataOutSize, ref dataOutWritten);
		}

	}
}