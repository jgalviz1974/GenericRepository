// <copyright file="IReadGenericRepositoryT.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Repository.Interfaces
{
    /// <summary>
    /// Defines the contract for a read-only repository that provides data access
    /// for entities of type <typeparamref name="T"/> with a primary key of type <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileNameMustMatchTypeName", Justification = "Reviewed.")]
    public interface IReadGenericRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        /// <summary>
        /// Queries the repository for entities matching the specified criteria.
        /// </summary>
        /// <param name="whereOrPrimaryKey">The criteria or primary key value.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> representing the matching entities.</returns>
        IEnumerable<T> Query(object whereOrPrimaryKey);

        /// <summary>
        /// Queries the repository for entities matching the specified criteria and allows
        /// ordering the results.
        /// </summary>
        /// <param name="whereOrPrimaryKey">The criteria or primary key value.</param>
        /// <param name="orderBy">The ordering specifications.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> representing the matching entities.</returns>
        IEnumerable<T> Query(object whereOrPrimaryKey, IEnumerable<OrderField> orderBy);

        /// <summary>
        /// Queries all entities in the repository.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> representing all entities.</returns>
        IEnumerable<T> QueryAll();

        /// <summary>
        /// Queries all entities in the repository with caching support.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="renewCache">Indicates whether to renew the cache.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> representing all entities.</returns>
        IEnumerable<T> QueryAll(string cacheKey, bool renewCache);

        /// <summary>
        /// Gets the maximum value of the specified field for the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="whereOrPrimaryKey">The criteria or primary key value.</param>
        /// <returns>The maximum value as a nullable TKey.</returns>
        TKey? Max(string tableName, string fieldName, object whereOrPrimaryKey);
    }
}
