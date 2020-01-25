﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_render_handler_t.cs
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

namespace CefNet
{
	/// <summary>
	/// Implement this structure to handle events when window rendering is disabled.
	/// The functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// Role: Handler
	/// </remarks>
	public unsafe partial class CefRenderHandler : CefBaseRefCounted<cef_render_handler_t>, ICefRenderHandlerPrivate
	{
		private static readonly GetAccessibilityHandlerDelegate fnGetAccessibilityHandler = GetAccessibilityHandlerImpl;

		private static readonly GetRootScreenRectDelegate fnGetRootScreenRect = GetRootScreenRectImpl;

		private static readonly GetViewRectDelegate fnGetViewRect = GetViewRectImpl;

		private static readonly GetScreenPointDelegate fnGetScreenPoint = GetScreenPointImpl;

		private static readonly GetScreenInfoDelegate fnGetScreenInfo = GetScreenInfoImpl;

		private static readonly OnPopupShowDelegate fnOnPopupShow = OnPopupShowImpl;

		private static readonly OnPopupSizeDelegate fnOnPopupSize = OnPopupSizeImpl;

		private static readonly OnPaintDelegate fnOnPaint = OnPaintImpl;

		private static readonly OnAcceleratedPaintDelegate fnOnAcceleratedPaint = OnAcceleratedPaintImpl;

		private static readonly OnCursorChangeDelegate fnOnCursorChange = OnCursorChangeImpl;

		private static readonly StartDraggingDelegate fnStartDragging = StartDraggingImpl;

		private static readonly UpdateDragCursorDelegate fnUpdateDragCursor = UpdateDragCursorImpl;

		private static readonly OnScrollOffsetChangedDelegate fnOnScrollOffsetChanged = OnScrollOffsetChangedImpl;

		private static readonly OnImeCompositionRangeChangedDelegate fnOnImeCompositionRangeChanged = OnImeCompositionRangeChangedImpl;

		private static readonly OnTextSelectionChangedDelegate fnOnTextSelectionChanged = OnTextSelectionChangedImpl;

		private static readonly OnVirtualKeyboardRequestedDelegate fnOnVirtualKeyboardRequested = OnVirtualKeyboardRequestedImpl;

		internal static unsafe CefRenderHandler Create(IntPtr instance)
		{
			return new CefRenderHandler((cef_render_handler_t*)instance);
		}

		public CefRenderHandler()
		{
			cef_render_handler_t* self = this.NativeInstance;
			self->get_accessibility_handler = (void*)Marshal.GetFunctionPointerForDelegate(fnGetAccessibilityHandler);
			self->get_root_screen_rect = (void*)Marshal.GetFunctionPointerForDelegate(fnGetRootScreenRect);
			self->get_view_rect = (void*)Marshal.GetFunctionPointerForDelegate(fnGetViewRect);
			self->get_screen_point = (void*)Marshal.GetFunctionPointerForDelegate(fnGetScreenPoint);
			self->get_screen_info = (void*)Marshal.GetFunctionPointerForDelegate(fnGetScreenInfo);
			self->on_popup_show = (void*)Marshal.GetFunctionPointerForDelegate(fnOnPopupShow);
			self->on_popup_size = (void*)Marshal.GetFunctionPointerForDelegate(fnOnPopupSize);
			self->on_paint = (void*)Marshal.GetFunctionPointerForDelegate(fnOnPaint);
			self->on_accelerated_paint = (void*)Marshal.GetFunctionPointerForDelegate(fnOnAcceleratedPaint);
			self->on_cursor_change = (void*)Marshal.GetFunctionPointerForDelegate(fnOnCursorChange);
			self->start_dragging = (void*)Marshal.GetFunctionPointerForDelegate(fnStartDragging);
			self->update_drag_cursor = (void*)Marshal.GetFunctionPointerForDelegate(fnUpdateDragCursor);
			self->on_scroll_offset_changed = (void*)Marshal.GetFunctionPointerForDelegate(fnOnScrollOffsetChanged);
			self->on_ime_composition_range_changed = (void*)Marshal.GetFunctionPointerForDelegate(fnOnImeCompositionRangeChanged);
			self->on_text_selection_changed = (void*)Marshal.GetFunctionPointerForDelegate(fnOnTextSelectionChanged);
			self->on_virtual_keyboard_requested = (void*)Marshal.GetFunctionPointerForDelegate(fnOnVirtualKeyboardRequested);
		}

		public CefRenderHandler(cef_render_handler_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		/// <summary>
		/// Return the handler for accessibility notifications. If no handler is
		/// provided the default implementation will be used.
		/// </summary>
		public unsafe virtual CefAccessibilityHandler GetAccessibilityHandler()
		{
			return default;
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate cef_accessibility_handler_t* GetAccessibilityHandlerDelegate(cef_render_handler_t* self);

		// _cef_accessibility_handler_t* (*)(_cef_render_handler_t* self)*
		private static unsafe cef_accessibility_handler_t* GetAccessibilityHandlerImpl(cef_render_handler_t* self)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null)
			{
				return default;
			}
			CefAccessibilityHandler rv = instance.GetAccessibilityHandler();
			if (rv == null)
				return null;
			return (rv != null) ? rv.GetNativeInstance() : null;
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidGetRootScreenRect();

		/// <summary>
		/// Called to retrieve the root window rectangle in screen coordinates. Return
		/// true (1) if the rectangle was provided. If this function returns false (0)
		/// the rectangle from GetViewRect will be used.
		/// </summary>
		public unsafe virtual bool GetRootScreenRect(CefBrowser browser, ref CefRect rect)
		{
			return default;
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate int GetRootScreenRectDelegate(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect);

		// int (*)(_cef_render_handler_t* self, _cef_browser_t* browser, cef_rect_t* rect)*
		private static unsafe int GetRootScreenRectImpl(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidGetRootScreenRect())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return default;
			}
			return instance.GetRootScreenRect(CefBrowser.Wrap(CefBrowser.Create, browser), ref *(CefRect*)rect) ? 1 : 0;
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidGetViewRect();

		/// <summary>
		/// Called to retrieve the view rectangle which is relative to screen
		/// coordinates. This function must always provide a non-NULL rectangle.
		/// </summary>
		public unsafe virtual void GetViewRect(CefBrowser browser, ref CefRect rect)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void GetViewRectDelegate(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, cef_rect_t* rect)*
		private static unsafe void GetViewRectImpl(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidGetViewRect())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.GetViewRect(CefBrowser.Wrap(CefBrowser.Create, browser), ref *(CefRect*)rect);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidGetScreenPoint();

		/// <summary>
		/// Called to retrieve the translation from view coordinates to actual screen
		/// coordinates. Return true (1) if the screen coordinates were provided.
		/// </summary>
		public unsafe virtual bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
		{
			return default;
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate int GetScreenPointDelegate(cef_render_handler_t* self, cef_browser_t* browser, int viewX, int viewY, int* screenX, int* screenY);

		// int (*)(_cef_render_handler_t* self, _cef_browser_t* browser, int viewX, int viewY, int* screenX, int* screenY)*
		private static unsafe int GetScreenPointImpl(cef_render_handler_t* self, cef_browser_t* browser, int viewX, int viewY, int* screenX, int* screenY)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidGetScreenPoint())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return default;
			}
			return instance.GetScreenPoint(CefBrowser.Wrap(CefBrowser.Create, browser), viewX, viewY, ref *screenX, ref *screenY) ? 1 : 0;
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidGetScreenInfo();

		/// <summary>
		/// Called to allow the client to fill in the CefScreenInfo object with
		/// appropriate values. Return true (1) if the |screen_info| structure has been
		/// modified.
		/// If the screen info rectangle is left NULL the rectangle from GetViewRect
		/// will be used. If the rectangle is still NULL or invalid popups may not be
		/// drawn correctly.
		/// </summary>
		public unsafe virtual bool GetScreenInfo(CefBrowser browser, ref CefScreenInfo screenInfo)
		{
			return default;
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate int GetScreenInfoDelegate(cef_render_handler_t* self, cef_browser_t* browser, cef_screen_info_t* screen_info);

		// int (*)(_cef_render_handler_t* self, _cef_browser_t* browser, _cef_screen_info_t* screen_info)*
		private static unsafe int GetScreenInfoImpl(cef_render_handler_t* self, cef_browser_t* browser, cef_screen_info_t* screen_info)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidGetScreenInfo())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return default;
			}
			return instance.GetScreenInfo(CefBrowser.Wrap(CefBrowser.Create, browser), ref *(CefScreenInfo*)screen_info) ? 1 : 0;
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnPopupShow();

		/// <summary>
		/// Called when the browser wants to show or hide the popup widget. The popup
		/// should be shown if |show| is true (1) and hidden if |show| is false (0).
		/// </summary>
		public unsafe virtual void OnPopupShow(CefBrowser browser, bool show)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnPopupShowDelegate(cef_render_handler_t* self, cef_browser_t* browser, int show);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, int show)*
		private static unsafe void OnPopupShowImpl(cef_render_handler_t* self, cef_browser_t* browser, int show)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnPopupShow())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.OnPopupShow(CefBrowser.Wrap(CefBrowser.Create, browser), show != 0);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnPopupSize();

		/// <summary>
		/// Called when the browser wants to move or resize the popup widget. |rect|
		/// contains the new location and size in view coordinates.
		/// </summary>
		public unsafe virtual void OnPopupSize(CefBrowser browser, CefRect rect)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnPopupSizeDelegate(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, const cef_rect_t* rect)*
		private static unsafe void OnPopupSizeImpl(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnPopupSize())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.OnPopupSize(CefBrowser.Wrap(CefBrowser.Create, browser), *(CefRect*)rect);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnPaint();

		/// <summary>
		/// Called when an element should be painted. Pixel values passed to this
		/// function are scaled relative to view coordinates based on the value of
		/// CefScreenInfo.device_scale_factor returned from GetScreenInfo. |type|
		/// indicates whether the element is the view or the popup widget. |buffer|
		/// contains the pixel data for the whole image. |dirtyRects| contains the set
		/// of rectangles in pixel coordinates that need to be repainted. |buffer| will
		/// be |width|*|height|*4 bytes in size and represents a BGRA image with an
		/// upper-left origin. This function is only called when
		/// cef_window_tInfo::shared_texture_enabled is set to false (0).
		/// </summary>
		public unsafe virtual void OnPaint(CefBrowser browser, CefPaintElementType type, CefRect[] dirtyRects, IntPtr buffer, int width, int height)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnPaintDelegate(cef_render_handler_t* self, cef_browser_t* browser, CefPaintElementType type, UIntPtr dirtyRectsCount, cef_rect_t* dirtyRects, void* buffer, int width, int height);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, cef_paint_element_type_t type, size_t dirtyRectsCount, const cef_rect_t* dirtyRects, const void* buffer, int width, int height)*
		private static unsafe void OnPaintImpl(cef_render_handler_t* self, cef_browser_t* browser, CefPaintElementType type, UIntPtr dirtyRectsCount, cef_rect_t* dirtyRects, void* buffer, int width, int height)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnPaint())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			CefRect[] obj_dirtyRects = new CefRect[(int)dirtyRectsCount];
			for (int i = 0; i < obj_dirtyRects.Length; i++)
			{
				obj_dirtyRects[i] = *(CefRect*)(dirtyRects + i);
			}
			instance.OnPaint(CefBrowser.Wrap(CefBrowser.Create, browser), type, obj_dirtyRects, unchecked((IntPtr)buffer), width, height);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnAcceleratedPaint();

		/// <summary>
		/// Called when an element has been rendered to the shared texture handle.
		/// |type| indicates whether the element is the view or the popup widget.
		/// |dirtyRects| contains the set of rectangles in pixel coordinates that need
		/// to be repainted. |shared_handle| is the handle for a D3D11 Texture2D that
		/// can be accessed via ID3D11Device using the OpenSharedResource function.
		/// This function is only called when cef_window_tInfo::shared_texture_enabled
		/// is set to true (1), and is currently only supported on Windows.
		/// </summary>
		public unsafe virtual void OnAcceleratedPaint(CefBrowser browser, CefPaintElementType type, CefRect[] dirtyRects, IntPtr sharedHandle)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnAcceleratedPaintDelegate(cef_render_handler_t* self, cef_browser_t* browser, CefPaintElementType type, UIntPtr dirtyRectsCount, cef_rect_t* dirtyRects, void* shared_handle);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, cef_paint_element_type_t type, size_t dirtyRectsCount, const cef_rect_t* dirtyRects, void* shared_handle)*
		private static unsafe void OnAcceleratedPaintImpl(cef_render_handler_t* self, cef_browser_t* browser, CefPaintElementType type, UIntPtr dirtyRectsCount, cef_rect_t* dirtyRects, void* shared_handle)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnAcceleratedPaint())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			CefRect[] obj_dirtyRects = new CefRect[(int)dirtyRectsCount];
			for (int i = 0; i < obj_dirtyRects.Length; i++)
			{
				obj_dirtyRects[i] = *(CefRect*)(dirtyRects + i);
			}
			instance.OnAcceleratedPaint(CefBrowser.Wrap(CefBrowser.Create, browser), type, obj_dirtyRects, unchecked((IntPtr)shared_handle));
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnCursorChange();

		/// <summary>
		/// Called when the browser&apos;s cursor has changed. If |type| is CT_CUSTOM then
		/// |custom_cursor_info| will be populated with the custom cursor information.
		/// </summary>
		public unsafe virtual void OnCursorChange(CefBrowser browser, IntPtr cursor, CefCursorType type, CefCursorInfo customCursorInfo)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnCursorChangeDelegate(cef_render_handler_t* self, cef_browser_t* browser, IntPtr cursor, CefCursorType type, cef_cursor_info_t* custom_cursor_info);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, HCURSOR cursor, cef_cursor_type_t type, const const _cef_cursor_info_t* custom_cursor_info)*
		private static unsafe void OnCursorChangeImpl(cef_render_handler_t* self, cef_browser_t* browser, IntPtr cursor, CefCursorType type, cef_cursor_info_t* custom_cursor_info)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnCursorChange())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.OnCursorChange(CefBrowser.Wrap(CefBrowser.Create, browser), cursor, type, *(CefCursorInfo*)custom_cursor_info);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidStartDragging();

		/// <summary>
		/// Called when the user starts dragging content in the web view. Contextual
		/// information about the dragged content is supplied by |drag_data|. (|x|,
		/// |y|) is the drag start location in screen coordinates. OS APIs that run a
		/// system message loop may be used within the StartDragging call.
		/// Return false (0) to abort the drag operation. Don&apos;t call any of
		/// cef_browser_host_t::DragSource*Ended* functions after returning false (0).
		/// Return true (1) to handle the drag operation. Call
		/// cef_browser_host_t::DragSourceEndedAt and DragSourceSystemDragEnded either
		/// synchronously or asynchronously to inform the web view that the drag
		/// operation has ended.
		/// </summary>
		public unsafe virtual bool StartDragging(CefBrowser browser, CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y)
		{
			return default;
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate int StartDraggingDelegate(cef_render_handler_t* self, cef_browser_t* browser, cef_drag_data_t* drag_data, CefDragOperationsMask allowed_ops, int x, int y);

		// int (*)(_cef_render_handler_t* self, _cef_browser_t* browser, _cef_drag_data_t* drag_data, cef_drag_operations_mask_t allowed_ops, int x, int y)*
		private static unsafe int StartDraggingImpl(cef_render_handler_t* self, cef_browser_t* browser, cef_drag_data_t* drag_data, CefDragOperationsMask allowed_ops, int x, int y)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidStartDragging())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				ReleaseIfNonNull((cef_base_ref_counted_t*)drag_data);
				return default;
			}
			return instance.StartDragging(CefBrowser.Wrap(CefBrowser.Create, browser), CefDragData.Wrap(CefDragData.Create, drag_data), allowed_ops, x, y) ? 1 : 0;
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidUpdateDragCursor();

		/// <summary>
		/// Called when the web view wants to update the mouse cursor during a drag
		/// &amp;
		/// drop operation. |operation| describes the allowed operation (none, move,
		/// copy, link).
		/// </summary>
		public unsafe virtual void UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void UpdateDragCursorDelegate(cef_render_handler_t* self, cef_browser_t* browser, CefDragOperationsMask operation);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, cef_drag_operations_mask_t operation)*
		private static unsafe void UpdateDragCursorImpl(cef_render_handler_t* self, cef_browser_t* browser, CefDragOperationsMask operation)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidUpdateDragCursor())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.UpdateDragCursor(CefBrowser.Wrap(CefBrowser.Create, browser), operation);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnScrollOffsetChanged();

		/// <summary>
		/// Called when the scroll offset has changed.
		/// </summary>
		public unsafe virtual void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnScrollOffsetChangedDelegate(cef_render_handler_t* self, cef_browser_t* browser, double x, double y);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, double x, double y)*
		private static unsafe void OnScrollOffsetChangedImpl(cef_render_handler_t* self, cef_browser_t* browser, double x, double y)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnScrollOffsetChanged())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.OnScrollOffsetChanged(CefBrowser.Wrap(CefBrowser.Create, browser), x, y);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnImeCompositionRangeChanged();

		/// <summary>
		/// Called when the IME composition range has changed. |selected_range| is the
		/// range of characters that have been selected. |character_bounds| is the
		/// bounds of each character in view coordinates.
		/// </summary>
		public unsafe virtual void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRect[] characterBounds)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnImeCompositionRangeChangedDelegate(cef_render_handler_t* self, cef_browser_t* browser, cef_range_t* selected_range, UIntPtr character_boundsCount, cef_rect_t* character_bounds);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, const cef_range_t* selected_range, size_t character_boundsCount, const cef_rect_t* character_bounds)*
		private static unsafe void OnImeCompositionRangeChangedImpl(cef_render_handler_t* self, cef_browser_t* browser, cef_range_t* selected_range, UIntPtr character_boundsCount, cef_rect_t* character_bounds)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnImeCompositionRangeChanged())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			CefRect[] obj_character_bounds = new CefRect[(int)character_boundsCount];
			for (int i = 0; i < obj_character_bounds.Length; i++)
			{
				obj_character_bounds[i] = *(CefRect*)(character_bounds + i);
			}
			instance.OnImeCompositionRangeChanged(CefBrowser.Wrap(CefBrowser.Create, browser), *(CefRange*)selected_range, obj_character_bounds);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnTextSelectionChanged();

		/// <summary>
		/// Called when text selection has changed for the specified |browser|.
		/// |selected_text| is the currently selected text and |selected_range| is the
		/// character range.
		/// </summary>
		public unsafe virtual void OnTextSelectionChanged(CefBrowser browser, string selectedText, CefRange selectedRange)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnTextSelectionChangedDelegate(cef_render_handler_t* self, cef_browser_t* browser, cef_string_t* selected_text, cef_range_t* selected_range);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, const cef_string_t* selected_text, const cef_range_t* selected_range)*
		private static unsafe void OnTextSelectionChangedImpl(cef_render_handler_t* self, cef_browser_t* browser, cef_string_t* selected_text, cef_range_t* selected_range)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnTextSelectionChanged())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.OnTextSelectionChanged(CefBrowser.Wrap(CefBrowser.Create, browser), CefString.Read(selected_text), *(CefRange*)selected_range);
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefRenderHandlerPrivate.AvoidOnVirtualKeyboardRequested();

		/// <summary>
		/// Called when an on-screen keyboard should be shown or hidden for the
		/// specified |browser|. |input_mode| specifies what kind of keyboard should be
		/// opened. If |input_mode| is CEF_TEXT_INPUT_MODE_NONE, any existing keyboard
		/// for this browser should be hidden.
		/// </summary>
		public unsafe virtual void OnVirtualKeyboardRequested(CefBrowser browser, CefTextInputMode inputMode)
		{
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate void OnVirtualKeyboardRequestedDelegate(cef_render_handler_t* self, cef_browser_t* browser, CefTextInputMode input_mode);

		// void (*)(_cef_render_handler_t* self, _cef_browser_t* browser, cef_text_input_mode_t input_mode)*
		private static unsafe void OnVirtualKeyboardRequestedImpl(cef_render_handler_t* self, cef_browser_t* browser, CefTextInputMode input_mode)
		{
			var instance = GetInstance((IntPtr)self) as CefRenderHandler;
			if (instance == null || ((ICefRenderHandlerPrivate)instance).AvoidOnVirtualKeyboardRequested())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)browser);
				return;
			}
			instance.OnVirtualKeyboardRequested(CefBrowser.Wrap(CefBrowser.Create, browser), input_mode);
		}
	}
}