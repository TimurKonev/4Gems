using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform sprite;
    [SerializeField] float speed = 5;
    
    float positionPercent;
    int direction = 1;

    void Update()
    {
        float distance = Vector3.Distance(start.position, end.position);
        float speedDistance = speed / distance;
        positionPercent += Time.deltaTime * direction * speedDistance;
        sprite.position = Vector3.Lerp(start.position, end.position, positionPercent);

        if(positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            direction = 1;
        }
    }
}
