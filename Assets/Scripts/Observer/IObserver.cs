using System;
using System.Collections.Generic;
using System.Threading;

public interface IObserver
{
    // Receive update from subject
    void Update(ISubject subject);
}