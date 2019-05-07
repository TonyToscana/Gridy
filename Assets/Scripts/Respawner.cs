using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private static Respawner instance = null; 
    private Respawner()
    {
        elems = new Queue<SpawnElement>();
    }

    class SpawnElement
    {
        public GameObject obj;
        public Vector3 transform;
        public float time;

        public SpawnElement(GameObject o, Vector3 trans, float time)
        {
            this.time = time;
            this.obj = o;
            this.transform = trans;
        }
    }

    private Queue<SpawnElement> elems;

    public void Spawn(GameObject gameObject, Vector3 transform,float time)
    {
        this.elems.Enqueue(new SpawnElement(gameObject, transform, time));
        StartCoroutine(GetInstance().SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        SpawnElement el = elems.Dequeue();

        yield return new WaitForSeconds(el.time);

        if (el.obj != null)
        {
            Instantiate(el.obj, transform);
        }
    }

    public static Respawner GetInstance()
    {
        if (instance == null)
        {
            instance = new Respawner();
            GameObject go = new GameObject();
            instance = go.AddComponent<Respawner>();
            go.name = "Respawner";
        }

        return instance;
    }
}
