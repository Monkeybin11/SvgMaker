﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvgMakerCore.Geometry2D
{
    public static class Utility
    {
        public static bool Tolerance(double t0, double t1, double tolerance = 0.0001D)
        {
            return Math.Abs(t0 - t1) > tolerance;
        }
    }
}