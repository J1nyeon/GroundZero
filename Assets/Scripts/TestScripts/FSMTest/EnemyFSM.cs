using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public BaseState state;

    void Start()
    {
        
        if (state != null)
        {
            state.Enter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
