using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIDistance : MonoBehaviour
{
    public float distance = 10f;

    private Character target;
    private AIPath aiPath;
    private Seeker seeker;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        seeker = this.GetComponent<Seeker>();
        target = FindObjectOfType<Character>();
        aiPath = this.GetComponent<AIPath>();
        this.GetComponent<AIDestinationSetter>().target = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(target.transform.position, this.transform.position);

        if (dist >= distance && aiPath.enabled)
        {
            aiPath.enabled = false;
        }
        else if (dist <= distance && !aiPath.enabled)
        {
            aiPath.enabled = true;
        }
    }
}
