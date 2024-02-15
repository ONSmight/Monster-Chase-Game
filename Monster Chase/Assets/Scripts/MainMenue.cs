using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
    public void StartGame() 
    {
        int Slected_Player = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.Chosen_p = Slected_Player;
        SceneManager.LoadScene("GamePlay");
    }
}
