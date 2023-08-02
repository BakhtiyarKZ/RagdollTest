using UnityEngine;
using RootMotion.Dynamics;

public class Shooter : MonoBehaviour
    {

        [SerializeField] private LayerMask _layers;
        [SerializeField] private float _unpin;
        [SerializeField] private float _force;
        [SerializeField] private float bodyForceMultiplayer;

        [SerializeField] GameObject spine;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
            
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 100f, _layers))
                {                
                    var parentBroadcaster = spine.GetComponentInParent<MuscleCollisionBroadcaster>();
                    var broadcaster = hit.collider.attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();

                    if (broadcaster != null)
                    {
                        parentBroadcaster.Hit(_unpin, ray.direction * _force * bodyForceMultiplayer, hit.point);
                        broadcaster.Hit(_unpin, ray.direction * _force, hit.point);
                    }
                }
            }
        }
    }

