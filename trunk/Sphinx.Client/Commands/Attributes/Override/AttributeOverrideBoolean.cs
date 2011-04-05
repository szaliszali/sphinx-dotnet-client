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
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Override
{
    /// <summary>
    /// Represents temprorary attribute boolean values and document IDs set to override.
    /// </summary>
    public class AttributeOverrideBoolean : AttributeOverrideBase, IAttributeValuesPerDocument<bool>
    {
        #region Fields
        private readonly Dictionary<long, bool> _values = new Dictionary<long, bool>();
        
        #endregion

        #region Constructors
        internal AttributeOverrideBoolean()
        {
        }

        public AttributeOverrideBoolean(string name, IDictionary<long, bool> values): base(name)
        {
            ArgumentAssert.IsNotEmpty(values, "values");
            CollectionUtil.UnionDictionaries(_values, values);
        }
        
        #endregion

        #region Properties

    	public override AttributeType AttributeType
        {
            get { return AttributeType.Boolean; }
        }

        #region Implementation of IAttributeValuesPerDocument
        public IDictionary<long, bool> Values
        {
            get { return _values; }
        }

        #endregion
        
        #endregion

        #region Methods
        internal override void Serialize(BinaryWriterBase writer)
        {
            base.Serialize(writer);
            // filter type
            writer.Write((int)AttributeType);
            // values count
            writer.Write(Values.Count);
            // value pairs
            foreach (KeyValuePair<long,bool> value in Values)
            {
                writer.Write(value.Key);
                writer.Write(value.Value);
            }
        }

        #endregion

    }
}
