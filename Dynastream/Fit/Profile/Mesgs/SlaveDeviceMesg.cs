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
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Linq;

namespace Dynastream.Fit
{
    /// <summary>
    /// Implements the SlaveDevice profile message.
    /// </summary>
    public class SlaveDeviceMessage : Message
    {
        #region Fields
        static class ProductSubfield
        {
            public static ushort GarminProduct = 0;
            public static ushort Subfields = 1;
            public static ushort Active = Fit.SubfieldIndexActiveSubfield;
            public static ushort MainField = Fit.SubfieldIndexMainField;
        }
        #endregion

        /// <summary>
        /// Field Numbers for <see cref="SlaveDeviceMessage"/>
        /// </summary>
        public sealed class FieldDefNum
        {
            public const byte Manufacturer = 0;
            public const byte Product = 1;
            public const byte Invalid = Fit.FieldNumInvalid;
        }

        #region Constructors
        public SlaveDeviceMessage() : base(Profile.GetMessage(MessageNum.SlaveDevice))
        {
        }

        public SlaveDeviceMessage(Message mesg) : base(mesg)
        {
        }
        #endregion // Constructors

        #region Methods
        ///<summary>
        /// Retrieves the Manufacturer field</summary>
        /// <returns>Returns nullable ushort representing the Manufacturer field</returns>
        public ushort? GetManufacturer()
        {
            Object val = GetFieldValue(0, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set Manufacturer field</summary>
        /// <param name="manufacturer_">Nullable field value to be set</param>
        public void SetManufacturer(ushort? manufacturer_)
        {
            SetFieldValue(0, 0, manufacturer_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the Product field</summary>
        /// <returns>Returns nullable ushort representing the Product field</returns>
        public ushort? GetProduct()
        {
            Object val = GetFieldValue(1, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set Product field</summary>
        /// <param name="product_">Nullable field value to be set</param>
        public void SetProduct(ushort? product_)
        {
            SetFieldValue(1, 0, product_, Fit.SubfieldIndexMainField);
        }
        

        /// <summary>
        /// Retrieves the GarminProduct subfield</summary>
        /// <returns>Nullable ushort representing the GarminProduct subfield</returns>
        public ushort? GetGarminProduct()
        {
            Object val = GetFieldValue(1, 0, ProductSubfield.GarminProduct);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        ///
        /// Set GarminProduct subfield</summary>
        /// <param name="garminProduct">Subfield value to be set</param>
        public void SetGarminProduct(ushort? garminProduct)
        {
            SetFieldValue(1, 0, garminProduct, ProductSubfield.GarminProduct);
        }
        #endregion // Methods
    } // Class
} // namespace
