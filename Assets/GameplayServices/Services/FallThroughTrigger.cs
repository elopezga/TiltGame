using System;
using UnityEngine;

public class FallThroughTrigger : MonoBehaviour
{
    public event Action<Collider> TriggerEnter;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (TriggerEnter != null)
        {
            TriggerEnter.Invoke(otherCollider);
        }
    }
}
