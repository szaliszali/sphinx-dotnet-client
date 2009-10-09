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
using Sphinx.Client.Commands.Attributes.Update;
using Sphinx.Client.Commands.Collections;
using Sphinx.Client.Connections;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.UpdateAttributes
{
    /// <summary>
    /// Represents command to instantly update given attribute values in given documents. Returns number of actually affected documents. 
    /// </summary>
    public class UpdateAttributesCommand : CommandWithResultBase<UpdateAttributesCommandResult>
    {
        #region Constants
        internal const short COMMAND_VERSION = 0x102;

        #endregion

        #region Fields
        private static readonly CommandInfo _commandInfo = new CommandInfo(ServerCommand.Update, COMMAND_VERSION);

        private readonly StringList _indexNames = new StringList();
        private readonly AttributeUpdateList _attributesValues = new AttributeUpdateList();

        #endregion

        #region Constructors
        public UpdateAttributesCommand(ConnectionBase connection): base(connection)
        {
        }

        public UpdateAttributesCommand(ConnectionBase connection, IEnumerable<string> indexes, IEnumerable<AttributeUpdateBase> attributesValues): base(connection)
        {
            Indexes.UnionWith(indexes);
            AttributesValues.UnionWith(attributesValues);
        }
        #endregion

        #region Properties

        #region Command parameters
        /// <summary>
        /// List of index names to be updated
        /// </summary>
        public StringList Indexes
        {
            get { return _indexNames; }
        }

        /// <summary>
        /// Attributes list to update and new values 
        /// </summary>
        public AttributeUpdateList AttributesValues
        {
            get { return _attributesValues; }
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
        /// <summary>
        /// Execute command against specified <see cref=".Connection"/>
        /// </summary>
        public override void Execute()
        {
            ArgumentAssert.IsGreaterThan(Indexes.Count, 0, "Indexes.Count");
            ArgumentAssert.IsGreaterThan(AttributesValues.Count, 0, "AttributesValues.Count");

            base.Execute();
        }

        /// <summary>
        /// Serialize command parameters using specified binary stream writer.
        /// </summary>
        /// <param name="writer">Binary stream writer object</param>
        protected override void SerializeRequest(BinaryWriterBase writer)
        {
            Indexes.Serialize(writer);
            AttributesValues.Serialize(writer);
        }

        /// <summary>
        /// Deserialize server response body using specified binary stream reader.
        /// </summary>
        /// <param name="reader">Binary stream reader object</param>
        protected override void DeserializeResponse(BinaryReaderBase reader)
        {
            Result.Deserialize(reader); 
        }

        #endregion
 
	    #endregion    
    }
}
