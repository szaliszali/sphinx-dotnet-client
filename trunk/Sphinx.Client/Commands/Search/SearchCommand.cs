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
using Sphinx.Client.Commands.Collections;
using Sphinx.Client.Connections;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Search
{
    /// <summary>
    /// Represents Sphinx search command to perform batch search using specified query list.
    /// </summary>
    public class SearchCommand : CommandWithResultBase<SearchCommandResult>
    {
        #region Constants
        internal const short COMMAND_VERSION = 0x117;
        private const int MAX_QUERIES = 32;
        
        #endregion

        #region Fields
        private static readonly CommandInfo _commandInfo = new CommandInfo(ServerCommand.Search, COMMAND_VERSION);

        private readonly SearchQueryList _queryList = new SearchQueryList();

        #endregion

        #region Constructors
        public SearchCommand(ConnectionBase connection): base(connection)
        {
        }

        public SearchCommand(ConnectionBase connection, IEnumerable<SearchQuery> queryList): base(connection)
        {
            QueryList.AddRange(queryList);
        }

        public SearchCommand(ConnectionBase connection, SearchQuery query): base(connection)
        {
            QueryList.Add(query);
        }
        #endregion

        #region Properties

        #region Command parameters
        /// <summary>
        /// Search query list
        /// </summary>
        public SearchQueryList QueryList
        {
            get { return _queryList; }
        }
        
        #endregion

        #region Overrides of CommandWithResultBase
        protected override CommandInfo CommandInfo
        {
            get { return _commandInfo; }
        }

        #endregion

        #endregion

        #region Methods

        #region Overrides of CommandWithResultBase
        public override void Execute()
        {
            ArgumentAssert.IsInRange(QueryList.Count, 1, MAX_QUERIES, "QueryList.Count");

            base.Execute();
        }

        protected override void SerializeRequest(BinaryWriterBase writer)
        {
            QueryList.Serialize(writer);
        }

        protected override void DeserializeResponse(BinaryReaderBase reader)
        {
            Result.Deserialize(reader, QueryList.Count);
        }

        #endregion

	    #endregion    
    }
}
