﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_process_message_t.cs
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
	/// Structure representing a message. Can be used on any process and thread.
	/// </summary>
	/// <remarks>
	/// Role: Proxy
	/// </remarks>
	public unsafe partial class CefProcessMessage : CefBaseRefCounted<cef_process_message_t>
	{
		internal static unsafe CefProcessMessage Create(IntPtr instance)
		{
			return new CefProcessMessage((cef_process_message_t*)instance);
		}

		public CefProcessMessage(cef_process_message_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		/// <summary>
		/// Gets a value indicating whether this object is valid. Do not call any other functions
		/// if this property returns false.
		/// </summary>
		public unsafe virtual bool IsValid
		{
			get
			{
				return SafeCall(NativeInstance->IsValid() != 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the values of this object are read-only. Some APIs may
		/// expose read-only objects.
		/// </summary>
		public unsafe virtual bool IsReadOnly
		{
			get
			{
				return SafeCall(NativeInstance->IsReadOnly() != 0);
			}
		}

		/// <summary>
		/// Gets the message name.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string Name
		{
			get
			{
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetName()));
			}
		}

		/// <summary>
		/// Gets the list of arguments.
		/// </summary>
		public unsafe virtual CefListValue ArgumentList
		{
			get
			{
				return SafeCall(CefListValue.Wrap(CefListValue.Create, NativeInstance->GetArgumentList()));
			}
		}

		/// <summary>
		/// Returns a writable copy of this object.
		/// </summary>
		public unsafe virtual CefProcessMessage Copy()
		{
			return SafeCall(CefProcessMessage.Wrap(CefProcessMessage.Create, NativeInstance->Copy()));
		}
	}
}
