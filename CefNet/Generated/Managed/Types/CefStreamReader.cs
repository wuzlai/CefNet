﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_stream_reader_t.cs
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
	/// Structure used to read data from a stream. The functions of this structure
	/// may be called on any thread.
	/// </summary>
	/// <remarks>
	/// Role: Proxy
	/// </remarks>
	public unsafe partial class CefStreamReader : CefBaseRefCounted<cef_stream_reader_t>
	{
		internal static unsafe CefStreamReader Create(IntPtr instance)
		{
			return new CefStreamReader((cef_stream_reader_t*)instance);
		}

		public CefStreamReader(cef_stream_reader_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		/// <summary>
		/// Read raw binary data.
		/// </summary>
		public unsafe virtual long Read(IntPtr ptr, long size, long n)
		{
			return SafeCall((long)NativeInstance->Read((void*)ptr, new UIntPtr((ulong)size), new UIntPtr((ulong)n)));
		}

		/// <summary>
		/// Seek to the specified offset position. |whence| may be any one of SEEK_CUR,
		/// SEEK_END or SEEK_SET. Returns zero on success and non-zero on failure.
		/// </summary>
		public unsafe virtual int Seek(long offset, int whence)
		{
			return SafeCall(NativeInstance->Seek(offset, whence));
		}

		/// <summary>
		/// Return the current offset position.
		/// </summary>
		public unsafe virtual long Tell()
		{
			return SafeCall(NativeInstance->Tell());
		}

		/// <summary>
		/// Return non-zero if at end of file.
		/// </summary>
		public unsafe virtual int Eof()
		{
			return SafeCall(NativeInstance->Eof());
		}

		/// <summary>
		/// Returns true (1) if this reader performs work like accessing the file
		/// system which may block. Used as a hint for determining the thread to access
		/// the reader from.
		/// </summary>
		public unsafe virtual bool MayBlock()
		{
			return SafeCall(NativeInstance->MayBlock() != 0);
		}
	}
}
