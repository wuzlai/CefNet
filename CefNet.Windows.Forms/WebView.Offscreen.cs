﻿using CefNet.Internal;
using CefNet.WinApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CefNet.Windows.Forms
{


	partial class WebView: IWinFormsWebViewPrivate
	{
		private CefEventFlags _keydownModifiers;
		private IntPtr _keyboardLayout;

		/// <summary>
		/// Gets emulated device.
		/// </summary>
		protected VirtualDevice Device { get; private set; }

		/// <summary>
		/// Enable or disable device simulation.
		/// </summary>
		/// <param name="device">The simulated device or null.</param>
		public void SimulateDevice(VirtualDevice device)
		{
			if (IsHandleCreated)
			{
				VerifyAccess();
			}

			if (Device == device)
				return;

			OffscreenGraphics offscreenGraphics = this.OffscreenGraphics;
			if (offscreenGraphics != null)
				offscreenGraphics.Device = device;
			
			if (IsHandleCreated)
			{
				if (!WindowlessRenderingEnabled)
					throw new InvalidOperationException();
				OnSizeChanged(EventArgs.Empty);
			}
			else
			{
				Device = device;
			}
		}

		protected CefRect GetViewportRect()
		{
			CefRect viewportRect;
			VirtualDevice device = Device;
			if (device == null)
			{
				viewportRect = new CefRect(0, 0, this.Width, this.Height);
				viewportRect.Scale(OffscreenGraphics.PixelsPerDip);
				return viewportRect;
			}
			else
			{
				return device.GetBounds(OffscreenGraphics.PixelsPerDip);
			}
		}

		protected OffscreenGraphics OffscreenGraphics { get; private set; }

		public bool WindowlessRenderingEnabled
		{
			get
			{
				return OffscreenGraphics != null;
			}
			set
			{
				SetInitProperty(InitialPropertyKeys.Windowless, value);

				if (value)
				{
					if (OffscreenGraphics == null)
						OffscreenGraphics = new OffscreenGraphics { Background = this.BackColor, Device = Device };
				}
				else
				{
					OffscreenGraphics = null;
				}
			}
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			OffscreenGraphics offscreenGraphics = this.OffscreenGraphics;
			if (offscreenGraphics != null) 
				offscreenGraphics.Background = this.BackColor;

			base.OnBackColorChanged(e);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			if (OffscreenGraphics != null)
				OffscreenGraphics.WidgetHandle = this.Handle;
			else
				this.Device = null;

			float devicePixelRatio;
			using (var g = CreateGraphics())
			{
				devicePixelRatio = g.DpiX / 96f;
			}
			SetDevicePixelRatio(devicePixelRatio);

			base.OnHandleCreated(e);
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			if (OffscreenGraphics != null)
				OffscreenGraphics.WidgetHandle = IntPtr.Zero;

			base.OnHandleDestroyed(e);
		}


		bool IChromiumWebViewPrivate.GetCefScreenInfo(ref CefScreenInfo screenInfo)
		{
			return GetCefScreenInfo(ref screenInfo);
		}

		protected virtual bool GetCefScreenInfo(ref CefScreenInfo screenInfo)
		{
			VirtualDevice device = Device;
			if (device == null)
				return false;
			screenInfo = device.ScreenInfo;
			return true;
		}

		bool IChromiumWebViewPrivate.CefPointToScreen(ref CefPoint point)
		{
			return CefPointToScreen(ref point);
		}

		protected virtual bool CefPointToScreen(ref CefPoint point)
		{
			VirtualDevice device = Device;
			if (device == null)
			{
				point.Scale(OffscreenGraphics.PixelsPerDip);
				NativeMethods.MapWindowPoints(OffscreenGraphics.WidgetHandle, IntPtr.Zero, ref point, 1);
				return true;
			}
			else
			{
				return device.PointToScreen(ref point);
			}
		}

		public float GetDevicePixelRatio()
		{
			VirtualDevice device = Device;
			return device != null ? device.DevicePixelRatio : OffscreenGraphics.PixelsPerDip;
		}

		protected virtual CefPoint PointToViewport(CefPoint point)
		{
			float scale = OffscreenGraphics.PixelsPerDip;
			VirtualDevice viewport = Device;
			if (viewport != null) scale = scale * viewport.Scale;
			CefRect viewportRect = GetViewportRect();
			return new CefPoint((int)((point.X - viewportRect.X) / scale), (int)((point.Y - viewportRect.Y) / scale));
		}

		protected virtual bool PointInViewport(int x, int y)
		{
			CefRect viewportRect = GetViewportRect();
			return viewportRect.X <= x && x <= viewportRect.Right && viewportRect.Y <= y && y <= viewportRect.Bottom;
		}

		CefRect IChromiumWebViewPrivate.GetCefRootBounds()
		{
			return GetCefRootBounds();
		}

		protected virtual CefRect GetCefRootBounds()
		{
			VirtualDevice device = Device;
			if (device == null)
			{
				const int GA_ROOT = 2;

				IntPtr hwnd = NativeMethods.GetAncestor(OffscreenGraphics.WidgetHandle, GA_ROOT);
				if (NativeMethods.GetWindowRect(hwnd, out RECT windowBounds))
				{
					float ppd = OffscreenGraphics.PixelsPerDip;
					if (ppd == 1.0f)
						return windowBounds.ToCefRect();
					return new CefRect(
						(int)(windowBounds.Left / ppd),
						(int)(windowBounds.Top / ppd),
						(int)((windowBounds.Right - windowBounds.Left) / ppd),
						(int)((windowBounds.Bottom - windowBounds.Top) / ppd)
					);
				}
				return OffscreenGraphics.GetBounds();
			}
			else
			{
				return device.GetRootBounds();
			}
		}

		CefRect IChromiumWebViewPrivate.GetCefViewBounds()
		{
			return OffscreenGraphics.GetBounds();
		}

		void IWinFormsWebViewPrivate.RaiseCefCursorChange(CursorChangeEventArgs e)
		{
			RaiseCrossThreadEvent(OnCursorChange, e, false);
		}

		protected virtual void OnCursorChange(CursorChangeEventArgs e)
		{
			this.Cursor = e.Cursor;
		}

		void IWinFormsWebViewPrivate.CefSetToolTip(string text)
		{
			RaiseCrossThreadEvent(OnSetToolTip, new TooltipEventArgs(text), false);
		}

		protected virtual void OnSetToolTip(TooltipEventArgs e)
		{
			ToolTip toolTip = this.ToolTip;
			if (toolTip != null && toolTip.GetToolTip(this) != e.Text)
			{
				toolTip.SetToolTip(this, e.Text);
			}
		}

		public void CefInvalidate()
		{
			CefBrowserHost browserHost = BrowserObject?.Host;
			if (browserHost != null)
			{
				browserHost.Invalidate(CefPaintElementType.View);
				browserHost.Invalidate(CefPaintElementType.Popup);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			SetDevicePixelRatio(e.Graphics.DpiX / 96f);
			if (WindowlessRenderingEnabled)
			{
				Rectangle renderBounds = OffscreenGraphics.GetRenderBounds();
				DrawDeviceArea(e.Graphics, e.ClipRectangle);
				OffscreenGraphics.Render(e.Graphics, e.ClipRectangle);

				// redraw background if render has wrong size
				VirtualDevice device = Device;
				if (device != null)
				{
					CefRect deviceBounds = device.GetBounds(OffscreenGraphics.PixelsPerDip);
					if (renderBounds.Width > deviceBounds.Width || renderBounds.Height > deviceBounds.Height)
					{
						e.Graphics.ExcludeClip(deviceBounds.ToRectangle());
						DrawDeviceArea(e.Graphics, ClientRectangle);
					}
				}
			}
			//e.Graphics.DrawRectangle(Pens.Red, popupRect);
			base.OnPaint(e);
		}

		protected virtual void DrawDeviceArea(Graphics graphics, Rectangle rectangle)
		{
			VirtualDevice device = Device;
			if (device != null)
			{
				CefRect deviceBounds = device.GetBounds(OffscreenGraphics.PixelsPerDip);
				Color background = this.BackColor;
				if (background.A > 0)
				{
					using (var brush = new SolidBrush(background))
					{
						graphics.FillRectangle(brush, rectangle);
					}
				}
				graphics.DrawRectangle(Pens.Gray, deviceBounds.X - 1, deviceBounds.Y - 1, deviceBounds.Width + 1, deviceBounds.Height + 1);
			}
		}

		protected virtual void OnCefPaint(CefPaintEventArgs e)
		{
			CefPaint?.Invoke(this, e);

			if (GetState(State.Closing))
				return;

			CefRect invalidRect = OffscreenGraphics.Draw(e);
			Device?.MoveToDevice(ref invalidRect, OffscreenGraphics.PixelsPerDip);

			if (GetState(State.Closing))
				return;

			try
			{
				if (invalidRect.Width > 0 && invalidRect.Height > 0)
				{
					bool useInvalidate = false;

					Graphics graphics = null;
					try
					{
						if (!IsHandleCreated)
							return;
						graphics = CreateGraphics();

						Rectangle renderBounds = OffscreenGraphics.GetRenderBounds();
						OffscreenGraphics.Render(graphics, invalidRect.ToRectangle());

						// draw background if render has wrong size
						VirtualDevice device = Device;
						if (device != null)
						{
							CefRect deviceBounds = device.GetBounds(OffscreenGraphics.PixelsPerDip);
							if (renderBounds.Width > deviceBounds.Width || renderBounds.Height > deviceBounds.Height)
							{
								graphics.ExcludeClip(deviceBounds.ToRectangle());
								DrawDeviceArea(graphics, ClientRectangle);
							}
						}
					}
					catch (ObjectDisposedException) { throw; }
					catch { useInvalidate = true; }
					finally
					{
						graphics?.Dispose();
					}

					if (useInvalidate)
					{
						if (!IsHandleCreated)
							return;
						Invalidate(invalidRect.ToRectangle(), false);
					}
				}
				else
				{
					if (!IsHandleCreated)
						return;
					Invalidate();
				}
			}
			catch (ObjectDisposedException) { }
		}

		protected virtual void OnPopupShow(PopupShowEventArgs e)
		{
			Rectangle invalidRect = OffscreenGraphics.GetPopupBounds();

			CefRect bounds = e.Bounds;
			float ppd = OffscreenGraphics.PixelsPerDip;
			VirtualDevice device = Device;
			if (device != null)
			{
				invalidRect.Offset((int)(device.X * ppd), (int)(device.Y * ppd));
				device.ScaleToViewport(ref bounds, ppd);
			}
			else
			{
				bounds.Scale(ppd);
			}
			OffscreenGraphics.SetPopup(e.Visible, bounds);
			Invalidate(invalidRect, false);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			if (WindowlessRenderingEnabled)
			{
				CefRect? viewportRect = Device?.ViewportRect;
				if (viewportRect != null)
				{
					if (OffscreenGraphics.SetSize(viewportRect.Value.Width, viewportRect.Value.Height))
					{
						BrowserObject?.Host.WasResized();
					}
				}
				else if (OffscreenGraphics.SetSize(this.Width, this.Height))
				{
					BrowserObject?.Host.WasResized();
				}
			}
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (specified == BoundsSpecified.All || specified == BoundsSpecified.None)
			{
				if (width == 0 || height == 0)
					return;
			}
			else if(specified == BoundsSpecified.Width && width == 0)
			{
				return;
			}
			else if(specified == BoundsSpecified.Height && height == 0)
			{
				return;
			}
			base.SetBoundsCore(x, y, width, height, specified);
		}

		protected override Size DefaultSize
		{
			get { return new Size(100, 100); }
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (PointInViewport(e.X, e.Y))
			{
				if (WindowlessRenderingEnabled)
				{
					CefEventFlags modifiers = CefEventFlags.None;
					if (e.Button == MouseButtons.Left)
						modifiers |= CefEventFlags.LeftMouseButton;
					if (e.Button == MouseButtons.Right)
						modifiers |= CefEventFlags.RightMouseButton;
					SendMouseMoveEvent(e.X, e.Y, modifiers);
				}
			}
			else
			{

			}
			base.OnMouseMove(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (WindowlessRenderingEnabled)
			{
				SendMouseLeaveEvent();
			}
			base.OnMouseLeave(e);
		}

		private static CefMouseButtonType GetButton(MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Right:
					return CefMouseButtonType.Right;
				case MouseButtons.Middle:
					return CefMouseButtonType.Middle;
			}
			return CefMouseButtonType.Left;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (PointInViewport(e.X, e.Y))
			{
				if (WindowlessRenderingEnabled)
				{
					SendMouseClickEvent(e.X, e.Y, GetButton(e), false, e.Clicks, GetModifierKeys());
				}
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (PointInViewport(e.X, e.Y))
			{
				if (WindowlessRenderingEnabled)
				{
					SendMouseClickEvent(e.X, e.Y, GetButton(e), true, e.Clicks, GetModifierKeys());
				}
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);

			if (!ModifierKeys.HasFlag(Keys.Shift))
			{
				if (PointInViewport(e.X, e.Y))
				{
					if (WindowlessRenderingEnabled)
					{
						SendMouseWheelEvent(e.X, e.Y, 0, e.Delta);
						((HandledMouseEventArgs)e).Handled = true;
					}
				}
				return;
			}
			OnMouseHWheel(e);
		}

		protected virtual void OnMouseHWheel(MouseEventArgs e)
		{
			if (PointInViewport(e.X, e.Y))
			{
				if (WindowlessRenderingEnabled)
				{
					SendMouseWheelEvent(e.X, e.Y, e.Delta, 0);
				}
			}
			((HandledMouseEventArgs)e).Handled = true;
		}

		private void WmMouseHWheel(ref Message m)
		{
			Point p = PointToClient(new Point(NativeMethods.LoWord(m.LParam), NativeMethods.HiWord(m.LParam)));
			int delta = -NativeMethods.HiWord(m.WParam);
			if (Math.Abs(delta) < 10)
			{
				delta = Math.Sign(delta) * 10;
			}
			HandledMouseEventArgs handledMouseEventArgs = new HandledMouseEventArgs(MouseButtons.None, 0, p.X, p.Y, delta);
			OnMouseHWheel(handledMouseEventArgs);
			m.Result = new IntPtr((!handledMouseEventArgs.Handled) ? 1 : 0);
			if (!handledMouseEventArgs.Handled)
			{
				DefWndProc(ref m);
			}
		}

		private bool ProcessWindowlessMessage(ref Message m)
		{
			const int MA_ACTIVATE = 0x1;
			const int WM_MOUSEHWHEEL = 0x20E;
			const int WM_INPUTLANGCHANGE = 0x0051;

			switch (m.Msg)
			{
				case WM_INPUTLANGCHANGE:
					SetKeyboardLayoutForCefUIThreadIfNeeded();
					return false;
				case WM_MOUSEHWHEEL:
					WmMouseHWheel(ref m);
					return true;
				case 0x21: // WM_MOUSEACTIVATE:
					Focus();
					m.Result = new IntPtr(MA_ACTIVATE);
					return true;
				case 0x0083: //	WM_NCCALCSIZE:
					m.Result = IntPtr.Zero;
					return true;
				case 0x114: // WM_HSCROLL:
					short delta;
					switch (m.WParam.ToInt64())
					{
						case 0: // SB_LINELEFT
							delta = -1;
							break;
						case 1: // SB_LINERIGHT
							delta = 1;
							break;
						default:
							base.WndProc(ref m);
							return true;
					}
					Point mousePos = Control.MousePosition;
					NativeMethods.PostMessage(m.HWnd, WM_MOUSEHWHEEL, NativeMethods.MakeParam(delta, 0), NativeMethods.MakeParam((short)mousePos.Y, (short)mousePos.X));
					m.Result = IntPtr.Zero;
					return true;
				case 0x84: //WM_NCHITTEST
					m.Result = new IntPtr(1); // HTCLIENT
					return true;
			}
			return false;
		}

		protected override bool ProcessCmdKey(ref Message m, Keys keyData)
		{
			const int WM_SYSKEYDOWN = 0x0104;
			const int WM_KEYDOWN = 0x0100;

			if (WindowlessRenderingEnabled)
			{
				if (m.Msg == WM_KEYDOWN || m.Msg == WM_SYSKEYDOWN)
				{
					Keys key = (Keys)m.WParam.ToInt64();
					if ((key >= Keys.PageUp && key <= Keys.Down) || key == Keys.Tab)
					{
						var e = new CefKeyEvent();
						e.WindowsKeyCode = unchecked((int)m.WParam);
						e.NativeKeyCode = (int)((ulong)m.LParam & 0xFFFFFFFFUL);
						e.IsSystemKey = (m.Msg == WM_SYSKEYDOWN);
						e.Type = CefKeyEventType.RawKeyDown;
						e.Modifiers = (uint)GetCefKeyboardModifiers((Keys)m.WParam.ToInt64(), m.LParam);
						this.BrowserObject?.Host.SendKeyEvent(e);
						return true;
					}
				}
			}
			return base.ProcessCmdKey(ref m, keyData);
		}

		protected override bool ProcessKeyEventArgs(ref Message m)
		{
			const int WM_KEYDOWN = 0x0100;
			const int WM_KEYUP = 0x0101;
			const int WM_SYSKEYDOWN = 0x0104;
			const int WM_SYSKEYUP = 0x0105;
			const int WM_SYSCHAR = 0x0106;

			if (WindowlessRenderingEnabled)
			{
				var k = new CefKeyEvent();
				k.WindowsKeyCode = unchecked((int)m.WParam);
				k.NativeKeyCode = unchecked((int)((ulong)m.LParam & 0xFFFFFFFFUL));
				k.IsSystemKey = m.Msg >= WM_SYSKEYDOWN && m.Msg <= WM_SYSCHAR;
				
				CefEventFlags modifiers;
				if (m.Msg == WM_KEYDOWN || m.Msg == WM_SYSKEYDOWN)
				{
					modifiers = GetCefKeyboardModifiers((Keys)m.WParam.ToInt64(), m.LParam);
					_keydownModifiers = modifiers;
					k.Type = CefKeyEventType.RawKeyDown;
					SetKeyboardLayoutForCefUIThreadIfNeeded();
				}
				else if (m.Msg == WM_KEYUP || m.Msg == WM_SYSKEYUP)
				{
					modifiers = GetCefKeyboardModifiers((Keys)m.WParam.ToInt64(), m.LParam);
					if (_keydownModifiers.HasFlag(CefEventFlags.IsRight))
						modifiers = CefEventFlags.IsRight & ~CefEventFlags.IsLeft;
					_keydownModifiers = CefEventFlags.None;
					k.Type = CefKeyEventType.KeyUp;
					SetKeyboardLayoutForCefUIThreadIfNeeded();
				}
				else
				{
					k.Type = CefKeyEventType.Char;
					modifiers = GetCefKeyboardModifiers((Keys)NativeMethods.MapVirtualKey((uint)(m.LParam.ToInt64() >> 16) & 0xFFU, MapVirtualKeyType.MAPVK_VSC_TO_VK_EX), m.LParam);
				}
				k.Modifiers = (uint)modifiers;

				this.BrowserObject?.Host.SendKeyEvent(k);
			}
			return base.ProcessKeyEventArgs(ref m);
		}

		protected static CefEventFlags GetModifierKeys()
		{
			CefEventFlags modifiers = CefEventFlags.None;
			Keys modKeys = Control.ModifierKeys;
			if (modKeys.HasFlag(Keys.Shift))
				modifiers |= CefEventFlags.ShiftDown;
			if (modKeys.HasFlag(Keys.Control))
				modifiers |= CefEventFlags.ControlDown;
			if (modKeys.HasFlag(Keys.Alt))
				modifiers |= CefEventFlags.AltDown;
			return modifiers;
		}

		protected CefEventFlags GetCefKeyboardModifiers(Keys key, IntPtr lparam)
		{
			const int KF_EXTENDED = 0x100;

			CefEventFlags modifiers = GetModifierKeys();

			if (IsKeyLocked(Keys.NumLock))
				modifiers |= CefEventFlags.NumLockOn;
			if (IsKeyLocked(Keys.CapsLock))
				modifiers |= CefEventFlags.CapsLockOn;

			switch (key)
			{
				case Keys.Return:
					if (((lparam.ToInt64() >> 16) & KF_EXTENDED) != 0)
						modifiers |= CefEventFlags.IsKeyPad;
					break;
				case Keys.Insert:
				case Keys.Delete:
				case Keys.Home:
				case Keys.End:
				case Keys.Prior:
				case Keys.Next:
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					if (((lparam.ToInt64() >> 16) & KF_EXTENDED) == 0)
						modifiers |= CefEventFlags.IsKeyPad;
					break;
				case Keys.NumLock:
				case Keys.NumPad0:
				case Keys.NumPad1:
				case Keys.NumPad2:
				case Keys.NumPad3:
				case Keys.NumPad4:
				case Keys.NumPad5:
				case Keys.NumPad6:
				case Keys.NumPad7:
				case Keys.NumPad8:
				case Keys.NumPad9:
				case Keys.Divide:
				case Keys.Multiply:
				case Keys.Subtract:
				case Keys.Add:
				case Keys.Decimal:
				case Keys.Clear:
					modifiers |= CefEventFlags.IsKeyPad;
					break;
				case Keys.LShiftKey:
				case Keys.LControlKey:
				case Keys.LMenu:
				case Keys.LWin:
					modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.RShiftKey:
				case Keys.RControlKey:
				case Keys.RMenu:
				case Keys.RWin:
					modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.ShiftKey:
					if (NativeMethods.GetKeyState(VirtualKeys.RShiftKey).HasFlag(KeyState.Pressed))
						modifiers |= CefEventFlags.IsRight;
					else
						modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.ControlKey:
					if (NativeMethods.GetKeyState(VirtualKeys.RControlKey).HasFlag(KeyState.Pressed))
						modifiers |= CefEventFlags.IsRight;
					else
						modifiers |= CefEventFlags.IsLeft;
					break;
				case Keys.Menu:
					if (NativeMethods.GetKeyState(VirtualKeys.RMenu).HasFlag(KeyState.Pressed))
						modifiers |= CefEventFlags.IsRight;
					else
						modifiers |= CefEventFlags.IsLeft;
					break;
				default:
					if (((lparam.ToInt64() >> 16) & KF_EXTENDED) != 0)
						modifiers |= CefEventFlags.IsKeyPad;
					break;
			}
			return modifiers;
		}

		/// <summary>
		/// Sets the current input locale identifier for the UI thread in the browser.
		/// </summary>
		protected void SetKeyboardLayoutForCefUIThreadIfNeeded()
		{
			IntPtr hkl = NativeMethods.GetKeyboardLayout(0);
			if (_keyboardLayout == hkl)
				return;

			if (CefApi.CurrentlyOn(CefThreadId.UI))
			{
				_keyboardLayout = hkl;
			}
			else
			{
				CefNetApi.Post(CefThreadId.UI, () => {
					NativeMethods.ActivateKeyboardLayout(hkl, 0);
					_keyboardLayout = hkl;
				});
			}
		}

	}
}