using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WhiteboardMarker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int penSize = 5;
    private Renderer renderer;
    private Color[] colors;
    private float tipHeight;
    private RaycastHit touch;
    private Whiteboard whiteboard;
    private Vector2 touchPos;
    private bool touchedLastFrame;
    private Vector2 lastTouchPos;
    private Quaternion lastTouchRot;
    //public DistanceGrabbable otherScript;

    void Start()
    {
        //otherScript = GetComponent<DistanceGrabbable>();
        renderer = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(renderer.material.color, penSize * penSize).ToArray();
        tipHeight = tip.localScale.y;

    }

    void Update()
    {
        //Console.WriteLine(DistanceGrabbable.Targeted);
        //if (DistanceGrabbable.Targeted)
        //{
        //    Console.WriteLine(DistanceGrabbable.Targeted);
        //}
        Draw();
    }

    private void Draw() 
    {
        if (Physics.Raycast(tip.position, transform.up, out touch, tipHeight))
        {
            if (touch.transform.CompareTag("Whiteboard"))
            {
                if (whiteboard == null) 
                {
                    whiteboard = touch.transform.GetComponent<Whiteboard>();
                }
                touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                var x = (int)(touchPos.x * whiteboard.textureSize.x - penSize/2);
                var y = (int)(touchPos.y * whiteboard.textureSize.y - penSize/2);

                if (y < 0 || y > whiteboard.textureSize.y || x < 0 || x > whiteboard.textureSize.x)
                {
                    return;
                }
                if (touchedLastFrame) 
                {
                    whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, f);
                        whiteboard.texture.SetPixels(lerpX, lerpY, penSize, penSize, colors);
                    }
                    transform.rotation = lastTouchRot;
                    whiteboard.texture.Apply();
                }
                lastTouchPos = new Vector2(x, y);
                lastTouchRot = transform.rotation;
                touchedLastFrame = true;
                return;
            }
        }
        whiteboard = null;
        touchedLastFrame = false;
    }
}
