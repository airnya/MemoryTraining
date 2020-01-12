using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGirlGame : MonoBehaviour
{
    [SerializeField]
    private CardGameManager cardGameManager;
    [SerializeField]
    private GirlLevelLocker levelLocker;
    [SerializeField]
    private LayoutGirlButtons LayoutGirlButtons;
    [SerializeField]
    private GameObject levelMenu;    
    [SerializeField]
    private Animator levelMenuAnim;
    [SerializeField]
    private GameObject girlGamePanel1, girlGamePanel2, girlGamePanel3, girlGamePanel4, girlGamePanel5;   
    [SerializeField]
    private Animator girlGamePanelAnim1, girlGamePanelAnim2, girlGamePanelAnim3, girlGamePanelAnim4, girlGamePanelAnim5; 
    private int girlLevel;
    private string selectedMode;            
    private List<Animator> anims; //need this if we come back to level
    public void LoadGirlLevel(int level, string gameMode)
    {
        this.girlLevel = level;
        this.selectedMode = gameMode;
        LayoutGirlButtons.LayoutButtons(level, selectedMode);
        
        switch(girlLevel)
        {
            case 0:
                StartCoroutine(LoadGirlGamePanel(girlGamePanel1, girlGamePanelAnim1));
                break;
            case 1:

                StartCoroutine(LoadGirlGamePanel(girlGamePanel2, girlGamePanelAnim2));            
                break;

            case 2:
                StartCoroutine(LoadGirlGamePanel(girlGamePanel3, girlGamePanelAnim3));
                break;

            case 3:
                StartCoroutine(LoadGirlGamePanel(girlGamePanel4, girlGamePanelAnim4));
                break;

            case 4:
                StartCoroutine(LoadGirlGamePanel(girlGamePanel5, girlGamePanelAnim5)); 
                break;
        }
    }
    public void BackGirlSelectMenu()
    {   
        Debug.Log("Back Button Pressed");     
        anims = cardGameManager.resetGameplay( );
        levelLocker.CheckWhisLevelAreUnlocked( selectedMode );
        switch(girlLevel)
        {
            case 0:
                StartCoroutine(BackToLevelMenu(girlGamePanel1, girlGamePanelAnim1));
                break;
            case 1:

                StartCoroutine(BackToLevelMenu(girlGamePanel2, girlGamePanelAnim2));            
                break;

            case 2:
                StartCoroutine(BackToLevelMenu(girlGamePanel3, girlGamePanelAnim3));
                break;

            case 3:
                StartCoroutine(BackToLevelMenu(girlGamePanel4, girlGamePanelAnim4));
                break;

            case 4:
                StartCoroutine(BackToLevelMenu(girlGamePanel5, girlGamePanelAnim5)); 
                break;
        }
    }
    IEnumerator BackToLevelMenu(GameObject girlGamePanel, Animator girlGamePanelAnim)
    {
        Debug.Log($"{levelMenu} + {girlGamePanel}");
        levelMenu.SetActive(true);
        levelMenuAnim.Play("OpenGirlPanel");
        girlGamePanelAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);

        foreach(Animator anim in anims)
        {
            anim.Play("Idle");
        }
        yield return new WaitForSeconds(0.5f);

        girlGamePanel.SetActive(false);

    }

    IEnumerator LoadGirlGamePanel(GameObject girlGamePanel, Animator girlGamePanelAnim)
    {
        girlGamePanel.SetActive(true);
        girlGamePanelAnim.Play("SlideIn");
        levelMenuAnim.Play("CloseGirlPanel");
        yield return new WaitForSeconds(1f);
        levelMenu.SetActive(false);
    }
    
}
