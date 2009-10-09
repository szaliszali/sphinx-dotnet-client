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
using Sphinx.Client.Commands.BuildKeywords;
using Sphinx.Client.Commands.Collections;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands
{
    public class BuildKeywordsCommandResult : CommandResultBase
    {
        #region Fields
        private readonly KeywordInfoList _keywordInfoList = new KeywordInfoList();
        
        #endregion

        #region Properties
        public IList<KeywordInfo> Keywords
        {
            get
            {
                return _keywordInfoList;
            }
        }
        
        #endregion

        #region Methods
        internal void Deserialize(BinaryReaderBase reader, bool calcStatistics)
        {
            _keywordInfoList.Deserialize(reader, calcStatistics);
        }

        #endregion
    }
}
