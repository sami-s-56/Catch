using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State _curState;

    //Property for state changing 
    public State _CurState
    {
        get => _curState;   //Syntax for return
        set
        {
            if(_curState != null)
                _curState.OnExit();

            _curState = value;
            
            if (_curState != null)
                _curState.OnEnter();
        }
    }


}
