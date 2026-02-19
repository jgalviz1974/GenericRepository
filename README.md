# GenericRepository
GenericRepository define las interfaces necesarias para implementar el patrón Generic Repository

# El Patrón Generic Repository.
•	Que hace: Abstrae el acceso a datos detrás de interfaces (IReadGenericRepository, IReadGenericRepository<T,TKey>, IWriteGenericRepository).
•	Propósito: separar la lógica de acceso a datos de la lógica de negocio, facilitar pruebas y permitir intercambio de la tecnología de persistencia.
•	Beneficios: independencia de la DAL, facilidad para inyección de dependencias y pruebas unitarias.
