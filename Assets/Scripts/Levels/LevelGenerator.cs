using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public Texture2D map;
    public ColorToPrefab[] prefab;
    public string nextLevelScene;

    // Start is called before the first frame update
    void Start()
    {
        RenderLevel();
    }

    private void RenderLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixel = map.GetPixel(x, y);

        if (pixel.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab elem in this.prefab)
        {
            if (elem.color.Equals(pixel))
            {
                Vector3 position = new Vector3(x, y, 0);

                Instantiate(elem.prefab, position, Quaternion.identity, transform);
            } 
        }
    }
}
