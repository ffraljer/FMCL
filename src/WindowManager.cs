using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Xna.Framework;

public class WindowManager
{
	/*
	 not VERY in line with the modern osu! WindowManager, but this is for compatibility with modern code.
	 */
	private Game game_;
	public int Width { get; private set; }
	public int Height { get; private set; }

	public Vector2 Centre
	{
		get
		{
			return new Vector2(Width / 2f, Height / 2f);
		}
	}

	public int DefaultWidth { get; set; } = 640;
	public int DefaultHeight { get; set; } = 480;
	public int SpriteRes { get; set; } = 768;

	public float OffsetX { get; set; }

	public float Ratio { get; private set; }
	public float RatioScaleDown { get; private set; }
	public float RatioInverse { get; private set; }

	public int WidthScaled => (int) Math.Ceiling(Width / Ratio);
	public int HeightScaled => (int) Math.Ceiling(Height / Ratio);
	public float OffsetXScaled => OffsetX / Ratio;
	public float WidthWidescreenRatio => (float) WidthScaled / DefaultWidth;

	[System.Runtime.Versioning.SupportedOSPlatform("windows6.1")]
	public WindowManager(Game game)
	{
		CalculateWindowSizes(game);
	}
	[System.Runtime.Versioning.SupportedOSPlatform("windows6.1")]
	public void CalculateWindowSizes(Game gasme)
	{
		game_ = gasme;

		// this IS hacky, but osu! does it in its GameBase
		// next thing to do is like, actually make the window a Form,
		// but that's a bit more work and I don't want to do it right now.
		var Form = (Form) Control.FromHandle(gasme.Window.Handle); 

		if (Form == null || Form.ClientSize.Width == 0 || Form.ClientSize.Height == 0)
			return;

		Width = Form.ClientSize.Width;
		Height = Form.ClientSize.Height;

		Ratio = (float) Height / DefaultHeight;
		RatioScaleDown = 1f / Ratio;
		RatioInverse = (float) Height / SpriteRes;
	}

	[System.Runtime.Versioning.SupportedOSPlatform("windows6.1")]
	public void Update()
	{
		CalculateWindowSizes(game_);
	}
}
