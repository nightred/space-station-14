using Content.Shared.GameObjects.Components.Chemistry;
using Robust.Client.GameObjects.Components.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.GameObjects.Components.UserInterface;
using System;


namespace Content.Client.GameObjects.Components.Chemistry
{

    public class ChemDispenserBoundUserInterface : BoundUserInterface
    {
        private ChemDispenserWindow _window;

        protected override void Open()
        {
            base.Open();
            _window = new ChemDispenserWindow()
            {
                
            };
            _window.OnClose += Close;

        }

        public ChemDispenserBoundUserInterface(ClientUserInterfaceComponent owner, object uiKey) : base(owner, uiKey)
        {

        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);

            var castState = (ChemDispenserBoundInterfaceState)state;

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _window.Dispose();
            }
        }

        private class ChemDispenserWindow : SS14Window
        {

            public ChemDispenserWindow()
            {
                Title = "Chem Dispenser";
                var rows = new VBoxContainer("Rows");

                var header = new Label("header") { Text = "Chem Dispenser Madness" };
                rows.AddChild(header);

                Contents.AddChild(rows);

            }

        }

    }
}
