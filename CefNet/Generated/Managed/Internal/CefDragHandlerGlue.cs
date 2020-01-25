﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_drag_handler_t.cs
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
	sealed partial class CefDragHandlerGlue: CefDragHandler, ICefDragHandlerPrivate
	{
		private WebViewGlue _implementation;

		public CefDragHandlerGlue(WebViewGlue impl)
		{
			_implementation = impl;
		}

		bool ICefDragHandlerPrivate.AvoidOnDragEnter()
		{
			return _implementation.AvoidOnDragEnter();
		}

		public override bool OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
		{
			return _implementation.OnDragEnter(browser, dragData, mask);
		}

		bool ICefDragHandlerPrivate.AvoidOnDraggableRegionsChanged()
		{
			return _implementation.AvoidOnDraggableRegionsChanged();
		}

		public override void OnDraggableRegionsChanged(CefBrowser browser, CefFrame frame, CefDraggableRegion[] regions)
		{
			_implementation.OnDraggableRegionsChanged(browser, frame, regions);
		}

	}
}