using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateFSM
{
    public abstract class StateFSM
    {
        public abstract void PlayerStateEnter();
        public abstract void PlayerStateUpdate();
        public abstract void PlayerStateExit();
    }
}
