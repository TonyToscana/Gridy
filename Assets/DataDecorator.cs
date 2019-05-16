using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DataDecorator : IData
{
    protected IData comp;

    public DataDecorator(IData temp)
    {
        this.comp = temp;
    }

    public override string Load(string name)
    {
        return this.comp.Load(name);
    }

    public override string Save(string name, string value)
    {
        return this.comp.Save(name, value);
    }
}
