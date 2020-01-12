using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutGirlButtons : MonoBehaviour
{
    [SerializeField]
    private CardGameManager cardGameManager;    
    [SerializeField]
	private SetupGirlGame setupGirlGame;

	[SerializeField]
	private Transform gameLevel1, gameLevel2, gameLevel3, gameLevel4, gameLevel5;
	
	public List<Button> level1Buttons, level2Buttons, level3Buttons, level4Buttons, level5Buttons;
	
	public List<Animator> level1Anims, level2Anims, level3Anims, level4Anims, level5Anims;
	
	[SerializeField]
	private Sprite[] cardButtonsBacksideImages;
	
	private int gameLevel;
	
	private string selectedMode;

	public void LayoutButtons(int level, string mode) 
    {
		this.gameLevel = level;
		this.selectedMode = mode;
        
        setupGirlGame.SetLevelCard(level, mode);
		LayoutPuzzle ();
	}

    void LayoutPuzzle()
    {
        switch(this.gameLevel)
        {
            case 0:
                foreach(Button btn in level1Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy) 
                    {
                        btn.gameObject.SetActive(true);
                        btn.transform.SetParent(gameLevel1, false);
                    }
                    
                    if(selectedMode == "Play") {
                        btn.image.sprite = cardButtonsBacksideImages[0];
                    } else if(selectedMode == "Transport Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[1];
                    } else if(selectedMode == "Dlc Play Button") {
                        btn.image.sprite = cardButtonsBacksideImages[2];
                    }    
                }
                setupGirlGame.SetGameButtonsAnimators( level1Buttons, level1Anims);

                break;

            case 1:
                foreach(Button btn in level2Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy) 
                    {
                        btn.gameObject.SetActive(true);
                        btn.transform.SetParent(gameLevel2, false);
                    }
                    
                    if(selectedMode == "Play") {
                        btn.image.sprite = cardButtonsBacksideImages[0];
                    } else if(selectedMode == "Transport Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[1];
                    } else if(selectedMode == "Fruit Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[2];
                    }    
                }
                setupGirlGame.SetGameButtonsAnimators( level2Buttons, level2Anims);

                break;

            case 2:
                foreach(Button btn in level3Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy) 
                    {
                        btn.gameObject.SetActive(true);
                        btn.transform.SetParent(gameLevel3, false);
                    }
                    
                    if(selectedMode == "Candy Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[0];
                    } else if(selectedMode == "Transport Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[1];
                    } else if(selectedMode == "Fruit Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[2];
                    }    
                }
                setupGirlGame.SetGameButtonsAnimators( level3Buttons, level3Anims);

                break;

            case 3:
                foreach(Button btn in level4Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy) 
                    {
                        btn.gameObject.SetActive(true);
                        btn.transform.SetParent(gameLevel4, false);
                    }
                    
                    if(selectedMode == "Candy Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[0];
                    } else if(selectedMode == "Transport Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[1];
                    } else if(selectedMode == "Fruit Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[2];
                    }    
                }
                setupGirlGame.SetGameButtonsAnimators( level4Buttons, level4Anims);

                break;
                
            case 4:
                foreach(Button btn in level5Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy) 
                    {
                        btn.gameObject.SetActive(true);
                        btn.transform.SetParent(gameLevel5, false);
                    }

                    if(selectedMode == "Play") {
                        btn.image.sprite = cardButtonsBacksideImages[0];
                    } else if(selectedMode == "Transport Puzzle") {
                        btn.image.sprite = cardButtonsBacksideImages[1];
                    } else if(selectedMode == "Dlc Play Button") {
                        btn.image.sprite = cardButtonsBacksideImages[2];
                    }                    
                }
                setupGirlGame.SetGameButtonsAnimators( level5Buttons, level5Anims);

                break;
        }
    }
}
