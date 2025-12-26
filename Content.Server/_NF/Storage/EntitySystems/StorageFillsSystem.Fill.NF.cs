using Content.Shared.Storage;
using Content.Server.Storage.Components;
using Content.Server.Storage.Events;

namespace Content.Server.Storage;

/// <summary>
/// A stand-alone system intended to modularly sit atop the existing gun and weapon systems to create dynamic weapon rarities.
/// </summary>
public sealed partial class AddComponentToStorageFillsSystem : EntitySystem
{
    [Dependency] private readonly IEntityManager _entMan = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<AddComponentToStorageFillsComponent, StorageFilledEvent>(OnStorageFillSpawn);
    }


    private void OnStorageFillSpawn(Entity<AddComponentToStorageFillsComponent> ent, ref StorageFilledEvent args)
    {
        if (!TryComp(ent, out StorageComponent? storage))
            return;

        foreach (var item in storage.StoredItems)
        {
            _entMan.AddComponents(item.Key, ent.Comp.AddComponents, true);
        }
    }
}
