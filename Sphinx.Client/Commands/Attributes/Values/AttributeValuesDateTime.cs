#region Copyright
// 
// Copyright (c) 2009-2011, Rustam Babadjanov <theplacefordev [at] gmail [dot] com>
// 
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License version 2.1 as published
// by the Free Software Foundation.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
#endregion
#region Usings

using System;
using System.Collections.Generic;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Values
{
    /// <summary>
    /// Represents DateTime attribute values in matched document.
    /// </summary>
    public class AttributeValuesDateTime : AttributeValueBase, IAttributeValues<DateTime>
    {
        #region Fields
        private readonly List<DateTime> _values;
        
        #endregion

        #region Constructors
        internal AttributeValuesDateTime()
        {
			_values = new List<DateTime>();
        }

        public AttributeValuesDateTime(string name, IEnumerable<DateTime> values): base(name)
        {
            _values.AddRange(values);
        }
        
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.MultiTimestamp; }
        }

        #region Implementation of IAttributeValues
        public IList<DateTime> Values
        {
            get { return _values; }
        }

        #endregion

        #endregion

        #region Methods
        public override object GetValue()
        {
            return Values;
        }

        internal override void Deserialize(IBinaryReader reader, AttributeInfo attributeInfo)
        {
            base.Deserialize(reader, attributeInfo);
            int count = reader.ReadInt32();
            for (int i=0; i < count; i++)
            {
                _values.Add(reader.ReadDateTime());
            }
        }

        #endregion

    }
}
