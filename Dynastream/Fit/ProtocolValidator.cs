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

using System.Linq;

namespace Dynastream.Fit
{
    internal interface IValidator
    {
        /// <summary>
        /// Validate if a Message is compatible with a protocol version
        /// </summary>
        /// <param name="mesg">Message to validate</param>
        /// <returns>true if message is compatible. false otherwise</returns>
        bool ValidateMessage(Message mesg);

        /// <summary>
        /// Validate if a MessageDefinition is compatible with a protocol version
        /// </summary>
        /// <param name="defn">Definition to validate</param>
        /// <returns>true if definition is compatible. false otherwise</returns>
        bool ValidateMessageDefn(MessageDefinition defn);
    }

    /// <summary>
    /// Validates Protocol Features for a given give version
    /// </summary>
    internal class ProtocolValidator
        : IValidator
    {
        private readonly IValidator m_validator;

        public ProtocolValidator(ProtocolVersion version)
        {
            switch (version)
            {
                case ProtocolVersion.V10:
                    m_validator = new V1Validator();
                    break;

                default:
                    m_validator = null;
                    break;
            }
        }

        /// <summary>
        /// Validate if a Message is compatible with a protocol version
        /// </summary>
        /// <param name="mesg">Message to validate</param>
        /// <returns>true if message is compatible. false otherwise</returns>
        public bool ValidateMessage(Message mesg)
        {
            if (m_validator == null)
                return true;

            return m_validator.ValidateMessage(mesg);
        }

        /// <summary>
        /// Validate if a MessageDefinition is compatible with a protocol version
        /// </summary>
        /// <param name="defn">Definition to validate</param>
        /// <returns>true if definition is compatible. false otherwise</returns>
        public bool ValidateMessageDefn(MessageDefinition defn)
        {
            if (m_validator == null)
                return true;

            return m_validator.ValidateMessageDefn(defn);
        }
    } // Class

    internal class V1Validator
        : IValidator
    {
        /// <summary>
        /// Validate if a Message is compatible with a protocol version
        /// </summary>
        /// <param name="mesg">Message to validate</param>
        /// <returns>true if message is compatible. false otherwise</returns>
        public bool ValidateMessage(Message mesg)
        {
            if (mesg.DeveloperFields.Any())
            {
                return false;
            }

            foreach (var fld in mesg.Fields)
            {
                int typeNum = fld.Type & Fit.BaseTypeNumMask;

                if (typeNum > Fit.Byte)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Validate if a MessageDefinition is compatible with a protocol version
        /// </summary>
        /// <param name="defn">Definition to validate</param>
        /// <returns>true if definition is compatible. false otherwise</returns>
        public bool ValidateMessageDefn(MessageDefinition defn)
        {
            if (defn.DeveloperFieldDefinitions.Any())
            {
                return false;
            }

            foreach (var fld in defn.GetFields())
            {
                int typeNum = fld.Type & Fit.BaseTypeNumMask;

                if (typeNum > Fit.Byte)
                {
                    return false;
                }
            }

            return true;
        }
    }
} // namespace
