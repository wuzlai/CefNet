﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_download_image_callback_t.cs
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
	/// Callback structure for cef_browser_host_t::DownloadImage. The functions of
	/// this structure will be called on the browser process UI thread.
	/// </summary>
	/// <remarks>
	/// Role: Proxy
	/// </remarks>
	public unsafe partial class CefDownloadImageCallback : CefBaseRefCounted<cef_download_image_callback_t>
	{
		internal static unsafe CefDownloadImageCallback Create(IntPtr instance)
		{
			return new CefDownloadImageCallback((cef_download_image_callback_t*)instance);
		}

		public CefDownloadImageCallback(cef_download_image_callback_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		/// <summary>
		/// Method that will be executed when the image download has completed.
		/// |image_url| is the URL that was downloaded and |http_status_code| is the
		/// resulting HTTP status code. |image| is the resulting image, possibly at
		/// multiple scale factors, or NULL if the download failed.
		/// </summary>
		public unsafe virtual void OnDownloadImageFinished(string imageUrl, int httpStatusCode, CefImage image)
		{
			fixed (char* s0 = imageUrl)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = imageUrl != null ? imageUrl.Length : 0 };
				NativeInstance->OnDownloadImageFinished(&cstr0, httpStatusCode, (image != null) ? image.GetNativeInstance() : null);
			}
		}
	}
}