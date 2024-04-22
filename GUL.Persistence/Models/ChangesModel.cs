using Microsoft.EntityFrameworkCore;

namespace GUL.Persistence.Models;

public record ChangesModel(
    string EntityName,
    string EntityId,
    EntityState EntityState,
    List<ChangesNewAndOld> Changes
);

public record ChangesNewAndOld(string FieldName, object? OldValue, object? NewValue);
