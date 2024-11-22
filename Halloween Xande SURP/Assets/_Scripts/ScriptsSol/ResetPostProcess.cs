using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

public class ResetPostProcess : MonoBehaviour
{
    public UnityEvent OnFixPostProcess;
    public void ResetPostProccesWeight(PostProcessVolume postProcess)
    {
        postProcess.weight = 0;
    }
    public void SetPostProccesWeight(PostProcessVolume postProcess)
    {
        postProcess.weight = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnFixPostProcess.Invoke();
        }
    }
}
