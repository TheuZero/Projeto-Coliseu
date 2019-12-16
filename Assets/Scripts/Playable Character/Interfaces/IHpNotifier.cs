using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHpNotifier
{   
    void AttachHpListeners(IHpListener listener);
    void DetachHpListeners(List<IHpListener> listener);
    void NotifyOnHpChange(List<IHpListener> listener, int playerNumber);
}
