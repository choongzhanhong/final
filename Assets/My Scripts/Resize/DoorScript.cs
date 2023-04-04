using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    private bool isAnimationEnabled = false;
    public AudioClip doorOpenSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        animator.enabled = false;
    }

    private void Update()
    {
        if (isAnimationEnabled)
        {
            animator.enabled = true;
        }
        else
        {
            animator.enabled = false;
        }
    }
    
    public void PlayAnimation()
    {
        if (isAnimationEnabled == false)
        {
            AudioSource.PlayClipAtPoint(doorOpenSound, this.transform.position);
        }
        isAnimationEnabled = true;
    }
}
