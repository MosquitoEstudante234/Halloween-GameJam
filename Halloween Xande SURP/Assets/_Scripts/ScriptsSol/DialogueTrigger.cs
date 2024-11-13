using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent startnextSentence;

    public UnityEvent OnDialogueFinish;

    private void OnMouseOver()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this);
        }
    }
}
