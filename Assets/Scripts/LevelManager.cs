using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] //poder ver propiedades en unity
    bool circularNavigation = true;
 /// <summary>
 /// Retruns current Scene Index
 /// </summary>
 /// <returns>Current Scene Index</returns>
    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public int GetLastScene() // retorna la ultima escena
    {
        return SceneManager.sceneCountInBuildSettings - 1;
    }
    public void FirstScene() { 
        SceneManager.LoadScene(0); //ir a la primera escena
    }

    public void LastScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1); //ir hasta la ultima escena puede ser tambien con: 1. SceneManger.scenecount - 1 o 2. SceneManger.GetAllScenes().Length -1;
    }

    public void NextScene() { 
        int currentScene = GetCurrentScene();//Almacena el valor de la escena actual
        int lastScene = GetLastScene();//Almacena el valor de la última escena

        if (currentScene < lastScene) //si escena actual no es la ultima escena
        {
            SceneManager.LoadScene(currentScene + 1); //entonces, cargue la siguiente escena
        }
        else if (circularNavigation) {  //si esta permitido navegar circularmente que pase a la primer, osea si llego a la ultima que retorne a la primera
            FirstScene();
        }
    }

    //metodo que hace posible que se vaya de nuevo a la escena primera si se llego al final 
    public void PreviousScene()
    {
        int currentScene = GetCurrentScene();

        if (currentScene > 0) { 
            SceneManager.LoadScene(currentScene - 1);
        }
    }

}
