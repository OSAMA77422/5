using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    internal struct Point
    {
		private double x;
		private double y;

		public double Y
		{
			get { return y;}
			set { y = value;}
		}

		public double X
		{
			get { return x; }
			set{ this.x = value;}
		}

	}
}
