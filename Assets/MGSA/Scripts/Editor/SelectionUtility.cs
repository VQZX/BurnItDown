using UnityEditor;
using UnityEngine;

public static class SelectionUtility
{   
    public static bool Selected(GameObject gameObject)
    {
        GameObject[] selection = Selection.gameObjects;
        foreach (GameObject current in selection)
        {
            if (current == gameObject)
            {
                return true;
            }
        }
        return false;
    }
    
    public static bool IsSelectedInEditor(this GameObject gameObject)
    {
        return Selected(gameObject);
    }
}