using UnityEngine;

public class DragUI : MonoBehaviour
{
    public Transform pointer;

    [Header("Select to include in drag.")]
    public bool x;
    public bool y;
    public bool z;

    // Only moves along the axes that are checked/activated.
    // Essentially allows you to constrain movement.
    public void Drag() {
        float newX = x ? pointer.position.x : transform.position.x;
        float newY = y ? pointer.position.y : transform.position.y;
        float newZ = z ? pointer.position.z : transform.position.z;

        transform.position = new Vector3(newX, newY, newZ);
    }
    
}
