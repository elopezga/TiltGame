using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltGame.GameplayServices
{
    public class GameplayHoleService : MonoBehaviour
    {
        [SerializeField]
        private string _platformFloorTag;
        [SerializeField]
        private FallThroughTrigger _fallThroughTrigger;
        private MeshCollider _platformFloorCollider;

        private void Awake()
        {
            GameObject platformFloor = GameObject.FindGameObjectWithTag(_platformFloorTag);
            _platformFloorCollider = platformFloor.GetComponent<MeshCollider>();
        }

        private void OnEnable()
        {
            _fallThroughTrigger.TriggerEnter += CauseFallThroughPlatform;
        }

        private void OnDisable()
        {
            _fallThroughTrigger.TriggerEnter -= CauseFallThroughPlatform;
        }

        private void CauseFallThroughPlatform(Collider otherCollider)
        {
            Physics.IgnoreCollision(otherCollider, _platformFloorCollider, true);
            Debug.LogError(string.Format("Ignore collisions between {0} and {1}", otherCollider.name, _platformFloorCollider.name));
        }
    }
}