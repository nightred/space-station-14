using System;
using Content.Server.GameObjects.EntitySystems;
using Content.Shared.GameObjects.Components.Chemistry;
using Robust.Server.GameObjects.Components.UserInterface;
using Robust.Server.Interfaces.GameObjects;
using Robust.Shared.GameObjects.Components.UserInterface;

namespace Content.Server.GameObjects.Components.Chemistry
{
    class ChemDispenserComponent : SharedChemDispenserComponent, IActivate
    {

        private BoundUserInterface _userInterface;
        private bool _uiDirty = true;

        public override void Initialize()
        {
            base.Initialize();
            _userInterface = Owner.GetComponent<ServerUserInterfaceComponent>().GetBoundUserInterface(ChemDispenserUiKey.Key);
            _userInterface.OnReceiveMessage += UserInterfaceOnReciveMessage;

        }

        private void UserInterfaceOnReciveMessage(BoundUserInterfaceMessage obj)
        {
            if (obj is ChemDispenserDispenseMessage)
            {
                _uiDirty = true;
            }
        }

        public void OnUpdate()
        {
            if (_uiDirty)
            {
                _userInterface.SetState(new ChemDispenserBoundInterfaceState());
                _uiDirty = false;
            }
        }

        void IActivate.Activate(ActivateEventArgs eventArgs)
        {
            if (!eventArgs.User.TryGetComponent(out IActorComponent actor))
            {
                return;
            }

            _userInterface.Open(actor.playerSession);
        }
    }
}
