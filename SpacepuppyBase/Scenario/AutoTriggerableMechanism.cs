﻿using UnityEngine;

using com.spacepuppy.Utils;

namespace com.spacepuppy.Scenario
{
    public abstract class AutoTriggerableMechanism : TriggerableMechanism
    {
        
        #region Fields

        [SerializeField()]
        private ActivateEvent _activateOn = ActivateEvent.None;

        [System.NonSerialized]
        private bool _inDisable;

        #endregion

        #region CONSTRUCTOR

        protected override void Awake()
        {
            base.Awake();

            if((_activateOn & ActivateEvent.Awake) != 0)
            {
                this.Trigger(this, null);
            }
        }

        protected override void Start()
        {
            base.Start();

            if ((_activateOn & ActivateEvent.OnStart) != 0 || (_activateOn & ActivateEvent.OnEnable) != 0)
            {
                this.Trigger(this, null);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (!this.started) return;

            if ((_activateOn & ActivateEvent.OnEnable) != 0)
            {
                this.Trigger(this, null);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            if((_activateOn & ActivateEvent.OnDisable) != 0)
            {
                _inDisable = true;
                this.Trigger(this, null);
                _inDisable = false;
            }
        }

        #endregion

        #region Properties

        public ActivateEvent ActivateOn
        {
            get { return _activateOn; }
            set { _activateOn = value; }
        }

        public override bool CanTrigger
        {
            get
            {
                return _inDisable || base.CanTrigger;
            }
        }

        #endregion


    }
}
