using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class AlienEnemyAI : MonoBehaviour
{
    #region properties
    public int layerMask = 8;

    public float stopDistance = 1f;
    public float senseDistance = 1f;

    public Transform target;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 10f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    private bool searchingForPlayer = false;
    #endregion

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            //Debug.Log("No Player Found? PANIC!");
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    private void OnPathComplete(Path p)
    {
        //Debug.Log("We got a Path. Did it have an error?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    IEnumerator SearchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if(sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        } else
        {
            target = sResult.transform;

            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
            yield break;
            
        }
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            //Debug.Log("No Player Found? PANIC!");
            yield break;
        }

        bool raycast = Physics2D.Raycast(this.transform.position, target.position - this.transform.position, Vector3.Distance(target.position, this.transform.position), 1 << layerMask).collider != null;
        bool distance = Vector3.Distance(target.position, this.transform.position) > senseDistance;

        distance = distance || Vector3.Distance(target.position, this.transform.position) <= stopDistance;

        if (distance || raycast)
        {
            seeker.CancelCurrentPathRequest();
      
            if (!searchingForPlayer)
            {
                target = null;
                searchingForPlayer = true;
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(SearchForPlayer());
            }
            yield break;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds( 1/updateRate );
        StartCoroutine(UpdatePath());
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            //Debug.Log("No Player Found? PANIC!");
            return;
        }

        //TODO: always look at player

        if (path == null)
        {
            return;
        }

        if(currentWaypoint >=path.vectorPath.Count)
        {
            if (pathIsEnded) return;

            //Debug.Log("End of path reached!");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        //playerTag[0].transform.localPosition += move * character.speed * Time.deltaTime;
        //this.transform.localPosition += dir * speed * Time.fixedDeltaTime;
        //rb.AddForce(dir, fMode);
        transform.position += dir;
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
