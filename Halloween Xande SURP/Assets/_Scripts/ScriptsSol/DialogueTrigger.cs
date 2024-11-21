using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject InteractWithE;
    public UnityEvent startnextSentence;

    public UnityEvent OnDialogueFinish;


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            TriggerDialogue();
            InteractWithE.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D()
    {
        InteractWithE.SetActive(false);
    }
    public void TriggerDialogue()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this);
        }
    }
}
