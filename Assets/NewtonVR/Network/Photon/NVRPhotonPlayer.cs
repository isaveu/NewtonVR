﻿using UnityEngine;
using System.Collections;
using NewtonVR;
using System;
using NewtonVR.Network;

namespace NewtonVR.NetworkPhoton
{
    public class NVRPhotonPlayer : NVRNetworkPlayer
    {
        private PhotonView pvCache = null;
        public PhotonView photonView
        {
            get
            {
                if (pvCache == null)
                {
                    pvCache = PhotonView.Get(this);
                }
                return pvCache;
            }
        }

        public override bool IsMine()
        {
            return this.photonView.isMine;
        }

        protected override void Awake()
        {
            base.Awake();

            if (IsMine() == false)
            {
                Destroy(gameObject.GetComponentInChildren<AudioListener>());
            }
        }
    }
}