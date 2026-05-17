using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Microsoft.Xna.Framework
{
	internal sealed class xNativeMethods
	{
		public struct Message
		{
			public IntPtr hWnd;

			public WindowMessage msg;

			public IntPtr wParam;

			public IntPtr lParam;

			public uint time;

			public System.Drawing.Point p;
		}

		public struct MinMaxInformation
		{
			public System.Drawing.Point reserved;

			public System.Drawing.Point MaxSize;

			public System.Drawing.Point MaxPosition;

			public System.Drawing.Point MinTrackSize;

			public System.Drawing.Point MaxTrackSize;
		}

		public struct MonitorInformation
		{
			public uint Size;

			public System.Drawing.Rectangle MonitorRectangle;

			public System.Drawing.Rectangle WorkRectangle;

			public uint Flags;
		}

		public enum MouseButtons
		{
			Left = 1,
			Middle = 16,
			Right = 2,
			Side1 = 32,
			Side2 = 64
		}

		public struct POINT
		{
			public int X;

			public int Y;
		}

		public struct RECT
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;
		}

		internal enum WindowMessage : uint
		{
			ActivateApplication = 28u,
			Character = 258u,
			Close = 16u,
			Destroy = 2u,
			EnterMenuLoop = 529u,
			EnterSizeMove = 561u,
			ExitMenuLoop = 530u,
			ExitSizeMove = 562u,
			GetMinMax = 36u,
			KeyDown = 256u,
			KeyUp = 257u,
			LeftButtonDoubleClick = 515u,
			LeftButtonDown = 513u,
			LeftButtonUp = 514u,
			MiddleButtonDoubleClick = 521u,
			MiddleButtonDown = 519u,
			MiddleButtonUp = 520u,
			MouseFirst = 513u,
			MouseLast = 525u,
			MouseMove = 512u,
			MouseWheel = 522u,
			NonClientHitTest = 132u,
			Paint = 15u,
			PowerBroadcast = 536u,
			Quit = 18u,
			RightButtonDoubleClick = 518u,
			RightButtonDown = 516u,
			RightButtonUp = 517u,
			SetCursor = 32u,
			Size = 5u,
			SystemCharacter = 262u,
			SystemCommand = 274u,
			SystemKeyDown = 260u,
			SystemKeyUp = 261u,
			XButtonDoubleClick = 525u,
			XButtonDown = 523u,
			XButtonUp = 524u
		}

		private xNativeMethods()
		{
		}

		[DllImport("user32.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool ClientToScreen(IntPtr hWnd, out POINT point);

		[DllImport("user32.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetClientRect(IntPtr hWnd, out RECT rect);

		[DllImport("user32.dll")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

		[DllImport("user32.dll")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr MonitorFromWindow(IntPtr hWnd, uint flags);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

		[DllImport("kernel32")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool QueryPerformanceCounter(ref long PerformanceCount);

		[DllImport("kernel32")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);
	}
}
