using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorTypeConverter
{
    public static string ToRGBHex(Color c)
    {
        return string.Format("#{0:X2}{1:X2}{2:X2}", ToByte(c.r), ToByte(c.g), ToByte(c.b));
    }

    private static byte ToByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }
}

public class LevelGenerator : MonoBehaviour
{

    public Map[] maps;
    //public ColorToPrefab[] prefab;

    private int overlay = 0;

    // Start is called before the first frame update
    void Start()
    {
        RenderLevel();
        AstarPath start = GetComponent<AstarPath>();
        if (start == null) Debug.LogError("astar is null");
        start?.Scan();
    }

    private void RenderLevel()
    {
        foreach (var map in maps)
        {
            for (int x = 0; x < map.map.width; x++)
            {
                for (int y = 0; y < map.map.height; y++)
                {
                    GenerateTile(map, x, y);
                }
            }

            overlay--;
        }
    }

    private void GenerateTile(Map map, int x, int y)
    {
        Color pixel = map.map.GetPixel(x, y);

        if (pixel.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab elem in map.prefab)
        {
            if (elem.color.Equals(pixel))
            {
                Vector3 position = new Vector3(x, y, overlay);

                if (elem.UseLayerZIndex)
                {
                    position = new Vector3(x, y, elem.LayerZIndex);
                }

                Instantiate(elem.prefab, position, Quaternion.identity, transform);
            }
            else
            {
                //Debug.Log("NO - " + ColorTypeConverter.ToRGBHex(elem.color) + " - " + ColorTypeConverter.ToRGBHex(pixel));
            }
        }
    }
}
