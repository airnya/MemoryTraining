using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGirl : MonoBehaviour
{
    [SerializeField]
    private CardGameManager cardGameManager;    
    [SerializeField]
    private GirlLevelLocker levelLocker;
    [SerializeField]
    private LoadGirlGame loadGirlGame;
    [SerializeField]
    private GameObject mainMenu, levelMenu;    
    [SerializeField]
    private Animator selectedMenuAnim, levelMenuAnim;
    private string selectedGameMode;
    private bool[] cards;
    public void BackMainMenu()
    {
        StartCoroutine(ShowMainMenu ());
    }
    public void SelectedGirlLevel()
    {
        int level = int.Parse( UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name );
        cards = levelLocker.GetCardLevels( selectedGameMode );     

        if (cards[level]) 
        {
            cardGameManager.SetLevel( level );
            loadGirlGame.LoadGirlLevel( level, selectedGameMode );
        }
        //StartCoroutine(ShowMainMenu());
    }
    IEnumerator ShowMainMenu()
    { 
        mainMenu.SetActive(true);
        selectedMenuAnim.Play("SlideIn");
        levelMenuAnim.Play("CloseGirlPanel");
        yield return new WaitForSeconds(1f);
        levelMenu.SetActive (false);
    }
    public void SetGameMode(string aGameMode)
    {
        this.selectedGameMode = aGameMode;
        Debug.Log ("Selected game mod is " + selectedGameMode);
    }
}
