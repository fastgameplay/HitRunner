using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBased : MonoBehaviour
{
    protected Player player;
    
    protected virtual void Awake(){
        player = transform.root.GetComponent<Player>();
    }
}
