using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Girls
{
    Meditation, FirstGirl, SecondGirl
}

public class GameController : MonoBehaviour
{        
    public void ChangeScene(string gameMode)
    {
        System.Enum.TryParse(gameMode, out Girls selectedGirl);
        DataBase.Instance.SelectedGirl = selectedGirl;
        SceneManager.LoadScene(2);
    }
}
