// <copyright file="IReadGenericRepository.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Repository.Interfaces
{
    /// <summary>
    ///     Defines a contract for a generic read repository.
    /// </summary>
    public interface IReadGenericRepository
    {
        /// <summary>
        ///     Queries the data source and returns the result as JSON.
        /// </summary>
        /// <param name="commandText">
        ///     The command text to execute against the data source.
        /// </param>
        /// <param name="commandType">
        ///     The type of the command (e.g., Text, StoredProcedure).
        /// </param>
        /// <returns>
        ///     A JSON string containing the query results.
        /// </returns>
        /// <exception cref="Exception">
        ///     Thrown when there is an error executing the query.
        /// </exception>
        string QueryAndReturnJson(string commandText, CommandType commandType);
    }
}
