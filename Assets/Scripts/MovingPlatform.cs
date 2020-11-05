using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform Pos1, Pos2;
    public float speed;
    public Transform startpos;
    Vector3 nextpos;
    // Start is called before the first frame update
    void Start()
    {
        nextpos = startpos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position==Pos1.position)
        {
            nextpos = Pos2.position;
        }
        if (transform.position == Pos2.position)
        {
            nextpos = Pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextpos, speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Pos1.position, Pos2.position);
    }
}
