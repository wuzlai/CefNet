﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_drag_data_t.cs
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
	/// Structure used to represent drag data. The functions of this structure may be
	/// called on any thread.
	/// </summary>
	/// <remarks>
	/// Role: Proxy
	/// </remarks>
	public unsafe partial class CefDragData : CefBaseRefCounted<cef_drag_data_t>
	{
		internal static unsafe CefDragData Create(IntPtr instance)
		{
			return new CefDragData((cef_drag_data_t*)instance);
		}

		public CefDragData(cef_drag_data_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		/// <summary>
		/// Gets a value indicating whether this object is read-only.
		/// </summary>
		public unsafe virtual bool IsReadOnly
		{
			get
			{
				return SafeCall(NativeInstance->IsReadOnly() != 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the drag data is a link.
		/// </summary>
		public unsafe virtual bool IsLink
		{
			get
			{
				return SafeCall(NativeInstance->IsLink() != 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the drag data is a text or html fragment.
		/// </summary>
		public unsafe virtual bool IsFragment
		{
			get
			{
				return SafeCall(NativeInstance->IsFragment() != 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the drag data is a file.
		/// </summary>
		public unsafe virtual bool IsFile
		{
			get
			{
				return SafeCall(NativeInstance->IsFile() != 0);
			}
		}

		/// <summary>
		/// Return the link URL that is being dragged.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string LinkUrl
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetLinkUrl()));
			}
			set
			{
				fixed (char* s0 = value)
				{
					var cstr0 = new cef_string_t { Str = s0, Length = value != null ? value.Length : 0 };
					NativeInstance->SetLinkUrl(&cstr0);
				}
				GC.KeepAlive(this);
			}
		}

		/// <summary>
		/// Return the title associated with the link being dragged.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string LinkTitle
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetLinkTitle()));
			}
			set
			{
				fixed (char* s0 = value)
				{
					var cstr0 = new cef_string_t { Str = s0, Length = value != null ? value.Length : 0 };
					NativeInstance->SetLinkTitle(&cstr0);
				}
				GC.KeepAlive(this);
			}
		}

		/// <summary>
		/// Return the metadata, if any, associated with the link being dragged.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string LinkMetadata
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetLinkMetadata()));
			}
			set
			{
				fixed (char* s0 = value)
				{
					var cstr0 = new cef_string_t { Str = s0, Length = value != null ? value.Length : 0 };
					NativeInstance->SetLinkMetadata(&cstr0);
				}
				GC.KeepAlive(this);
			}
		}

		/// <summary>
		/// Return the plain text fragment that is being dragged.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string FragmentText
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetFragmentText()));
			}
			set
			{
				fixed (char* s0 = value)
				{
					var cstr0 = new cef_string_t { Str = s0, Length = value != null ? value.Length : 0 };
					NativeInstance->SetFragmentText(&cstr0);
				}
				GC.KeepAlive(this);
			}
		}

		/// <summary>
		/// Return the text/html fragment that is being dragged.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string FragmentHtml
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetFragmentHtml()));
			}
			set
			{
				fixed (char* s0 = value)
				{
					var cstr0 = new cef_string_t { Str = s0, Length = value != null ? value.Length : 0 };
					NativeInstance->SetFragmentHtml(&cstr0);
				}
				GC.KeepAlive(this);
			}
		}

		/// <summary>
		/// Return the base URL that the fragment came from. This value is used for
		/// resolving relative URLs and may be NULL.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string FragmentBaseUrl
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetFragmentBaseUrl()));
			}
			set
			{
				fixed (char* s0 = value)
				{
					var cstr0 = new cef_string_t { Str = s0, Length = value != null ? value.Length : 0 };
					NativeInstance->SetFragmentBaseUrl(&cstr0);
				}
				GC.KeepAlive(this);
			}
		}

		/// <summary>
		/// Return the name of the file being dragged out of the browser window.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string FileName
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetFileName()));
			}
		}

		/// <summary>
		/// Gets a value indicating whether an image representation of drag data is available.
		/// </summary>
		public unsafe virtual bool HasImage
		{
			get
			{
				return SafeCall(NativeInstance->HasImage() != 0);
			}
		}

		/// <summary>
		/// Get the image hotspot (drag start location relative to image dimensions).
		/// </summary>
		public unsafe virtual CefPoint ImageHotspot
		{
			get
			{
				return SafeCall(NativeInstance->GetImageHotspot());
			}
		}

		/// <summary>
		/// Returns a copy of the current object.
		/// </summary>
		public unsafe virtual CefDragData Clone()
		{
			return SafeCall(CefDragData.Wrap(CefDragData.Create, NativeInstance->Clone()));
		}

		/// <summary>
		/// Write the contents of the file being dragged out of the web view into
		/// |writer|. Returns the number of bytes sent to |writer|. If |writer| is NULL
		/// this function will return the size of the file contents in bytes. Call
		/// get_file_name() to get a suggested name for the file.
		/// </summary>
		public unsafe virtual long GetFileContents(CefStreamWriter writer)
		{
			return SafeCall((long)NativeInstance->GetFileContents((writer != null) ? writer.GetNativeInstance() : null));
		}

		/// <summary>
		/// Retrieve the list of file names that are being dragged into the browser
		/// window.
		/// </summary>
		public unsafe virtual int GetFileNames(CefStringList names)
		{
			return SafeCall(NativeInstance->GetFileNames(names.GetNativeInstance()));
		}

		/// <summary>
		/// Reset the file contents. You should do this before calling
		/// cef_browser_host_t::DragTargetDragEnter as the web view does not allow us
		/// to drag in this kind of data.
		/// </summary>
		public unsafe virtual void ResetFileContents()
		{
			NativeInstance->ResetFileContents();
			GC.KeepAlive(this);
		}

		/// <summary>
		/// Add a file that is being dragged into the webview.
		/// </summary>
		public unsafe virtual void AddFile(string path, string displayName)
		{
			fixed (char* s0 = path)
			fixed (char* s1 = displayName)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = path != null ? path.Length : 0 };
				var cstr1 = new cef_string_t { Str = s1, Length = displayName != null ? displayName.Length : 0 };
				NativeInstance->AddFile(&cstr0, &cstr1);
			}
			GC.KeepAlive(this);
		}
	}
}
