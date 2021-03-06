using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounded : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;

    Transform groundedObject;
    Vector3? groundedObjectLastPosition;

    public bool IsGrounded { get; private set; }
    public Vector2 GroundedDirection { get; private set; }

    void Update()
    {
        foreach (var position in positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded)
                break;
        }

        StickToMovingObjects();
    }

    void StickToMovingObjects()
    {
        if (groundedObject != null)
        {
            if (groundedObjectLastPosition.HasValue && groundedObjectLastPosition.Value != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;
                transform.position += delta;
            }
            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, foot.forward, maxDistance, layerMask);
        Debug.DrawRay(foot.position, foot.forward * maxDistance, Color.red);
        if (raycastHit.collider != null)
        {
            if(groundedObject != raycastHit.collider.transform)
            { 
                groundedObjectLastPosition = raycastHit.collider.transform.position;
            }
            groundedObject = raycastHit.collider.transform;
            IsGrounded = true;
            GroundedDirection = foot.forward;
        }
        else
        {
            groundedObject = null; 
            IsGrounded = false;
        }
    }
}
