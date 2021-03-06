﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

using com.spacepuppy.Utils;

namespace com.spacepuppy.AI.Sensors.Collision
{

    [RequireComponent(typeof(Collider))]
    public class ColliderAspect : SPEntityComponent, IAspect
    {

        #region Fields

        private Collider _collider;

        #endregion

        #region CONSTRUCTOR

        protected override void Awake()
        {
            base.Awake();

            _collider = this.GetComponent<Collider>();
        }

        #endregion

        #region Properties

        public Collider Collider
        {
            get { return _collider; }
        }

        #endregion

        #region IAspect Interface

        bool IAspect.IsActive
        {
            get { return _collider.IsActiveAndEnabled(); }
        }

        public float Precedence
        {
            get { return 0f; }
        }

        bool IAspect.OmniPresent
        {
            get { return false; }
        }

        #endregion

        #region Static Interface

        public static ColliderAspect GetAspect(Collider coll)
        {
            if (coll == null) return null;

            return coll.AddOrGetComponent<ColliderAspect>();
        }

        #endregion

    }

}
