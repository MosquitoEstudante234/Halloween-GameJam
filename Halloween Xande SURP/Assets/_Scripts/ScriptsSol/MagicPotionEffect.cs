using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class MagicPotionEffect : MonoBehaviour
{

    public PostProcessVolume mainEffect;       // Efeito principal
    public PostProcessVolume teleportEffect;   // Efeito de transição
    public float transitionSpeed = 1f;         // Velocidade da transição
    // Start is called before the first frame update
    public IEnumerator MagicPotion()
    {
        while (mainEffect.weight > 0 || teleportEffect.weight < 1)
        {
            mainEffect.weight = Mathf.Max(0, mainEffect.weight - Time.deltaTime * transitionSpeed);
            teleportEffect.weight = Mathf.Min(1, teleportEffect.weight + Time.deltaTime * transitionSpeed);

            yield return null;
        }
        yield return new WaitForSeconds(10);
        StartCoroutine(Return());
    }

    public void EffectAtivation() 
    {
        StartCoroutine(MagicPotion());
    }

    public IEnumerator Return()
    {
        while (mainEffect.weight < 1 || teleportEffect.weight > 0)
        {
            mainEffect.weight = Mathf.Min(1, mainEffect.weight + Time.deltaTime * transitionSpeed);
            teleportEffect.weight = Mathf.Max(0, teleportEffect.weight - Time.deltaTime * transitionSpeed);

            yield return null;
        }
    }
}
