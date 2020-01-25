﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CefNet.Internal
{
	public partial class WebViewGlue
	{
		private bool _isResourceRequestGlueInitialized;
		private CefResourceRequestHandler _resourceRequestGlue;

		private bool _isCookieAccessFilterGlueInitialized;
		private CefCookieAccessFilter _cookieAccessFilterGlue;

		private bool _isFocusGlueInitialized;
		private CefFocusHandlerGlue _focusGlue;

		protected IChromiumWebViewPrivate WebView { get; private set; }

		public CefBrowser BrowserObject { get; protected set; }

		public CefClient Client { get; private set; }
		private CefLifeSpanHandlerGlue LifeSpanGlue { get; }
		private CefRenderHandlerGlue RenderGlue { get; }
		private CefDisplayHandlerGlue DisplayGlue { get; }
		private CefRequestHandler RequestGlue { get; }
		private CefDialogHandler DialogGlue { get; }

		private CefContextMenuHandlerGlue ContextMenuGlue { get; }
		private CefLoadHandlerGlue LoadGlue { get; }

		public WebViewGlue(IChromiumWebViewPrivate view)
		{
			this.WebView = view;
			this.Client = new CefClientGlue(this);
			this.LifeSpanGlue = new CefLifeSpanHandlerGlue(this);
			this.RenderGlue = new CefRenderHandlerGlue(this);
			this.DisplayGlue = new CefDisplayHandlerGlue(this);
			this.RequestGlue = new CefRequestHandlerGlue(this);
			this.DialogGlue = new CefDialogHandlerGlue(this);
			
			this.ContextMenuGlue = new CefContextMenuHandlerGlue(this);
			this.LoadGlue = new CefLoadHandlerGlue(this);
		}


		private CefResourceRequestHandler ResourceRequestGlue
		{
			get
			{
				if (_isResourceRequestGlueInitialized)
					return _resourceRequestGlue;

				if (AvoidGetCookieAccessFilter()
					&& AvoidOverloadOnBeforeResourceLoad()
					&& AvoidGetResourceHandler()
					&& AvoidOnResourceRedirect()
					&& AvoidOnResourceResponse()
					&& AvoidGetResourceResponseFilter()
					&& AvoidOnResourceLoadComplete()
					&& AvoidOnProtocolExecution())
				{
					_resourceRequestGlue = null;
				}
				else
				{
					_resourceRequestGlue = new CefResourceRequestHandlerGlue(this);
				}

				_isResourceRequestGlueInitialized = true;
				return _resourceRequestGlue;
			}
		}

		private CefCookieAccessFilter CookieAccessFilterGlue
		{
			get
			{
				if (_isCookieAccessFilterGlueInitialized)
					return _cookieAccessFilterGlue;

				if (AvoidOverloadCanSendCookie() && AvoidOverloadCanSaveCookie())
				{
					_cookieAccessFilterGlue = null;
				}
				else
				{
					_cookieAccessFilterGlue = new CefCookieAccessFilterGlue(this);
				}

				_isCookieAccessFilterGlueInitialized = true;
				return _cookieAccessFilterGlue;
			}
		}

		private CefFocusHandlerGlue FocusGlue
		{
			get
			{
				if (_isFocusGlueInitialized)
					return _focusGlue;

				if (AvoidOnTakeFocus()
					&& AvoidOnSetFocus()
					&& AvoidOnGotFocus())
				{
					_focusGlue = null;
				}
				else
				{
					_focusGlue = new CefFocusHandlerGlue(this);
				}

				_isFocusGlueInitialized = true;
				return _focusGlue;
			}
		}

		internal void NotifyPopupBrowserCreating()
		{
			WebView.RaisePopupBrowserCreating();
		}

	}
}