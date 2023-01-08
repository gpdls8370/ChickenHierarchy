using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void button() 
    {

        Invoke("startgame", .3f);
        }
    public void startgame()
    {
        SceneManager.LoadScene("2round");
    
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
