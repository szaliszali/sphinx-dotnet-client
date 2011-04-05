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

namespace Sphinx.Client.Commands.Attributes.Update
{
    /// <summary>
    /// Represents attribute ordinal values and document IDs set to update.
    /// </summary>
	public class AttributeUpdateOrdinal : AttributeUpdateSinglePerDocumentBase<int>
    {
        #region Constructors
        internal AttributeUpdateOrdinal()
        {

        }

        public AttributeUpdateOrdinal(string name, IDictionary<long, int> values): base(name, values)
        {
        }
        
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.Ordinal; }
        }

        #endregion

        #region Methods
        internal override void Serialize(BinaryWriterBase writer, long id)
        {
            writer.Write(Values[id]);
        }

        #endregion


    }
}
