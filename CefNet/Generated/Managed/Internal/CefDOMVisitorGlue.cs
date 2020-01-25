﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_domvisitor_t.cs
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
	sealed partial class CefDOMVisitorGlue: CefDOMVisitor, ICefDOMVisitorPrivate
	{
		private WebViewGlue _implementation;

		public CefDOMVisitorGlue(WebViewGlue impl)
		{
			_implementation = impl;
		}

		bool ICefDOMVisitorPrivate.AvoidVisit()
		{
			return _implementation.AvoidVisit();
		}

		public override void Visit(CefDOMDocument document)
		{
			_implementation.Visit(document);
		}

	}
}