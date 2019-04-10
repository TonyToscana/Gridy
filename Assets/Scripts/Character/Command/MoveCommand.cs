using UnityEngine;

public class MoveCommand : ICommand
{
    public void Execute()
    {
        GameObject[] playerTag = GameObject.FindGameObjectsWithTag("Player");

        if (playerTag.Length != 1) return; 

        Character character = playerTag[0].GetComponent<Character>();

        Vector3 move = Vector3.zero;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        playerTag[0].transform.localPosition += move * character.speed * Time.deltaTime;
    }
}
