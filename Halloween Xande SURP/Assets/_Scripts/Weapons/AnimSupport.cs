using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimSupport : MonoBehaviour
{

    public UnityEvent OnAnimatorEventTrigger;
    public void TriggerEvent()
    {
        OnAnimatorEventTrigger?.Invoke();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
