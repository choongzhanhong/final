using UnityEngine;
using UnityEngine.Events;

// Careful about the capitalisation: VRUIOperations
public class VRUIOperations : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private void OnTriggerEnter(Collider other) { 
        TrigExit.instance.currentCollider = GetComponent<VRUIOperations>();
        OnEnter.Invoke();
    }
}
