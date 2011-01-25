#region Copyright
// 
// Copyright (c) 2009, Rustam Babadjanov <theplacefordev [at] gmail [dot] com>
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

using System.Collections.Generic;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Values
{
    /// <summary>
    /// Represents float attribute values in matched document.
    /// </summary>
    public class AttributeValuesFloat : AttributeValueBase, IAttributeValues<float>
    {
        #region Fields
        private readonly List<float> _values;

        #endregion

        #region Constructors
        internal AttributeValuesFloat()
        {
			_values = new List<float>();
        }

        public AttributeValuesFloat(string name, List<float> values): base(name)
        {
            _values = values;
        }
        
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.MultiFloat; }
        }

        #region Implementation of IAttributeValues
        public IList<float> Values
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

        internal override void Deserialize(BinaryReaderBase reader, AttributeInfo attributeInfo)
        {
            base.Deserialize(reader, attributeInfo);
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                _values.Add(reader.ReadSingle());
            }
        }

        #endregion
    }
}
