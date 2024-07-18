using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorAttack;
    [SerializeField] private bool isNormalCursor;

    private Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        if(isNormalCursor)
        {
            cursorHotspot = new Vector2(10, 10);
            Cursor.SetCursor(cursorNormal, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            cursorHotspot = new Vector2(10, 10);
            Cursor.SetCursor(cursorAttack, cursorHotspot, CursorMode.Auto);
        }
    }

    public void SetCurSorNormal()
    {
        cursorHotspot = new Vector2(10, 10);
        Cursor.SetCursor(cursorNormal, cursorHotspot, CursorMode.Auto);
    }
    
    public void SetCursorAttack()
    {
        cursorHotspot = new Vector2(10, 10);
        Cursor.SetCursor(cursorAttack, cursorHotspot, CursorMode.Auto);
    }
}
