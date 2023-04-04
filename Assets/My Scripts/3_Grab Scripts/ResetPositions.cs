using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositions : MonoBehaviour
{
    Vector3[] defaultPos;
    Vector3[] defaultScale;
    Quaternion[] defaultRot;

    Transform[] models;
    // Start is called before the first frame update
    void Start()
    {
        GetOriginalPositions();
    }

    private void GetOriginalPositions()
    {
        // Credits to:
        // https://stackoverflow.com/questions/38898035/unity-gameobjects-with-tag-reset-to-start-location-positions
        //Find GameObjects with Reset Position
        GameObject[] tempModels = GameObject.FindGameObjectsWithTag("Reset Positions");

        //Create pos, scale and rot, Transform array size based on sixe of Objects found
        defaultPos = new Vector3[tempModels.Length];
        defaultScale = new Vector3[tempModels.Length];
        defaultRot = new Quaternion[tempModels.Length];

        models = new Transform[tempModels.Length];

        //Get original the pos, scale and rot of each Object on the transform
        for (int i = 0; i < tempModels.Length; i++)
        {
            models[i] = tempModels[i].GetComponent<Transform>();

            defaultPos[i] = models[i].position;
            defaultScale[i] = models[i].localScale;
            defaultRot[i] = models[i].rotation;
        }
    }

    public void ResetAllPositions()
    {
        //Restore the all the original pos, scale and rot  of each GameOBject
        for (int i = 0; i < models.Length; i++)
        {
            models[i].position = defaultPos[i];
            models[i].localScale = defaultScale[i];
            models[i].rotation = defaultRot[i];
        }
    }
}
