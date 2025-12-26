using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Server.Storage.Components;

/// <summary>
/// This is used to temporarily prevent an entity from moving or acting.
/// </summary>
[RegisterComponent]
public sealed partial class AddComponentToStorageFillsComponent : Component
{
    /// <summary>
    /// Components to be added to any spawned grids.
    /// </summary>
    [DataField]
    [AlwaysPushInheritance]
    public ComponentRegistry AddComponents { get; set; } = new();
}
