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
        TKey Insert(T entity, SqlConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Inserts a range of new entities into the data source.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        /// <returns>
        ///     The number of entities that were inserted.
        /// </returns>
        int InsertAll(IEnumerable<T> entities);

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
        TKey Merge(T entity, IEnumerable<Field> qualifiers);

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
        TKey Merge(T entity, SqlConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Merges a range of entities into the current session.
        /// </summary>
        /// <param name="entities">The entities to merge.</param>
        /// <returns>
        ///     The number of entities that were merged.
        /// </returns>
        int MergeAll(IEnumerable<T> entities);

        /// <summary>
        ///     Deletes an entity with the given primary key or criteria.
        /// </summary>
        /// <param name="whereOrPrimaryKey">The primary key or criteria of the entity to delete.</param>
        /// <returns>
        ///     The number of entities that were deleted.
        /// </returns>
        int Delete(object whereOrPrimaryKey);

        /// <summary>
        ///     Deletes a range of entities.
        /// </summary>
        /// <param name="entities">The entities to delete.</param>
        /// <returns>
        ///     The number of entities that were deleted.
        /// </returns>
        int DeleteAll(IEnumerable<T> entities);

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
        int Update(T entity, SqlConnection connection, IDbTransaction transaction);

        /// <summary>
        ///     Updates a range of entities in the data source.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        /// <returns>
        ///     The number of entities that were updated.
        /// </returns>
        int UpdateAll(IEnumerable<T> entities);

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
        ///     Executes a command that returns a single value.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     The result of the command.
        /// </returns>
        TKey ExecuteScalar(string commandText, CommandType commandType, IEnumerable<DbParameter>? parameters = null);

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
        ///     Executes a query that returns a sequence of entities.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">The type of the command.</param>
        /// <param name="parameters">The parameters for the command.</param>
        /// <returns>
        ///     A sequence of entities of type <typeparamref name="T" />.
        /// </returns>
        IEnumerable<T> ExecuteQuery(string commandText, CommandType commandType, IEnumerable<DbParameter>? parameters = null);
    }
}
