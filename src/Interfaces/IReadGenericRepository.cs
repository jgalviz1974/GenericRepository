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

        /// <summary>
        /// Queries the data source and returns the result as JSON, using the specified transaction.
        /// </summary>
        /// <param name="commandText">The command text to execute against the data source.</param>
        /// <param name="commandType">The type of the command (e.g., Text, StoredProcedure).</param>
        /// <param name="connection">The SQL connection to use for executing the command. Must be open.</param>
        /// <param name="transaction">The transaction within which the command should be executed.</param>
        /// <returns>A JSON string containing the query results.</returns>
        /// <exception cref="Exception">Thrown when there is an error executing the query.</exception>
        string QueryAndReturnJson(string commandText, CommandType commandType, SqlConnection connection, IDbTransaction transaction);

        /// <summary>
        /// Queries the data source and returns a single scalar value of type T.
        /// </summary>
        /// <typeparam name="T">The type of the scalar value to return.</typeparam>
        /// <param name="commandText">The command text to execute against the data source.</param>
        /// <param name="commandType">The type of the command (e.g., Text, StoredProcedure).</param>
        /// <returns>The scalar value of type T.</returns>
        /// <exception cref="Exception">Thrown when there is an error executing the query.</exception>
        T ExecuteScalar<T>(string commandText, CommandType commandType);

        /// <summary>
        /// Ejecuta un comando SQL y devuelve el valor de la primera columna de la primera fila del conjunto de
        /// resultados, convertido al tipo especificado.
        /// </summary>
        /// <typeparam name="T">El tipo al que se convertirá el valor devuelto.</typeparam>
        /// <param name="commandText">El texto del comando SQL que se va a ejecutar. No puede ser nulo ni estar vacío.</param>
        /// <param name="commandType">El tipo de comando que se va a ejecutar, como texto o procedimiento almacenado.</param>
        /// <param name="connection">The SQL connection to use for executing the command. Must be open.</param>
        /// <param name="transaction">La transacción de base de datos en la que se ejecutará el comando, o null para ejecutar fuera de una
        /// transacción.</param>
        /// <returns>El valor de la primera columna de la primera fila del conjunto de resultados, convertido al tipo
        /// especificado. Si el resultado es DBNull, se devuelve el valor predeterminado de T.</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType, SqlConnection connection, IDbTransaction transaction);

        /// <summary>
        /// Gets the maximum value of the specified field for the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="whereOrPrimaryKey">The criteria or primary key value.</param>
        /// <returns>The maximum value as an object.</returns>
        object? Max(string tableName, string fieldName, object whereOrPrimaryKey);

        /// <summary>
        /// Obtiene el valor máximo de un campo específico en una tabla de base de datos, aplicando un filtro opcional o
        /// clave primaria.
        /// </summary>
        /// <param name="tableName">El nombre de la tabla en la que se realizará la consulta.</param>
        /// <param name="fieldName">El nombre del campo cuyo valor máximo se desea obtener.</param>
        /// <param name="whereOrPrimaryKey">Una condición de filtro para la consulta, que puede ser una expresión de filtro o el valor de la clave
        /// primaria. Si es null, se calcula el máximo sobre todos los registros.</param>
        /// <param name="connection">La conexión de base de datos SQL Server que se utilizará para ejecutar la consulta. Debe estar abierta.</param>
        /// <param name="transaction">La transacción de base de datos en la que se ejecutará la consulta, o null si no se utiliza ninguna
        /// transacción.</param>
        /// <returns>El valor máximo encontrado en el campo especificado. Devuelve null si no existen registros que cumplan la
        /// condición.</returns>
        object? Max(string tableName, string fieldName, object whereOrPrimaryKey, SqlConnection connection, IDbTransaction transaction);
    }
}
