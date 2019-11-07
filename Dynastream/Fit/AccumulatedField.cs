#region Copyright
////////////////////////////////////////////////////////////////////////////////
// The following FIT Protocol software provided may be used with FIT protocol
// devices only and remains the copyrighted property of Dynastream Innovations Inc.
// The software is being provided on an "as-is" basis and as an accommodation,
// and therefore all warranties, representations, or guarantees of any kind
// (whether express, implied or statutory) including, without limitation,
// warranties of merchantability, non-infringement, or fitness for a particular
// purpose, are specifically disclaimed.
//
// Copyright 2017 Dynastream Innovations Inc.
////////////////////////////////////////////////////////////////////////////////
// ****WARNING****  This file is auto-generated!  Do NOT edit this file.
// Profile Version = 20.54Release
// Tag = production/akw/20.54.00-0-ga49a69a
////////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynastream.Fit
{
    public class AccumulatedField
    {
        public int mesgNum;
        public int destFieldNum;
        private long lastValue;
        private long accumulatedValue;

        public AccumulatedField(int mesgNum, int destFieldNum)
        {
            this.mesgNum = mesgNum;
            this.destFieldNum = destFieldNum;
            this.lastValue = 0;
            this.accumulatedValue = 0;
        }

        public long Accumulate(long value, int bits)
        {
            long mask = (1L << bits) - 1;

            accumulatedValue += (value - lastValue) & mask;
            lastValue = value;

            return accumulatedValue;
        }

        public long Set(long value)
        {
            accumulatedValue = value;
            this.lastValue = value;
            return accumulatedValue;
        }
    }
}
