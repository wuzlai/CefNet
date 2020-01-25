﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace CefNet.Internal
{
	public interface IChromiumWebViewPrivate
	{
		void RaisePopupBrowserCreating();
		float GetDevicePixelRatio();
		CefRect GetCefViewBounds();
		CefRect GetCefRootBounds();
		bool GetCefScreenInfo(ref CefScreenInfo screenInfo);
		bool CefPointToScreen(ref CefPoint point);
		void RaiseCefBrowserCreated();
		bool RaiseClosing();
		void RaiseClosed();
		//void RaiseBrowserDestroyed();
		void RaiseCefCreateWindow(CreateWindowEventArgs e);
		void RaiseCefPaint(CefPaintEventArgs e);
		void RaisePopupShow(PopupShowEventArgs e);
		void RaiseTitleChange(DocumentTitleChangedEventArgs e);
		void RaiseBeforeBrowse(BeforeBrowseEventArgs e);
		void RaiseAddressChange(AddressChangeEventArgs e);
		void RaiseLoadingStateChange(LoadingStateChangeEventArgs e);
		bool RaiseRunContextMenu(CefFrame frame, CefContextMenuParams menuParams, CefMenuModel model, CefRunContextMenuCallback callback);
	}
}