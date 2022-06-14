using System;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] private List<Behaviour> behavioursToDisableIfNotOwner;

    private void Awake()
    {
        foreach (Behaviour behaviour in behavioursToDisableIfNotOwner)
        {
            behaviour.enabled = false;
        }
    }
}
