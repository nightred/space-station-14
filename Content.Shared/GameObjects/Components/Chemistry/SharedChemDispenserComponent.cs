using System;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization;
using Robust.Shared.GameObjects.Components.UserInterface;


namespace Content.Shared.GameObjects.Components.Chemistry
{
    public abstract class SharedChemDispenserComponent : Component
    {
        public sealed override string Name => "ChemDispenser";
    }

    [Serializable, NetSerializable]
    public sealed class ChemDispenserBoundInterfaceState : BoundUserInterfaceState
    {

        public ChemDispenserBoundInterfaceState() {
            var a = 1;
        }

    }

    [Serializable, NetSerializable]
    public sealed class ChemDispenserDispenseMessage : BoundUserInterfaceMessage
    {

    }

    [Serializable, NetSerializable]
    public enum ChemDispenserUiKey
    {
        Key,
    }
}
