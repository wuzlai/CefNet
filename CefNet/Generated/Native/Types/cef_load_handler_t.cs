﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_load_handler_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using CefNet.WinApi;

namespace CefNet.CApi
{
	/// <summary>
	/// Implement this structure to handle events related to browser load status. The
	/// functions of this structure will be called on the browser process UI thread
	/// or render process main thread (TID_RENDERER).
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe partial struct cef_load_handler_t
	{
		/// <summary>
		/// Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		/// void (*)(_cef_load_handler_t* self, _cef_browser_t* browser, int isLoading, int canGoBack, int canGoForward)*
		/// </summary>
		public void* on_loading_state_change;

		/// <summary>
		/// Called when the loading state has changed. This callback will be executed
		/// twice -- once when loading is initiated either programmatically or by user
		/// action, and once when loading is terminated due to completion, cancellation
		/// of failure. It will be called before any calls to OnLoadStart and after all
		/// calls to OnLoadError and/or OnLoadEnd.
		/// </summary>
		[NativeName("on_loading_state_change")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void OnLoadingStateChange(cef_browser_t* browser, int isLoading, int canGoBack, int canGoForward);

		/// <summary>
		/// void (*)(_cef_load_handler_t* self, _cef_browser_t* browser, _cef_frame_t* frame, cef_transition_type_t transition_type)*
		/// </summary>
		public void* on_load_start;

		/// <summary>
		/// Called after a navigation has been committed and before the browser begins
		/// loading contents in the frame. The |frame| value will never be NULL -- call
		/// the is_main() function to check if this frame is the main frame.
		/// |transition_type| provides information about the source of the navigation
		/// and an accurate value is only available in the browser process. Multiple
		/// frames may be loading at the same time. Sub-frames may start or continue
		/// loading after the main frame load has ended. This function will not be
		/// called for same page navigations (fragments, history state, etc.) or for
		/// navigations that fail or are canceled before commit. For notification of
		/// overall browser load status use OnLoadingStateChange instead.
		/// </summary>
		[NativeName("on_load_start")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void OnLoadStart(cef_browser_t* browser, cef_frame_t* frame, CefTransitionType transition_type);

		/// <summary>
		/// void (*)(_cef_load_handler_t* self, _cef_browser_t* browser, _cef_frame_t* frame, int httpStatusCode)*
		/// </summary>
		public void* on_load_end;

		/// <summary>
		/// Called when the browser is done loading a frame. The |frame| value will
		/// never be NULL -- call the is_main() function to check if this frame is the
		/// main frame. Multiple frames may be loading at the same time. Sub-frames may
		/// start or continue loading after the main frame load has ended. This
		/// function will not be called for same page navigations (fragments, history
		/// state, etc.) or for navigations that fail or are canceled before commit.
		/// For notification of overall browser load status use OnLoadingStateChange
		/// instead.
		/// </summary>
		[NativeName("on_load_end")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void OnLoadEnd(cef_browser_t* browser, cef_frame_t* frame, int httpStatusCode);

		/// <summary>
		/// void (*)(_cef_load_handler_t* self, _cef_browser_t* browser, _cef_frame_t* frame, cef_errorcode_t errorCode, const cef_string_t* errorText, const cef_string_t* failedUrl)*
		/// </summary>
		public void* on_load_error;

		/// <summary>
		/// Called when a navigation fails or is canceled. This function may be called
		/// by itself if before commit or in combination with OnLoadStart/OnLoadEnd if
		/// after commit. |errorCode| is the error code number, |errorText| is the
		/// error text and |failedUrl| is the URL that failed to load. See
		/// net@base @net _error_list.h for complete descriptions of the error codes.
		/// </summary>
		[NativeName("on_load_error")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void OnLoadError(cef_browser_t* browser, cef_frame_t* frame, CefErrorCode errorCode, [Immutable]cef_string_t* errorText, [Immutable]cef_string_t* failedUrl);
	}
}
