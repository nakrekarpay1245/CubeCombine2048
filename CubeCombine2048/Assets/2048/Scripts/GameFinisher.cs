using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            if (other.gameObject.GetComponent<Cube>().passed)
            {
                Debug.Log("Lose");
                Manager.manager.ActivateRestartButton();
                Time.timeScale = 0.1f;
            }            
        }
    }
}
