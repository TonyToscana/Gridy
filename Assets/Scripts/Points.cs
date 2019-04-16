using UnityEngine;

public class Points
{
    private static Points instance = null;
    private int _points = 0;

    private Points() { }

    public int Number
    {
        get
        {
            return _points;
        }

        private set
        {
            _points = value;
        }
    }

    public void Add(int p)
    {
        Number += p;
    }

    public void Sub(int p)
    {
        Number -= p;
    }

    public void Zero()
    {
        Number = 0;
    }

    public void Set(int p)
    {
        Number = p;
    }

    public static Points GetInstance()
    {
        if (instance == null)
        {
            instance = new Points();
        }

        return instance;
    }
}
