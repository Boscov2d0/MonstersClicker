using System;
using UnityEngine;

namespace MainMenu
{
    public class AnimationEvent : MonoBehaviour
    {
        public Action _eventWaitingContent = delegate () { };
        public Action _eventHellowContent = delegate () { };
        public Action _eventPreStartContent = delegate () { };
        public void WaitingContentFinishEvent()
        {
            _eventWaitingContent?.Invoke();
        }
        public void HellowContentFinishEvent()
        {
            _eventHellowContent?.Invoke();
        }
        public void PreStartContentFinishEvent()
        {
            _eventPreStartContent?.Invoke();
        }
    }
}
