using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Players;
    public static GameManager instance;

    private int _chosenP;

    public int Chosen_p
    {
        get { return _chosenP; }
        set { _chosenP = value; }
    }

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
	}
	// Start is called before the first frame update
	void OnEnable()
	{
        SceneManager.sceneLoaded += OnLevelWasLoaded;	
	}
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelWasLoaded;
    }
    private void OnLevelWasLoaded(Scene scene,LoadSceneMode mode)
	{
        if (scene.name == "GamePlay")
        {
            Instantiate(Players[Chosen_p], gameObject.transform);
        }
	}




}//class
