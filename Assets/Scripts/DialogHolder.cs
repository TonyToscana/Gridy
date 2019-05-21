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
    private List<GameObject> pathToGo = new List<GameObject>();
    private bool moveRPC = false;

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

            manager.AddMessage("Hello. I see you are new in the craft..")
                   .AddMessage("This is a dangerous world. I will give you a shild to protext your self for 5 seconds..")
                   .AddMessage("Press [Q] to get the shild..")
                   .AddMessage("For every 100 calories that you consume the damage you receive is reduce by 10%..")
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

        moveRPC = true;
        bool startMove = false;
        float totalDist = Vector2.Distance(paths.Last().transform.position, this.gameObject.transform.position) * 1.5f;

        foreach (GameObject obj in paths)
        {
            float distance = Vector2.Distance(obj.transform.position, this.gameObject.transform.position);

            if (distance < 1)
            {
                startMove = true;
            }

            if (startMove)
            {
                this.pathToGo.Add(obj);
            }
        }

        queue = new Queue<GameObject>(this.pathToGo);
    }
    
    IEnumerator Move(GameObject[] doors)
    {
        Vector2 newPositionDoor = new Vector2(doors[0].transform.position.x - 5f, doors[0].transform.position.y);

        doors[0].transform.position =
            Vector3.Lerp(doors[0].transform.position, newPositionDoor, Time.deltaTime * 0.5f);

        newPositionDoor = new Vector2(doors[1].transform.position.x + 5f, doors[1].transform.position.y);

        doors[1].transform.position =
            Vector3.Lerp(doors[1].transform.position, newPositionDoor, Time.deltaTime * 5f);

        yield return new WaitForSeconds(1f);

        this.gameObject.transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1f);

        Vector2 newPositionDoorClose = new Vector2(doors[0].transform.position.x + 5f, doors[0].transform.position.y);

        doors[0].transform.position =
            Vector3.Lerp(doors[0].transform.position, newPositionDoorClose, Time.deltaTime * 0.5f);

        newPositionDoorClose = new Vector2(doors[1].transform.position.x - 5f, doors[1].transform.position.y);

        doors[1].transform.position =
            Vector3.Lerp(doors[1].transform.position, newPositionDoorClose, Time.deltaTime * 5f);


        Destroy(this.gameObject);
    }
    
    private readonly float speed = 6.0f;
    private Vector2 startPoint;
    private GameObject nextDestination = null;
    private Queue<GameObject> queue = new Queue<GameObject>();

    void Update()
    {
        if (moveRPC == false)
        {
            return;
        }
        else
        {
            startPoint = new Vector2(transform.position.x, transform.position.y);
        }

        if (this.queue.Count <= 0 && moveRPC)
        {
            moveRPC = false;
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

            transform.position = doors[0].transform.position;
            StartCoroutine(Move(doors));
        }


        // Distance moved = time * speed.
        float distCovered = Time.deltaTime * speed;

        if (nextDestination == null || Vector2.Distance(transform.position, nextDestination.transform.position) <= 2)
        {
            if (this.queue.Count > 0) nextDestination = queue.Dequeue();
            if (this.queue.Count > 0) nextDestination = queue.Dequeue();
            if (this.queue.Count > 0) nextDestination = queue.Dequeue();
        }

        transform.position = Vector3.MoveTowards(transform.position, nextDestination.transform.position, distCovered);
    }
}
