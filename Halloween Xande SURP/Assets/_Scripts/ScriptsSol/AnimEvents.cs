using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{

    public void EndAnim()
    {
        gameObject.SetActive(false);
    }

}
