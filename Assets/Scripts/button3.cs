using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void button() 
    {

        Invoke("startgame", .3f);
        }
    public void startgame()
    {
        SceneManager.LoadScene("3round");
    
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
