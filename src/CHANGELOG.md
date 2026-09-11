# Changelog - Gasolutions.Core.GenericRepository
### Changed
- Started migrating the repository contracts to be database-provider agnostic.
- Replaced RepoDb- and SQL Server-specific types with neutral abstractions in the contracts project.
- Removed direct dependency on RepoDb and Microsoft.Data.SqlClient from the contracts project.

## [1.0.10.11]
### Changed
- Refactored repository contracts to be database-provider agnostic.
- Replaced RepoDb- and SQL Server-specific types with neutral abstractions.
- Removed direct dependency on RepoDb and Microsoft.Data.SqlClient from the contracts project.

## [1.0.10.10]
### Changed
- Updated RepoDb.SlServer package to version 1.16.0

## [1.0.10.9]
### Changed
- Added transaction-enabled overloads to `IWriteGenericRepository` for batch write operations (`InsertAll`, `MergeAll`, `DeleteAll`, and `UpdateAll`).
- Added transaction-enabled overloads to `IWriteGenericRepository` for `Merge` with qualifiers and for command/query execution methods (`ExecuteScalar`, `ExecuteReader`, and `ExecuteQuery`).
- Added transaction-enabled overloads to `IReadGenericRepository` for `QueryAndReturnJson`, `ExecuteScalar<T>`, and `Max`.
- Added transaction-enabled overloads to `IReadGenericRepository<T, TKey>` for `Count`, `Query`, `QueryAll`, and `Max`.

## [1.0.10.8]
### Changed
-- Updated `Max` method in `IReadGenericRepositoryT` interface to return nullable `TKey` with transaction mode, enhancing the method's flexibility and allowing for better handling of scenarios where a maximum value may not exist or when transactions are involved, thus improving the robustness and reliability of data retrieval operations in applications using this repository.

## [1.0.10.7]
### Changed
- Added `Max` method in `IReadGenericRepositoryT` interface to return nullable `TKey` without transaction mode.

## [1.0.10.6]
### Changed
- Bug correction in ExecuteScalar method of `IGenericRepository` interface to ensure proper handling of null values and exceptions, improving the robustness and reliability of scalar query executions in applications using this repository.

## [1.0.10.5]
### Changed
- Addded transaction support to ExecuteScalar method in `IGenericRepository` interface, allowing for better control over database operations and ensuring data integrity during complex transactions. This enhancement enables developers to execute scalar queries within a transactional context, providing the ability to commit or roll back changes based on the success or failure of the operations, thus improving the robustness and reliability of data interactions in applications using this repository.

## [1.0.10.4]
### Added
- Add ExecuteScalar method to `IGenericRepository` interface for executing scalar queries.
- 
## [1.0.10.3]
### Changed
- Deleted entity field from Max method.

## [1.0.10.2]
### Changed
- Changed ´Max´ method adding field name and additional criteria, removing previous versions. 

## [1.0.10.1]
### Changed
- Changed the return type of Max methods to support nullable values.

## [1.0.10.0]
### Added
- Added 'Max' method to `IGenericRepository` interface for retrieving the maximum value of a specified column in a table, enhancing data analysis capabilities.

## [1.0.9.6]
### Added
- Added Delete method with transaction support to `IGenericRepository` interface for enhanced data integrity during delete operations.

## [1.0.9.4] 
### Fixed
- Count methods now return long type to accommodate large record counts and prevent overflow issues

## [1.0.9.3]
### Added
- Add Count methods to `IGenericRepository` interface for counting records in a table.
- 
## [1.0.9.0]
### Changed
- Add BulkInsert method to `IGenericRepository` interface for efficient batch operations

## [1.0.8.1]
### Changed
- Implementations were moved to a separate project `Gasolutions.Core.GenericRepository.RepoDB` to improve modularity and maintainability
- Changed name from `Gasolutions.Core.Repository` to `Gasolutions.Core.GenericRepository`
 
## [1.0.7]

### Added
- Comprehensive XML documentation for all repository interfaces and implementations
- Async operation support with `QueryAsync()` method
- Enhanced factory pattern interfaces for repository creation
- Complete test suite with 36+ test cases
- Support for cancellation tokens in async operations
- Configuration interfaces for advanced repository patterns
- RepoDB initialization in test suite

### Changed
- Updated LangVersion to 13.0
- Updated Description to English for international audience
- Improved error handling in repository implementations
- Enhanced nullability annotations for better type safety
- Refactored copyright headers to English

### Fixed
- Repository initialization with RepoDB
- Connection string validation
- Null parameter handling in repository methods

### Documentation
- Added comprehensive API documentation
- Created test suite documentation (README.md)
- Improved inline code comments in English

---

## [1.0.6] 

### Initial Release
- Generic repository interface `IReadGenericRepository<T>`
- RepoDB implementation for SQL Server
- Basic read operations with JSON return types
- Write operations (insert, update, delete)
- Connection string management
