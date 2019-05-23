using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class GroundScroller : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 destinationPos;
    public float scrollSpeed;
}

class GroundScrollerClass : ComponentSystem
{
    struct Components
    {
        public GroundScroller ground;
        public Transform transform;
    }

    protected override void OnStartRunning()
    {
        foreach (var e in GetEntities<Components>())
        {
            e.ground.startPos = e.transform.position;
        }
    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<Components>())
        {
            e.transform.position = Vector3.MoveTowards(e.transform.position, e.ground.destinationPos, e.ground.scrollSpeed);
            if (Mathf.Approximately(Vector3.Distance(e.transform.position, e.ground.destinationPos), 0f))
                ResetPosition();
        }
    }

    void ResetPosition()
    {
        foreach (var e in GetEntities<Components>())
        {
            e.transform.position = e.ground.startPos;
        }
    }
}