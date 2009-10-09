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
using Sphinx.Client.Commands.Status;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    /// <summary>
    /// Sphinx server status information variables list.
    /// </summary>
    public class StatusInfoList : List<StatusInfo>
    {
        #region Methods
        /// <summary>
        /// Deserialize object state from stream using specified binary stream reader.
        /// </summary>
        /// <param name="reader">Binary stream reader object</param>
        internal void Deserialize(BinaryReaderBase reader)
        {
            Clear();
            int rows = reader.ReadInt32();
            int cols = reader.ReadInt32();
            for (int i=0; i < rows; i++)
            {
                StatusInfo statusRow = new StatusInfo();
                statusRow.Deserialize(reader, cols);
                Add(statusRow);
            }
        }

        #endregion
    }
}
