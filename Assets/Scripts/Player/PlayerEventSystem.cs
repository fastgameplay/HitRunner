using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct PlayerEventSystem
{
    /*Input Handler*/
    public Action OnTap;
    public Action<Vector3> OnTapPosition;
    
    /*Player Behaviour Actions*/
    public Action OnDestinationReached;
    public Action FinishOnDestinationReach;
    public Action<Vector3> OnMovement;
    public Action<Vector3> OnAim;
    public Action OnShoot;
        
}
