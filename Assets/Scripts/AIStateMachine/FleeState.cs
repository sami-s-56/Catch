using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{
    protected CharacterMotor _charMotor;
    protected CatchParticipant catchParticipant;
    public FleeState(GameObject go, StateMachine sm) : base(go, sm)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();

        _charMotor = _go.GetComponent<CharacterMotor>();
        catchParticipant = _go.GetComponent<CatchParticipant>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        Vector3 fleeDirection = (_go.transform.position - CatchParticipant._catcher.transform.position).normalized;
        _charMotor._moveDir = fleeDirection;

        if (catchParticipant._catchRole == CatchParticipant.CatchRole.Catcher)
            _sm._CurState = new CatchState(_go, _sm);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
