using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMode : MonoBehaviour
{
    [SerializeField]
    private CardGameManager cardGameManager;
    [SerializeField]
    private SelectedGirl selectedGirl;
    [SerializeField]
    private GirlLevelLocker levelLocker;    
    [SerializeField]
    private StarsLocker starsLocker;

    [SerializeField]
    private GameObject selectedMenuPanel, levelMenuPanel;
    [SerializeField]
    private Animator selectedMenuAnim, levelMenuAnim;

    private string selectedMode;
    public void SelectedGameMode()
    {
        starsLocker.DeactiveStars( );
        selectedMode = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        cardGameManager.SetSelectedMod ( selectedMode );
        // Debug.Log (selectedMode);
        levelLocker.CheckWhisLevelAreUnlocked ( selectedMode );
        selectedGirl.SetGameMode( selectedMode );
        StartCoroutine(ShowLevelSelectMenu( ));
    }
    IEnumerator ShowLevelSelectMenu()
    {
        levelMenuPanel.SetActive (true); 
        selectedMenuAnim.Play("SlideOut");
        levelMenuAnim.Play("OpenGirlPanel");
        yield return new WaitForSeconds(1f);
        selectedMenuPanel.SetActive(false);
    }
}
