using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveFleeState : FleeState
{
    public AgressiveFleeState(GameObject go, StateMachine sm) : base(go, sm)
    {
    }

    public override void  OnFixedUpdate()
    {
        Vector3 fleeDirection = (_go.transform.position - CatchParticipant._catcher.transform.position).normalized;
        
        Vector3 agressiveFleeDir = CatchParticipant._catcher.transform.position + fleeDirection * 5f;

        _charMotor._moveDir = (agressiveFleeDir - _go.transform.position);

        if (catchParticipant._catchRole == CatchParticipant.CatchRole.Catcher)
            _sm._CurState = new CatchState(_go, _sm);
    }
}
