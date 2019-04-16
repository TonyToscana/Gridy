using UnityEngine;

public class MoveCommand : ICommand
{
    public Vector2 GetDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return Vector2.down;
        }

        return Vector2.zero;
    }

    public void Execute()
    {
        GameObject[] playerTag = GameObject.FindGameObjectsWithTag("Player");

        if (playerTag.Length != 1) return; 

        Character character = playerTag[0].GetComponent<Character>();

        Vector3 move = Vector3.zero;
       
        if (character.LastDirectionKey == KeyCode.LeftArrow || character.LastDirectionKey == KeyCode.RightArrow ||
            character.LastDirectionKey == KeyCode.A || character.LastDirectionKey == KeyCode.D )
        {
            Points.GetInstance().Add(1);

            move.x = Input.GetAxis("Horizontal");
        }

        if (character.LastDirectionKey == KeyCode.UpArrow || character.LastDirectionKey == KeyCode.DownArrow ||
            character.LastDirectionKey == KeyCode.W || character.LastDirectionKey == KeyCode.S)
        {
            Points.GetInstance().Sub(1);

            move.y = Input.GetAxis("Vertical");
        }

        if (character.PrevDirectionKey != character.LastDirectionKey)
        {
            if (character.LastDirectionKey == KeyCode.LeftArrow || character.LastDirectionKey == KeyCode.RightArrow ||
                   character.LastDirectionKey == KeyCode.A || character.LastDirectionKey == KeyCode.D)
            {
                if ((character.LastDirectionKey == KeyCode.LeftArrow || character.LastDirectionKey == KeyCode.A) && playerTag[0].transform.localScale.x > 0)
                {
                    playerTag[0].transform.localScale = Vector3.Scale(playerTag[0].transform.localScale, new Vector3(-1, 1, 1));
                }

                if ((character.LastDirectionKey == KeyCode.RightArrow || character.LastDirectionKey == KeyCode.D) && playerTag[0].transform.localScale.x < 0)
                {
                    playerTag[0].transform.localScale = Vector3.Scale(playerTag[0].transform.localScale, new Vector3(-1, 1, 1));
                }
            } 
        }

        playerTag[0].transform.localPosition += move * character.speed * Time.deltaTime;
    }
}
