using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsContoller : MonoBehaviour
{
//    [SerializeField]
//	private MusicController musicController;

    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private Animator settingPanelAnim;

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive (true);
        settingPanelAnim.Play ("Open");
    }
    public void CloseSettingsPanel()
    {
		StartCoroutine (CloseSeettings ());
    }

    IEnumerator CloseSeettings()
    {
        settingPanelAnim.Play ("Close");
        yield return new WaitForSeconds(1f);
        settingsPanel.SetActive(false);
    }
	public void GetVolume(float volume) {
//		musicController.SetMusicVolume (volume);
	}    
}
