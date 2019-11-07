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
using System.IO;
using System.Linq;

namespace Dynastream.Fit
{
    internal class DeveloperDataLookup
    {
        private readonly Dictionary<DeveloperDataKey, FieldDescriptionMessage> m_fieldDescriptionMessages;
        private readonly Dictionary<byte, DeveloperDataIdMessage> m_developerDataIdMessages;

        public DeveloperDataLookup()
        {
            m_fieldDescriptionMessages = new Dictionary<DeveloperDataKey, FieldDescriptionMessage>();
            m_developerDataIdMessages = new Dictionary<byte, DeveloperDataIdMessage>();
        }

        public Tuple<DeveloperDataIdMessage, FieldDescriptionMessage> GetMessages(DeveloperDataKey key)
        {
            DeveloperDataIdMessage devIdMessage;
            FieldDescriptionMessage descriptionMessage;

            m_developerDataIdMessages.TryGetValue(key.DeveloperDataIndex, out devIdMessage);
            m_fieldDescriptionMessages.TryGetValue(key, out descriptionMessage);

            if (devIdMessage != null && descriptionMessage != null)
            {
                return new Tuple<DeveloperDataIdMessage, FieldDescriptionMessage>(
                    devIdMessage,
                    descriptionMessage);
            }

            return null;
        }

        public void Add(DeveloperDataIdMessage mesg)
        {
            byte? index = mesg.GetDeveloperDataIndex();
            if (index == null)
                return;

            m_developerDataIdMessages[index.Value] = mesg;

            // Remove all fields currently associated with this developer
            var keysToRemove =
                m_fieldDescriptionMessages.Keys
                                  .Where(
                                      x =>
                                          x.DeveloperDataIndex ==
                                          index)
                                  .ToList();
            foreach (var key in keysToRemove)
            {
                m_fieldDescriptionMessages.Remove(key);
            }
        }

        public DeveloperFieldDescription Add(FieldDescriptionMessage mesg)
        {
            DeveloperFieldDescription desc = null;

            byte? developerDataIndex = mesg.GetDeveloperDataIndex();
            byte? fieldDefinitionNumber = mesg.GetFieldDefinitionNumber();
            if ((developerDataIndex != null) &&
                (fieldDefinitionNumber != null))
            {
                var key = new DeveloperDataKey(
                    (byte)developerDataIndex,
                    (byte)fieldDefinitionNumber);

                m_fieldDescriptionMessages[key] = mesg;

                // Build a Description of the pairing we just created
                var pair = GetMessages(key);
                if (pair != null)
                {
                    desc = new DeveloperFieldDescription(pair.Item1, pair.Item2);
                }
            }

            return desc;
        }
    }
} // namespace
