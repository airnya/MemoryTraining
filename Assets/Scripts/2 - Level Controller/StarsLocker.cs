using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsLocker : MonoBehaviour
{
    [SerializeField]
    CardGameSaver gameSaver;
    [SerializeField]
    private GameObject[] level1Stars, level2Stars, level3Stars, level4Stars,level5Stars, level6Stars;

    private int[] nonAdultLevelStars;
    public int[] adultLevelStars;

    public void ActiveStars(int level, string selectedMode)
    {
        GetStars( );
        int stars;

        switch (selectedMode)
        {
            case "Play":
                stars = nonAdultLevelStars[level];
                ActivateStars(level, stars);
                break;

            case "Play Dlc Button":
                stars = nonAdultLevelStars[level];
                ActivateStars(level, stars);                
                break;                
        }

    }
    void ActivateStars (int level, int stars)
    {
        switch (level)
        {
            case 0:
                if(stars != 0)
                {
                    for(int i =0; i < stars; i++)
                    {
                        level1Stars[i].SetActive(true);
                    }
                }
                break;
        case 1:
			
			if(stars != 0) {
				for(int i = 0; i < stars; i++) {
					level2Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 2:
			
			if(stars != 0) {
				for(int i = 0; i < stars; i++) {
					level3Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 3:
			
			if(stars != 0) {
				for(int i = 0; i < stars; i++) {
					level4Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 4:
			
			if(stars != 0) {
				for(int i = 0; i < stars; i++) {
					level5Stars[i].SetActive(true);
				}
			}
			
			break;

		case 5:
			
			if(stars != 0) {
				for(int i = 0; i < stars; i++) {
					level6Stars[i].SetActive(true);
				}
			}
			
			break;
		}
    }
    public void DeactiveStars( )
    {
        for (int i = 0; i < level1Stars.Length; i++)
        {
            level1Stars[i].SetActive(false);
            level2Stars[i].SetActive(false);
            level3Stars[i].SetActive(false);
            level4Stars[i].SetActive(false);
            level5Stars[i].SetActive(false);
            level6Stars[i].SetActive(false);            
        }
    }
    void GetStars( )
    {
        adultLevelStars = gameSaver.adultCardLevelStars;
        nonAdultLevelStars = gameSaver.nonAdultCardLevelStars;    
    }

}
