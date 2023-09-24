using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{ 
    public void loadPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void loadTutorial()
    {
        GameObject.Find("menu").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(3).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(6).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(7).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(5).gameObject.SetActive(false);
    }

    public void backButton()
    {
        GameObject.Find("menu").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(3).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(5).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(6).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(7).gameObject.SetActive(false);
    }
    public void credits()
    {
        GameObject.Find("menu").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(3).gameObject.SetActive(false);
        GameObject.Find("menu").transform.GetChild(5).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(6).gameObject.SetActive(true);
        GameObject.Find("menu").transform.GetChild(7).gameObject.SetActive(false);
    }

    public void close()
    {
        Application.Quit();
    }
}
