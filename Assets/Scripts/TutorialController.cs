using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    
    public void Menu()
    {
        //SceneManager.LoadScene("Main Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
