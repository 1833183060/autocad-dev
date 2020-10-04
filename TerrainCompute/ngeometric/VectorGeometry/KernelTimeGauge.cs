using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class KernelTimeGauge
	{
		public KernelTimeGauge()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(KernelTimeGauge));
			//base..ctor();
			KernelTimeGauge.QueryPerformanceFrequency(ref this.long_3);
		}

		[DllImport("Kernel32", CharSet = CharSet.Auto)]
		private static extern bool QueryPerformanceCounter(ref long long_4);

		[DllImport("Kernel32", CharSet = CharSet.Auto)]
		private static extern bool QueryPerformanceFrequency(ref long long_4);

		public void Reset()
		{
			this.long_0 = 0L;
			this.long_1 = 0L;
			this.long_2 = 0L;
		}

		public void ResetStart()
		{
			this.Reset();
			this.Start();
		}

		public void Start()
		{
			this.long_0 = 0L;
			KernelTimeGauge.QueryPerformanceCounter(ref this.long_0);
		}

		public void Stop()
		{
			this.long_1 = 0L;
			KernelTimeGauge.QueryPerformanceCounter(ref this.long_1);
			this.long_2 = this.long_1 - this.long_0;
		}

		public override string ToString()
		{
			return "Time elapsed: " + this.DurationInMilliSeconds + " ms";
		}

		public long DurationInMilliSeconds
		{
			get
			{
				return Convert.ToInt64(1000.0 * this.DurationInSeconds);
			}
		}

		public double DurationInSeconds
		{
			get
			{
				return Convert.ToDouble(this.long_2) / Convert.ToDouble(this.long_3);
			}
		}

		public long Frequency
		{
			get
			{
				return this.long_3;
			}
		}

		private long long_0;

		private long long_1;

		private long long_2;

		private long long_3;
	}
}
