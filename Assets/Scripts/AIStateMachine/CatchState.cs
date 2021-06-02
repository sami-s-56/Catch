using System;
using UnityEngine;

public class CatchState : State
{
    CharacterMotor _charMotor;
    CatchParticipant catchParticipant;
    CatchParticipant[] participants;

    public CatchState(GameObject go, StateMachine sm) : base(go, sm)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        _charMotor = _go.GetComponent<CharacterMotor>();
        catchParticipant = _go.GetComponent<CatchParticipant>();
        participants = GameObject.FindObjectsOfType<CatchParticipant>();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        Vector3 closestRunnerPos = GetClosestParticipant();
        Vector3 preyDirection = (closestRunnerPos - _go.transform.position).normalized;
        _charMotor._moveDir = preyDirection;

        if (catchParticipant._catchRole != CatchParticipant.CatchRole.Catcher)
        {
            int rand = UnityEngine.Random.Range(0, 2);
            if(rand == 0)
                _sm._CurState = new FleeState(_go, _sm);
            else
                _sm._CurState = new AgressiveFleeState(_go, _sm);
        }
    }

    private Vector3 GetClosestParticipant()
    {
        CatchParticipant participantx = null;
        float dis = 999999f;
        foreach (CatchParticipant participant in participants)
        {
            if(Vector3.Distance(_go.transform.position, participant.transform.position) < dis && participant._catchRole != CatchParticipant.CatchRole.Catcher)
            {
                dis = Vector3.Distance(_go.transform.position, participant.transform.position);
                participantx = participant;
            }
        }
        Debug.Log(participantx.name);
        return participantx.transform.position;
    }
}
