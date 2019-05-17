using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogHolder : MonoBehaviour
{
    private Animator anim;
    [SerializeField] public ParticleSystem particles;

    private bool inside = false;

    void Start()
    {
        this.particles.Stop();
        this.anim = GetComponent<Animator>();
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (inside == false)
        {
            inside = true;
            ShowDialog(other.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
        FindObjectOfType<DialogManager>().Destroy();
    }

    public void ShowDialog(GameObject gameObject)
    {
        if (gameObject.tag.Equals("Player"))
        {
            DialogManager manager = FindObjectOfType<DialogManager>();

            manager.AddMessage("Hello. I see you are new in the craft.")
                   .AddMessage("This is a dangerous world. I will give you a shild to protext your self for 5 seconds.")
                   .AddMessage("Press ENTER to get the shild.", "Shield")
                   .OnReaded(MessageReaded)
                   .ShowBox();
        }
    }

    private object MessageReaded(int MessagesLeft)
    {
        if (MessagesLeft <= 0)
        {
            StartCoroutine(RunAnimationForSeconds(1f));
        }

        return null;
    }

    private IEnumerator RunAnimationForSeconds(float sec)
    {
        this.particles.Play();
        this.anim.SetBool("wand", true);

        yield return new WaitForSeconds(sec);

        this.particles.Stop();
        this.anim.SetBool("wand", false);

        List<GameObject> paths = new List<GameObject>(GameObject.FindGameObjectsWithTag("Path"));
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

        paths = paths.OrderBy(
            x => Vector2.Distance(door.transform.position, x.transform.position)
        ).Reverse().ToList();

        StartCoroutine(Move(paths, door, doors));

    }
    
    IEnumerator Move(List<GameObject> paths, GameObject door, GameObject[] doors)
    {
        bool startMove = false;
        float totalDist = Vector2.Distance(paths.Last().transform.position, this.gameObject.transform.position) * 1.5f;
        GameObject prev = null;
        GameObject next = null;

        int index = 0;
        int index2 = 0;

        foreach (GameObject obj in paths)
        {
            float distance = Vector2.Distance(obj.transform.position, this.gameObject.transform.position);

            if (index2++ % 2 == 0) continue;

            if (index <= paths.Count - 1)
            {
                next = paths[index + 1];
            }
            else
            {
                next = null;
            }

            if (distance < 1)
            {
                startMove = true;
            }

            if (startMove)
            {
                if (prev != null && (Vector2.Distance(prev.transform.position, door.transform.position) < Vector2.Distance(obj.transform.position, door.transform.position)))
                {
                    continue;
                }

                if (next != null && (Vector2.Distance(next.transform.position, door.transform.position) < Vector2.Distance(obj.transform.position, door.transform.position)))
                {
                    continue;
                }
                
                float step = totalDist * Time.deltaTime;
                
                if (Vector2.Distance(gameObject.transform.position, obj.transform.position) > 4f)
                {
                    continue;
                }

                this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, obj.transform.position, Time.deltaTime * totalDist);

                yield return new WaitForSeconds(0.3f);

                prev = obj;

            }

            index++;
        }

        foreach (var currDoor in doors)
        {
            currDoor.GetComponent<Renderer>().enabled = false;
        }

        yield return new WaitForSeconds(1f);

        this.gameObject.transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1f);

        foreach (var currDoor in doors)
        {
            currDoor.GetComponent<Renderer>().enabled = true;
        }

        Destroy(this.gameObject);
    }

    void Update()
    {
        
    }
}
