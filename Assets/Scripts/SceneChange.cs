using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ToMain", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
