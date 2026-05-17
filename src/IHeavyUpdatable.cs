using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework
{
	public interface IHeavyUpdateable : IUpdateable
	{
		void HeavyUpdate();
	}
}
