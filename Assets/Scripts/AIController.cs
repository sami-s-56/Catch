using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private StateMachine stateMachine;
    private CatchParticipant catchParticipant;

    private void Awake()
    {
        catchParticipant = GetComponent<CatchParticipant>();
        stateMachine = new StateMachine();
        stateMachine._CurState = new AgressiveFleeState(gameObject, stateMachine);
    }

    private void Start()
    {
    }

    private void Update()
    {
        stateMachine._CurState.OnUpdate();
    }

    void FixedUpdate()
    {
        stateMachine._CurState.OnFixedUpdate();
    }
}
