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
using Sphinx.Client.Commands.Search;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    /// <summary>
    /// Represents list of <see cref="WordInfo"/> objects, contains information about keyword and optional hit statistics.
    /// </summary>
    public class WordsInfoList : List<WordInfo>
    {
        #region Methods
        /// <summary>
        /// Deserialize object state from stream using specified binary stream reader.
        /// </summary>
        /// <param name="reader">Binary stream reader object</param>
        internal void Deserialize(BinaryReaderBase reader)
        {
            Clear();
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                WordInfo word = new WordInfo();
                word.Deserialize(reader);
                Add(word);
            }
        }

        #endregion
    }
}
