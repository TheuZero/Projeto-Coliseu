using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface HpNotifier
{   
    void AttachHpListeners(IHpListener listener);
    void DetachHpListeners(IHpListener listener);
    void NotifyOnHpChange(List<IHpListener> listener);
}
