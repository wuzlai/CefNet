﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_domdocument_t.cs
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
	/// Structure used to represent a DOM document. The functions of this structure
	/// should only be called on the render process main thread thread.
	/// </summary>
	/// <remarks>
	/// Role: Proxy
	/// </remarks>
	public unsafe partial class CefDOMDocument : CefBaseRefCounted<cef_domdocument_t>
	{
		internal static unsafe CefDOMDocument Create(IntPtr instance)
		{
			return new CefDOMDocument((cef_domdocument_t*)instance);
		}

		public CefDOMDocument(cef_domdocument_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		/// <summary>
		/// Gets the document type.
		/// </summary>
		public unsafe virtual CefDOMDocumentType Type
		{
			get
			{
				return SafeCall(NativeInstance->GetCefType());
			}
		}

		/// <summary>
		/// Gets the root document node.
		/// </summary>
		public unsafe virtual CefDOMNode Document
		{
			get
			{
				return SafeCall(CefDOMNode.Wrap(CefDOMNode.Create, NativeInstance->GetDocument()));
			}
		}

		/// <summary>
		/// Gets the BODY node of an HTML document.
		/// </summary>
		public unsafe virtual CefDOMNode Body
		{
			get
			{
				return SafeCall(CefDOMNode.Wrap(CefDOMNode.Create, NativeInstance->GetBody()));
			}
		}

		/// <summary>
		/// Gets the HEAD node of an HTML document.
		/// </summary>
		public unsafe virtual CefDOMNode Head
		{
			get
			{
				return SafeCall(CefDOMNode.Wrap(CefDOMNode.Create, NativeInstance->GetHead()));
			}
		}

		/// <summary>
		/// Gets the title of an HTML document.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string Title
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetTitle()));
			}
		}

		/// <summary>
		/// Gets the node that currently has keyboard focus.
		/// </summary>
		public unsafe virtual CefDOMNode FocusedNode
		{
			get
			{
				return SafeCall(CefDOMNode.Wrap(CefDOMNode.Create, NativeInstance->GetFocusedNode()));
			}
		}

		/// <summary>
		/// Gets a value indicating whether a portion of the document is selected.
		/// </summary>
		public unsafe virtual bool HasSelection
		{
			get
			{
				return SafeCall(NativeInstance->HasSelection() != 0);
			}
		}

		/// <summary>
		/// Gets the selection offset within the start node.
		/// </summary>
		public unsafe virtual int SelectionStartOffset
		{
			get
			{
				return SafeCall(NativeInstance->GetSelectionStartOffset());
			}
		}

		/// <summary>
		/// Gets the selection offset within the end node.
		/// </summary>
		public unsafe virtual int SelectionEndOffset
		{
			get
			{
				return SafeCall(NativeInstance->GetSelectionEndOffset());
			}
		}

		/// <summary>
		/// Gets the contents of this selection as markup.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string SelectionAsMarkup
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetSelectionAsMarkup()));
			}
		}

		/// <summary>
		/// Gets the contents of this selection as text.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string SelectionAsText
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetSelectionAsText()));
			}
		}

		/// <summary>
		/// Gets the base URL for the document.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string BaseUrl
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetBaseUrl()));
			}
		}

		/// <summary>
		/// Returns the document element with the specified ID value.
		/// </summary>
		public unsafe virtual CefDOMNode GetElementById(string id)
		{
			fixed (char* s0 = id)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = id != null ? id.Length : 0 };
				return SafeCall(CefDOMNode.Wrap(CefDOMNode.Create, NativeInstance->GetElementById(&cstr0)));
			}
		}

		/// <summary>
		/// Returns a complete URL based on the document base URL and the specified
		/// partial URL.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string GetCompleteUrl(string partialURL)
		{
			fixed (char* s0 = partialURL)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = partialURL != null ? partialURL.Length : 0 };
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetCompleteUrl(&cstr0)));
			}
		}
	}
}
