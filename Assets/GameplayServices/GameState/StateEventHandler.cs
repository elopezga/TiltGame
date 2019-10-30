using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    public class StateEventHandler : MonoBehaviour
    {
        private StateEventListeners _listeners = new StateEventListeners();
        private Dictionary<Type, StateEventListeners> _allStateListeners = new Dictionary<Type, StateEventListeners>
        {
            {typeof(State_WaitForStart), new StateEventListeners()}
        };

        public StateEventHandler()
        {
            
        }

        public StateEventListeners OnStateEnter<T>()
        {
            return _allStateListeners[typeof(T)]; // Maybe you can use the state enum here?
        }

        public class StateEventListeners
        {
            private List<Action> _listeners = new List<Action>();

            public void AddListener(Action handler)
            {
                _listeners.Add(handler);
            }

            public void RemoveListener(Action handler)
            {
                _listeners.Remove(handler); // Will this work? Please confirm.
            }
        }
    }
}