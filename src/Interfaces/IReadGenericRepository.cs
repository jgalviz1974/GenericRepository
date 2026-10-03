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
        /// Queries the data source with typed parameters and returns the first JSON string result.
        /// </summary>
        /// <param name="commandText">The SQL command text or stored procedure name.</param>
        /// <param name="commandType">The command type.</param>
        /// <param name="parameters">Parameters added to the underlying database command.</param>
        /// <returns>The first JSON result, or an empty string when no rows are returned.</returns>
        string QueryAndReturnJson(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters);

        /// <summary>
        /// Queries the data source and returns the result as JSON, using the specified transaction.
        /// </summary>
        /// <param name="commandText">The command text to execute against the data source.</param>
        /// <param name="commandType">The type of the command (e.g., Text, StoredProcedure).</param>
        /// <param name="connection">The connection to use for executing the command. Must be open.</param>
        /// <param name="transaction">The transaction within which the command should be executed.</param>
        /// <returns>A JSON string containing the query results.</returns>
        /// <exception cref="Exception">Thrown when there is an error executing the query.</exception>
        string QueryAndReturnJson(string commandText, CommandType commandType, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        /// Queries the data source with typed parameters using the supplied connection and transaction.
        /// </summary>
        /// <param name="commandText">The SQL command text or stored procedure name.</param>
        /// <param name="commandType">The command type.</param>
        /// <param name="parameters">Parameters added to the underlying database command.</param>
        /// <param name="connection">The open connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>The first JSON result, or an empty string when no rows are returned.</returns>
        string QueryAndReturnJson(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        /// Queries the data source and returns the result as JSON, using the specified transaction.
        /// </summary>
        /// <param name="commandText">The command text to execute against the data source.</param>
        /// <param name="commandType">The type of the command (e.g., Text, StoredProcedure).</param>
        /// <param name="transaction">The transaction within which the command should be executed.</param>
        /// <returns>A JSON string containing the query results.</returns>
        /// <exception cref="Exception">Thrown when there is an error executing the query.</exception>
        string QueryAndReturnJson(string commandText, CommandType commandType, IDbTransaction transaction);

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
        /// Executes a scalar command with typed parameters.
        /// </summary>
        /// <typeparam name="T">The scalar result type.</typeparam>
        /// <param name="commandText">The SQL command text or stored procedure name.</param>
        /// <param name="commandType">The command type.</param>
        /// <param name="parameters">Parameters added to the underlying database command.</param>
        /// <returns>The first-column value of the first row converted to <typeparamref name="T"/>.</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters);

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
        T ExecuteScalar<T>(string commandText, CommandType commandType, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        /// Executes a scalar command with typed parameters using the supplied connection and transaction.
        /// </summary>
        /// <typeparam name="T">The scalar result type.</typeparam>
        /// <param name="commandText">The SQL command text or stored procedure name.</param>
        /// <param name="commandType">The command type.</param>
        /// <param name="parameters">Parameters added to the underlying database command.</param>
        /// <param name="connection">The open connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>The first-column value of the first row converted to <typeparamref name="T"/>.</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        /// Executes a reader command with typed parameters and maps all result sets while the repository owns the connection.
        /// </summary>
        /// <typeparam name="TResult">The mapped result type.</typeparam>
        /// <param name="commandText">The SQL command text or stored procedure name.</param>
        /// <param name="commandType">The command type.</param>
        /// <param name="parameters">Parameters added to the underlying database command.</param>
        /// <param name="map">Function that consumes the open reader and returns the result.</param>
        /// <returns>The mapped result.</returns>
        TResult ExecuteReader<TResult>(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters, Func<IDataReader, TResult> map);

        /// <summary>
        /// Executes a reader command with typed parameters in the supplied connection and transaction, mapping all result sets.
        /// </summary>
        /// <typeparam name="TResult">The mapped result type.</typeparam>
        /// <param name="commandText">The SQL command text or stored procedure name.</param>
        /// <param name="commandType">The command type.</param>
        /// <param name="parameters">Parameters added to the underlying database command.</param>
        /// <param name="connection">The open connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="map">Function that consumes the open reader and returns the result.</param>
        /// <returns>The mapped result.</returns>
        TResult ExecuteReader<TResult>(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters, IDbConnection connection, IDbTransaction transaction, Func<IDataReader, TResult> map);

        /// <summary>
        /// Ejecuta un comando SQL y devuelve el valor de la primera columna de la primera fila del conjunto de
        /// resultados, convertido al tipo especificado, usando la transacción proporcionada.
        /// </summary>
        /// <typeparam name="T">El tipo al que se convertirá el valor devuelto.</typeparam>
        /// <param name="commandText">El texto del comando SQL que se va a ejecutar. No puede ser nulo ni estar vacío.</param>
        /// <param name="commandType">El tipo de comando que se va a ejecutar, como texto o procedimiento almacenado.</param>
        /// <param name="transaction">La transacción de base de datos en la que se ejecutará el comando.</param>
        /// <returns>El valor de la primera columna de la primera fila del conjunto de resultados, convertido al tipo
        /// especificado. Si el resultado es DBNull, se devuelve el valor predeterminado de T.</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType, IDbTransaction transaction);

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
        object? Max(string tableName, string fieldName, object whereOrPrimaryKey, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        /// Obtiene el valor máximo de un campo específico en una tabla de base de datos, aplicando un filtro opcional o
        /// clave primaria y usando la transacción proporcionada.
        /// </summary>
        /// <param name="tableName">El nombre de la tabla en la que se realizará la consulta.</param>
        /// <param name="fieldName">El nombre del campo cuyo valor máximo se desea obtener.</param>
        /// <param name="whereOrPrimaryKey">Una condición de filtro para la consulta, que puede ser una expresión de filtro o el valor de la clave
        /// primaria. Si es null, se calcula el máximo sobre todos los registros.</param>
        /// <param name="transaction">La transacción de base de datos en la que se ejecutará la consulta.</param>
        /// <returns>El valor máximo encontrado en el campo especificado. Devuelve null si no existen registros que cumplan la
        /// condición.</returns>
        object? Max(string tableName, string fieldName, object whereOrPrimaryKey, IDbTransaction transaction);
    }
}
