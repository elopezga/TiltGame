using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TiltGame.GameplayServices
{
    public class CountdownPresenter : MonoBehaviour
    {
        [SerializeField]
        private int _countdownDuration = 3;
        [SerializeField]
        private string _countdownMessage = string.Empty; // What displays after countdown finishes. This is optional

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

