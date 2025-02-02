﻿using System;
using Robust.Server.GameObjects;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Serialization;
using Robust.Shared.GameObjects;
using Content.Server.GameObjects.EntitySystems;
using Content.Shared.GameObjects.Components.Triggers;

namespace Content.Server.GameObjects.Components.Triggers
{
    public class OnUseTimerTriggerComponent : Component, IUse
    {
        #pragma warning disable 649
        [Dependency] private readonly IEntitySystemManager _entitySystemManager;
#pragma warning restore 649

        public override string Name => "OnUseTimerTrigger";

        private float _delay = 0f;

        public override void ExposeData(ObjectSerializer serializer)
        {
            base.ExposeData(serializer);

            serializer.DataField(ref _delay, "delay", 0f);
        }

        public override void Initialize()
        {
            base.Initialize(); 
        }

        bool IUse.UseEntity(UseEntityEventArgs eventArgs)
        {
            var triggerSystem = _entitySystemManager.GetEntitySystem<TriggerSystem>();
            if (Owner.TryGetComponent<AppearanceComponent>(out var appearance)) {
                appearance.SetData(TriggerVisuals.VisualState, TriggerVisualState.Primed);
            }
            triggerSystem.HandleTimerTrigger(TimeSpan.FromSeconds(_delay), eventArgs.User, Owner);
            return true;
        }
    }
}