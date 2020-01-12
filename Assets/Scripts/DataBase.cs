using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static DataBase Instance;
    public Girls SelectedGirl;
    public Material CurrentBackground;
    public List<Material> BackgroundMaterials;
    //public AudioClip MainMenu;
    //public AudioClip FastMusic;
    public int CurrentIndex;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
