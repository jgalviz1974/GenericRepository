# GenericRepository
GenericRepository defines the interfaces necessary to implement the Generic Repository pattern.

# The Generic Repository Pattern:

• What it does: Abstracts data access behind interfaces (IReadGenericRepository, IReadGenericRepository<T,TKey>, IWriteGenericRepository).
• Purpose: Separates data access logic from business logic, facilitates testing, and enables the exchange of persistence technologies.
• Benefits: DAL independence, ease of dependency injection, and unit testing.
