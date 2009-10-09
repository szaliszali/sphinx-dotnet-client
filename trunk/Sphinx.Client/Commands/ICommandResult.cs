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
namespace Sphinx.Client.Commands
{
    public interface ICommandResult<TResult> where TResult : CommandResultBase, new()
    {
        /// <summary>
        /// Command execution result object. Holds all information returned by server, including command execution state and Sphinx server warnings.
        /// </summary>
        TResult Result { get; }
    }
}
