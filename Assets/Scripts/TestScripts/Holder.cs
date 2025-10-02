using UnityEngine;

public class Holder : MonoBehaviour
{
    public enum HolderType { Number, Sign }
    public HolderType holderType; // ✅ set this in Inspector

    private GameObject currentObj;

    public bool CanAccept(NewDrag dragScript)
    {
        if (holderType == HolderType.Sign)
        {
            return (dragScript.NumberDef == '+' || dragScript.NumberDef == '-' || dragScript.NumberDef == 'x' || dragScript.NumberDef == '/');
        }
        else // Number Holder
        {
            return !(dragScript.NumberDef == '+' || dragScript.NumberDef == '-' || dragScript.NumberDef == 'x' || dragScript.NumberDef == '/');
        }
    }

    public void AcceptDrop(GameObject obj, NewDrag dragScript)
    {
        // Case 1: Slot empty
        if (currentObj == null)
        {
            PlaceObject(obj);
        }
        // Case 2: Already filled → swap
        else if (currentObj != obj)
        {
            currentObj.GetComponent<NewDrag>().returnToOriginalPlace();
            PlaceObject(obj);
        }
    }

    private void PlaceObject(GameObject obj)
    {
        currentObj = obj;
        obj.transform.position = transform.position;
        Debug.Log(obj.name + " placed in Holder (" + holderType + ")");
        NumberSounds.Instance.ButtonClickSound1();
    }
}
