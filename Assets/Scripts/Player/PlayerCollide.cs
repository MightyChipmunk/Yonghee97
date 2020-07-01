using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollide : MonoBehaviour
{
    public GameObject obj;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == obj.tag)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
