using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool finished = false;
    public bool isFinish = false;
    void OnCollisionEnter(Collision collision)
    {
        if(!finished)
            Camera.main.GetComponent<PreGameJamGameInOneScriptFuckinAwesome>().IncreaseScore();
        GetComponent<MeshRenderer>().material.color = Color.green;
        finished = true;
        if(isFinish)
            Debug.Log($"WINNER WINNER");
    }
}
