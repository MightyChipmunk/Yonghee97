using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeNoskip : MonoBehaviour
{
    public float interval;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("ToNext", interval);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void ToNext()
    {
        SceneManager.LoadScene(scene);
    }
}
