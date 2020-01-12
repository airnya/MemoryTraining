using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlLevelLocker : MonoBehaviour
{
    [SerializeField]
    private CardGameSaver cardGameSaver;
    [SerializeField]
    private StarsLocker starsLocker;
    [SerializeField]
    private GameObject[] levelStarsHolders;
    [SerializeField]
    private GameObject[] levelsPadLocks;

    private bool[] nonAdultCardLevels;
    private bool[] adultCardLevels;
    void Awake( )
    {
        DeactiveUnlockAndStarsHolder( );
    }
    void Start( )
    {
        GetLevels();
    }
    public void CheckWhisLevelAreUnlocked( string selectedMode)
    {
        DeactiveUnlockAndStarsHolder( );
        GetLevels( );

        switch(selectedMode)
        {
            case "Play":
                for(int i = 0; i < nonAdultCardLevels.Length; i++)
                {
                    if(nonAdultCardLevels[i])
                    {
                        levelStarsHolders[i].SetActive(true);   
                        starsLocker.ActiveStars(i, selectedMode);                     
                    }
                    else
                    {
                        levelsPadLocks[i].SetActive(true);
                    }
                }

                break;

            case "Play Dlc Button":
                for(int i = 0; i < adultCardLevels.Length; i++)
                {
                    if(adultCardLevels[i])
                    {
                        levelStarsHolders[i].SetActive(true);                        
                        starsLocker.ActiveStars(i, selectedMode);                        
                    }
                    else
                    {
                        levelsPadLocks[i].SetActive(true);
                    }
                }

                break;                
        }
    }

    void DeactiveUnlockAndStarsHolder()
    {
        for (int i = 0; i < levelStarsHolders.Length; i++)
        {
            levelStarsHolders[i].SetActive(false);
            levelsPadLocks[i].SetActive(false);
        }
    }

    void GetLevels( )
    {
       nonAdultCardLevels = cardGameSaver.nonAdultCardLevels;
       adultCardLevels = cardGameSaver.adultCardLevels;
    }

    public bool[] GetCardLevels(string selectedMode)
    {
        switch (selectedMode)
        {
            case "Play":
                return this.nonAdultCardLevels;

            case "Play Dlc Button":
                return this.adultCardLevels;

            default:
                return null;
        }
    }
}
