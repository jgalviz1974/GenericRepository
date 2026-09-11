// <copyright file="IWriteGenericRepository.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Repository.Interfaces
{
    /// <summary>
    ///     Defines a repository with methods for adding, updating, and deleting entities of type <typeparamref name="T" />
    ///     in the data source. This is the write-only part of the repository, meant to be used when the data is
    ///     not needed to be read immediately after being written.
    /// </summary>
    /// <typeparam name="T">The type of the entities in the repository.</typeparam>
    /// <typeparam name="TKey">The type of the primary key of the entities.</typeparam>
    public interface IWriteGenericRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        /// <summary>
        ///     Inserts a new entity into the data source.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>
        ///     The primary key of the inserted entity.
        /// </returns>
        TKey Insert(T entity);

        /// <summary>
        ///     Inserts a new entity into the data source using the provided connection and transaction.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The primary key of the inserted entity.
        /// </returns>
        TKey Insert(T entity, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Inserts a range of new entities into the data source.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        /// <returns>
        ///     The number of entities that were inserted.
        /// </returns>
        int InsertAll(IEnumerable<T> entities);

        /// <summary>
        ///     Inserts a range of new entities into the data source using the provided connection and transaction.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were inserted.
        /// </returns>
        int InsertAll(IEnumerable<T> entities, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Inserts a range of new entities into the data source using the provided transaction.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were inserted.
        /// </returns>
        int InsertAll(IEnumerable<T> entities, IDbTransaction transaction);

        /// <summary>
        /// Inserts a collection of entities into the database in bulk, optionally using custom column mappings and
        /// additional options.
        /// </summary>
        /// <remarks>This method is optimized for high-performance bulk insert operations and can
        /// significantly improve throughput compared to individual inserts. When using custom mappings, ensure that the
        /// mapping definitions accurately reflect the target database schema. If a transaction is provided, the bulk
        /// insert is executed within its scope.</remarks>
        /// <param name="entities">The collection of entities to insert. Cannot be null or empty.</param>
        /// <param name="mappings">An optional collection of mapping definitions that specify how entity properties map to database columns. If
        /// null, default property-to-column mapping is used.</param>
        /// <param name="options">Bulk insert options.</param>
        /// <param name="transaction">An optional transaction to associate with the bulk insert operation. If null, the operation is executed
        /// without a transaction.</param>
        /// <returns>The identity value of the inserted entities if ReturnIdentity is true; otherwise, the default value of
        /// TKey.</returns>
        TKey BulkInsert(IEnumerable<T> entities, IEnumerable<BulkInsertColumnMap>? mappings = null, BulkInsertOptions? options = null, IDbTransaction? transaction = null);

        /// <summary>
        ///     Merges the state of the given entity into the current session.
        /// </summary>
        /// <param name="entity">The entity to merge.</param>
        /// <returns>
        ///     The primary key of the merged entity.
        /// </returns>
        TKey Merge(T entity);

        /// <summary>
        ///     Merges the state of the given entity into the current session with qualifiers.
        /// </summary>
        /// <param name="entity">The entity to merge.</param>
        /// <param name="qualifiers">The qualifiers for the merge.</param>
        /// <returns>
        ///     The primary key of the merged entity.
        /// </returns>
        TKey Merge(T entity, IEnumerable<string> qualifiers);

        /// <summary>
        ///     Merges the state of the given entity into the current session with qualifiers using the provided
        ///     connection and transaction.
        /// </summary>
        /// <param name="entity">The entity to merge.</param>
        /// <param name="qualifiers">The qualifiers for the merge.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The primary key of the merged entity.
        /// </returns>
        TKey Merge(T entity, IEnumerable<string> qualifiers, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Merges the state of the given entity into the current session with qualifiers using the provided
        ///     transaction.
        /// </summary>
        /// <param name="entity">The entity to merge.</param>
        /// <param name="qualifiers">The qualifiers for the merge.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The primary key of the merged entity.
        /// </returns>
        TKey Merge(T entity, IEnumerable<string> qualifiers, IDbTransaction transaction);

        /// <summary>
        ///     Merges the state of the given entity into the current session using the provided connection and
        ///     transaction.
        /// </summary>
        /// <param name="entity">The entity to merge.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The primary key of the merged entity.
        /// </returns>
        TKey Merge(T entity, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Merges a range of entities into the current session.
        /// </summary>
        /// <param name="entities">The entities to merge.</param>
        /// <returns>
        ///     The number of entities that were merged.
        /// </returns>
        int MergeAll(IEnumerable<T> entities);

        /// <summary>
        ///     Merges a range of entities into the current session using the provided connection and transaction.
        /// </summary>
        /// <param name="entities">The entities to merge.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were merged.
        /// </returns>
        int MergeAll(IEnumerable<T> entities, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Merges a range of entities into the current session using the provided transaction.
        /// </summary>
        /// <param name="entities">The entities to merge.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were merged.
        /// </returns>
        int MergeAll(IEnumerable<T> entities, IDbTransaction transaction);

        /// <summary>
        ///     Deletes an entity with the given primary key or criteria.
        /// </summary>
        /// <param name="whereOrPrimaryKey">The primary key or criteria of the entity to delete.</param>
        /// <returns>
        ///     The number of entities that were deleted.
        /// </returns>
        int Delete(object whereOrPrimaryKey);

        /// <summary>
        ///    Deletes an entity with the given primary key or criteria using the provided connection and transaction.
        /// </summary>
        /// <param name="whereOrPrimaryKey">The primary key or criteria of the entity to delete.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were deleted.
        /// </returns>
        int Delete(object whereOrPrimaryKey, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Deletes a range of entities.
        /// </summary>
        /// <param name="entities">The entities to delete.</param>
        /// <returns>
        ///     The number of entities that were deleted.
        /// </returns>
        int DeleteAll(IEnumerable<T> entities);

        /// <summary>
        ///     Deletes a range of entities using the provided connection and transaction.
        /// </summary>
        /// <param name="entities">The entities to delete.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were deleted.
        /// </returns>
        int DeleteAll(IEnumerable<T> entities, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Deletes a range of entities using the provided transaction.
        /// </summary>
        /// <param name="entities">The entities to delete.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were deleted.
        /// </returns>
        int DeleteAll(IEnumerable<T> entities, IDbTransaction transaction);

        /// <summary>
        ///     Updates the given entity in the data source.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>
        ///     The number of entities that were updated.
        /// </returns>
        int Update(T entity);

        /// <summary>
        ///     Updates the given entity in the data source using the provided connection and transaction.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were updated.
        /// </returns>
        int Update(T entity, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Updates a range of entities in the data source.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        /// <returns>
        ///     The number of entities that were updated.
        /// </returns>
        int UpdateAll(IEnumerable<T> entities);

        /// <summary>
        ///     Updates a range of entities in the data source using the provided connection and transaction.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were updated.
        /// </returns>
        int UpdateAll(IEnumerable<T> entities, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Updates a range of entities in the data source using the provided transaction.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The number of entities that were updated.
        /// </returns>
        int UpdateAll(IEnumerable<T> entities, IDbTransaction transaction);

        /// <summary>
        ///     Executes a command that does not return any rows.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     The number of rows affected.
        /// </returns>
        int ExecuteNonQuery(string commandText, CommandType commandType, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///    Executes a command that does not return any rows, using the provided transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     The number of rows affected.
        /// </returns>
        int ExecuteNonQuery(string commandText, CommandType commandType, IDbTransaction transaction, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///     Executes a command that returns a single value.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     The result of the command.
        /// </returns>
        TKey ExecuteScalar(string commandText, CommandType commandType, IEnumerable<DbParameter>? parameters);

        /// <summary>
        ///    Executes a command that returns a single value, using the provided transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     The result of the command.
        /// </returns>
        TKey ExecuteScalar(string commandText, CommandType commandType, IDbTransaction transaction, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///     Executes a command that returns a single value.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <returns>
        ///     The result of the command.
        /// </returns>
        string ExecuteScalar(string commandText, CommandType commandType);

        /// <summary>
        ///     Executes a command that returns a single value, using the provided transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The result of the command.
        /// </returns>
        string ExecuteScalar(string commandText, CommandType commandType, IDbTransaction transaction);

        /// <summary>
        ///     Executes a command that returns a single value using the provided connection and transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <returns>
        ///     The result of the command.
        /// </returns>
        string ExecuteScalar(string commandText, CommandType commandType, IDbConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Executes a command that returns a data reader.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     A data reader for reading the result set.
        /// </returns>
        IDataReader ExecuteReader(string commandText, CommandType commandType, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///     Executes a command that returns a data reader using the provided transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     A data reader for reading the result set.
        /// </returns>
        IDataReader ExecuteReader(string commandText, CommandType commandType, IDbTransaction transaction, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///     Executes a command that returns a data reader using the provided connection and transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     A data reader for reading the result set.
        /// </returns>
        IDataReader ExecuteReader(string commandText, CommandType commandType, IDbConnection connection, IDbTransaction transaction, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///     Executes a query that returns a sequence of entities.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     A sequence of entities of type <typeparamref name="T" />.
        /// </returns>
        IEnumerable<T> ExecuteQuery(string commandText, CommandType commandType, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///     Executes a query that returns a sequence of entities using the provided transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     A sequence of entities of type <typeparamref name="T" />.
        /// </returns>
        IEnumerable<T> ExecuteQuery(string commandText, CommandType commandType, IDbTransaction transaction, IEnumerable<DbParameter>? parameters = null);

        /// <summary>
        ///     Executes a query that returns a sequence of entities using the provided connection and transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     A sequence of entities of type <typeparamref name="T" />.
        /// </returns>
        IEnumerable<T> ExecuteQuery(string commandText, CommandType commandType, IDbConnection connection, IDbTransaction transaction, IEnumerable<DbParameter>? parameters = null);
    }
}

