namespace Gasolutions.Core.Repository.Interfaces
{
    public sealed class BulkInsertOptions
    {
        public string? Hints { get; init; }

        public int? BatchSize { get; init; }

        public bool ReturnIdentity { get; init; }

        public bool UsePhysicalPseudoTempTable { get; init; }
    }
}
