using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SightLine : MonoBehaviour
{
    public Transform eyePoint;
    public string targetTag = "Player";
    public float fieldOfView = 45f;

    public bool isTargetInSightLine { get; set; } = false;
    public Vector3 lastKnownSighting { get; set; }
    private SphereCollider thisCollider;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        lastKnownSighting = transform.position;
        thisCollider = GetComponent<SphereCollider>();
    }

    private bool TargetInFOV(Transform target)
    {
        Vector3 directionToTarget = target.position - eyePoint.position;
        float angle = Vector3.Angle(directionToTarget, target.position);
        return angle <= fieldOfView;
    }

    private bool HasClearLOSToTarget(Transform target)
    {
        RaycastHit hit;
        Vector3 dirToTarget = (target.position - eyePoint.position).normalized;
        if(Physics.Raycast(eyePoint.position, dirToTarget, out hit, thisCollider.radius))
        {
            if (hit.transform.CompareTag(targetTag))
            {
                return true;
            }
        }
        return false;
    }

    private void UpdateSight(Transform target)
    {
        isTargetInSightLine = TargetInFOV(target) && HasClearLOSToTarget(target);
        if (isTargetInSightLine)
        {
            lastKnownSighting = target.position;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            UpdateSight(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isTargetInSightLine = false;
        }
    }
}
