using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanges : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture, cursorTexture2;

    Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        cursorHotspot = new Vector2(cursorTexture2.width / 2, cursorTexture2.height / 2);
        Cursor.SetCursor(cursorTexture2, cursorHotspot, CursorMode.Auto);
    }
}
