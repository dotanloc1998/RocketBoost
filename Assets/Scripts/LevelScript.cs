using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene(8);
    }
}
