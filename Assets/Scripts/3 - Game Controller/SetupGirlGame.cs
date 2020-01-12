using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetupGirlGame : MonoBehaviour
{
    [SerializeField]
    private CardGameManager cardGameManager;    
    private Sprite[] nonAdultSprites, adultSprites, sexSprites;    
    //Girl card holder
    [SerializeField]
    private List<Sprite> girlCards = new List<Sprite>( ); //gamePuzzles
    private List<Button> cardButtons = new List<Button>( ); //puzzleButtons
    private List<Animator> cardButtonAnimators = new List<Animator>( );
    int level;
    private string selectedMode;
    private int looper;
    void Awake( )
    {
        nonAdultSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/nier2");
        adultSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Candy");
        sexSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Fruit");
    }
    void PrepareGameSprites( )
    {
        girlCards.Clear( );
        girlCards = new List<Sprite>( );

        int index = 0;
		switch (level) 
        {
            case 0:
                looper = 6;
                break;
                
            case 1:
                looper = 12;
                break;
                
            case 2:
                looper = 18;
                break;
                
            case 3:
                looper = 24;
                break;
                
            case 4:
                looper = 30;
                break;
        }
        switch(selectedMode)
        {
            case "Play":
                for(int i = 0; i < looper; i++)
                {
                    if(index == looper / 2)
                    {
                        index = 0;
                    }

                    girlCards.Add(nonAdultSprites[index]);
                    index++;
                }
                break;
                
            case "Dlc Play Button":
                for(int i = 0; i < looper; i++)
                {
                    if(index == looper / 2)
                    {
                        index = 0;
                    }

                    girlCards.Add(adultSprites[index]);
                    index++;
                }
                break;  
        }
        ShuffleList(girlCards);              
    }

    void ShuffleList(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
			int randomIndex = Random.Range(i, list.Count);
			list[i] = list[randomIndex];
			list[randomIndex] = temp;
        }
    }
    public void SetLevelCard (int level, string selectedMod)
    {
        this.level = level;
        this.selectedMode = selectedMod;

        PrepareGameSprites( );

        cardGameManager.SetGameCardSprite (this.girlCards);
    }

    public void SetGameButtonsAnimators(List<Button> cardButtons, List<Animator> gameButtonAnimators)
    {
        this.cardButtons = cardButtons;
        this.cardButtonAnimators = gameButtonAnimators;

        cardGameManager.SetupButtonAnim(cardButtons, cardButtonAnimators);
    }
}
