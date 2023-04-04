using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorOpenScript : MonoBehaviour
{
    public DoorScript dooropen;

    private Button button;

    private void Start()
    {
        // Get the button component attached to this object
        button = GetComponent<Button>();

        // Attach the PlayAnimation() method to the button's onClick event
        button.onClick.AddListener(dooropen.PlayAnimation);
    }
}
