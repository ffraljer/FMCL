using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework
{
	internal class GameClock
	{
		private long baseRealTime;

		private TimeSpan currentTimeBase;

		private TimeSpan currentTimeOffset;

		private TimeSpan elapsedAdjustedTime;

		private TimeSpan elapsedTime;

		private long lastRealTime;

		private bool lastRealTimeValid;

		private int suspendCount;

		private long suspendStartTime;

		private long timeLostToSuspension;

		private bool first = true;

		internal static long Counter => Stopwatch.GetTimestamp();

		internal TimeSpan CurrentTime => currentTimeBase + currentTimeOffset;

		internal TimeSpan ElapsedAdjustedTime => elapsedAdjustedTime;

		internal TimeSpan ElapsedTime => elapsedTime;

		internal static long Frequency => Stopwatch.Frequency;

		public GameClock()
		{
			Reset();
		}

		private static TimeSpan CounterToTimeSpan(long delta)
		{
			long num = 10000000L;
			return TimeSpan.FromTicks(delta * num / Frequency);
		}

		internal void Reset()
		{
			currentTimeBase = TimeSpan.Zero;
			currentTimeOffset = TimeSpan.Zero;
			baseRealTime = Counter;
			lastRealTimeValid = false;
		}

		internal void Resume()
		{
			suspendCount--;
			if (suspendCount <= 0)
			{
				long counter = Counter;
				timeLostToSuspension += counter - suspendStartTime;
				suspendStartTime = 0L;
			}
		}

		internal void Step()
		{
			long counter = Counter;
			if (!lastRealTimeValid)
			{
				lastRealTime = counter;
				lastRealTimeValid = true;
			}
			try
			{
				currentTimeOffset = CounterToTimeSpan(counter - baseRealTime);
			}
			catch (OverflowException)
			{
				currentTimeBase += currentTimeOffset;
				baseRealTime = lastRealTime;
				currentTimeOffset = CounterToTimeSpan(counter - baseRealTime);
			}
			try
			{
				elapsedTime = CounterToTimeSpan(counter - lastRealTime);
			}
			catch (OverflowException)
			{
				elapsedTime = TimeSpan.Zero;
			}
			try
			{
				long num = lastRealTime + timeLostToSuspension;
				elapsedAdjustedTime = CounterToTimeSpan(counter - num);
				timeLostToSuspension = 0L;
			}
			catch (OverflowException)
			{
				elapsedAdjustedTime = TimeSpan.Zero;
			}
			lastRealTime = counter;
		}

		internal void Suspend()
		{
			suspendCount++;
			if (suspendCount == 1)
			{
				suspendStartTime = Counter;
			}
		}
	}
}
