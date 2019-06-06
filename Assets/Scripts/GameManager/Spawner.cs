using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public SpawnObject[] SpawnObj;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in SpawnObj)
        {
            obj.lastSpawn = Time.time + obj.spawnCooldown;
        }
    }

    public bool debug = false;

    // Update is called once per frame
    void Update()
    {/*
        if (!debug)
        {
            GameObject[] grassObjs = GameObject.FindGameObjectsWithTag("grass");

            foreach (var grass in grassObjs)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(grass.gameObject.transform.position.x, grass.gameObject.transform.position.y), 1.5f);

                if (colliders.Length <= 1)
                {
                    Instantiate(SpawnObj[0].spawnPrefab, grass.gameObject.transform.position, Quaternion.identity);
                }
            }


            debug = true;
        }
        */
        foreach (var obj in SpawnObj)
        {
            if ((obj.maxSpawns > obj.currentSpawns || obj.maxSpawns == -1) && Time.time > obj.lastSpawn)
            {
                spawnObject(obj.spawnPrefab);
                Debug.Log("--->>> " + obj.currentSpawns + " = " + obj.spawnPrefab.name);
                obj.currentSpawns++;
                obj.lastSpawn = Time.time + obj.spawnCooldown;
            }
        }
    }

    private void spawnObject(GameObject obj)
    {
        GameObject[] grassObjs = GameObject.FindGameObjectsWithTag("grass");
        List<GameObject> possibleLocations = new List<GameObject>();

        foreach (var grass in grassObjs)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(grass.gameObject.transform.position.x, grass.gameObject.transform.position.y), 1.5f);

            if (colliders.Length <= 1)
            {
                possibleLocations.Add(grass);
            }
        }

        Vector3 dir = possibleLocations[Random.Range(0, possibleLocations.Count)].gameObject.transform.position;
        dir.z = -6;

        Instantiate(obj, dir, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        /*GameObject[] grassObjs = GameObject.FindGameObjectsWithTag("grass");
        Debug.Log("!@3123 - " + grassObjs.Length);
         
        foreach (var grass in grassObjs)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(grass.transform.position, 0.5f);
        }*/
    }
}

[System.Serializable]
public class SpawnObject
{
    [SerializeField] public GameObject spawnPrefab;
    [SerializeField] public float spawnCooldown = 2.0f;

    [SerializeField]
    [Tooltip("-1 for no limits.")]
    public float maxSpawns = -1;
    

    [HideInInspector] public float currentSpawns = 0;
    [HideInInspector] public float lastSpawn;
}
