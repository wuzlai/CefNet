﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Managed/Types/CefEndTracingCallback.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

.namespace CefNet
{
	.class public CefEndTracingCallback
	{

		.method private final hidebysig newslot virtual instance bool CefNet.Internal.ICefEndTracingCallbackPrivate.AvoidOnEndTracingComplete()
		{
			.override method instance bool CefNet.Internal.ICefEndTracingCallbackPrivate::AvoidOnEndTracingComplete()
			.maxstack 2
			ldarg.0
			ldvirtftn instance void CefNet.CefEndTracingCallback::OnEndTracingComplete(string)
			ldftn instance void CefNet.CefEndTracingCallback::OnEndTracingComplete(string)
			ceq
			ret
		}

	}
}
