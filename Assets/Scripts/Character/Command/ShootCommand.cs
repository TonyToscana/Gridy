using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : MonoBehaviour, ICommand
{
    private Shooter shooter;

    public void Execute(GameObject obj)
    {
        this.shooter = obj.GetComponent<Shooter>();
        Character character = obj.GetComponent<Character>();

        if (shooter.used) return;

        GameObject missile = Instantiate(this.shooter.MissilePrefab, this.shooter.InitPosition.transform.position, Quaternion.identity);
        missile.transform.parent = null;

        Vector2 dir = (character.isFacingLeft) ? Vector2.left : Vector2.right;
        missile.GetComponent<Rigidbody2D>().AddForce(dir * 1000 );

        shooter.used = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
