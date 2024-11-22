using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossesDie : MonoBehaviour
{
   public void OnDestroy()
   {
    EndGame.Instance.BossesLeft--;
   }
}
