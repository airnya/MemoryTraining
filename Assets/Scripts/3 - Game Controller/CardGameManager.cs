using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{
    [SerializeField]
	private GameFinished gameFinished;
    [SerializeField]
    private CardGameSaver gameSaver;
    private List<Button> cardButtons = new List<Button>( );
    private List<Animator> cardAnim = new List<Animator>( );
    [SerializeField]
    private List<Sprite> gameCardSprite = new List<Sprite>( );
    private int level;
    private string selectedMode;
    private Sprite cardBackGroundImage;
    private bool firstPick, secondPick;
    private int firstPickIndex, secondPickIndex;
    private string firstPickCard, secondPickCard;
    private int countTryPick; // succ. pick count
    private int countCorrectPick;    
    private int gamePicks; //count to win

    public void PickCard() 
    {
        if (!firstPick)
        {
            firstPick = true;
            firstPickIndex = int.Parse( UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstPickCard = gameCardSprite[firstPickIndex].name;

            int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            StartCoroutine(TurnCardButtonUp(cardAnim[firstPickIndex], cardButtons[firstPickIndex], gameCardSprite[firstPickIndex] ));
        } 
        else if (!secondPick)
        {
            secondPick = true;
            secondPickIndex = int.Parse( UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondPickCard = gameCardSprite[secondPickIndex].name;

            int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            StartCoroutine(TurnCardButtonUp(cardAnim[secondPickIndex], cardButtons[secondPickIndex], gameCardSprite[secondPickIndex] ));     
            StartCoroutine(CheckIfCardMatch(cardBackGroundImage));

            countTryPick++; 
        }
        Debug.Log("First sprite is " + firstPickCard + "Second sprite is " + secondPickCard);
        //Debug.Log("The selected Button is" + UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

    }

    IEnumerator CheckIfCardMatch(Sprite cardBackGroundImage)
    {
        yield return new WaitForSeconds(1.7f);
        if(firstPickCard == secondPickCard)
        {
            Debug.Log($"{firstPickCard} and {secondPickCard}");
            cardAnim[firstPickIndex].Play("FadeOut");
            cardAnim[secondPickIndex].Play("FadeOut");
            CheckIfGameFinished( );
            //increment score         
        } 
        else 
        {
            Debug.Log("Else started");
            StartCoroutine(TurnCardButtonBack(cardAnim[firstPickIndex], cardButtons[firstPickIndex], cardBackGroundImage ));            
            StartCoroutine(TurnCardButtonBack(cardAnim[secondPickIndex], cardButtons[secondPickIndex], cardBackGroundImage ));            
        }

        yield return new WaitForSeconds(.7f);

        firstPick = secondPick = false;
    }
    void CheckIfGameFinished()
    {
        countCorrectPick++;

        if(countCorrectPick == gamePicks)
        {
            Debug.Log("Game ends no more sex");
            CheckHowManyMatch( );
        }
    }

    void CheckHowManyMatch( )
    {
        int howManyPicks = 0;
        switch (level)
        {
            case 0:
                howManyPicks = 5;
                break;
            case 1: 
                howManyPicks = 10;
                break;
            case 2:
                howManyPicks = 15;
                break;
            case 3: 
                howManyPicks = 22;
                break;
            case 4:
                howManyPicks = 25;
                break;                              
        }

        if (countTryPick < howManyPicks) 
        {
			gameFinished.ShowGameFinishedPanel (3);
			gameSaver.Save(level, selectedMode, 3);
		} 
        else if (countTryPick < (howManyPicks + 5)) 
        {
			gameFinished.ShowGameFinishedPanel (2);
			gameSaver.Save(level, selectedMode, 2);
		} 
        else 
        {
			gameFinished.ShowGameFinishedPanel (1);
			gameSaver.Save(level, selectedMode, 1);
		}
    }

    public List<Animator> resetGameplay( )
    {
        firstPick = secondPick = false;
        countTryPick = 0;
        countCorrectPick = 0;
        
        gameFinished.HideGameFinishedPanel( );

        return cardAnim;
    }

    IEnumerator TurnCardButtonUp(Animator animator, Button btn, Sprite cardImage )
    {
        animator.Play("TurnUp");
        yield return new WaitForSeconds(.4f);
        btn.image.sprite = cardImage;
    }

    IEnumerator TurnCardButtonBack(Animator animator, Button btn, Sprite cardImage )
    {
        animator.Play("TurnBack");
        yield return new WaitForSeconds(.4f);
        btn.image.sprite = cardImage;
    }    
    void AddListeners()
    {
        foreach(Button btn in cardButtons)
        {
            btn.onClick.RemoveAllListeners( );
            btn.onClick.AddListener(( ) => PickCard( ));
        }
    }

    public void SetupButtonAnim( List<Button> buttons, List<Animator> anims)
    {
        this.cardButtons = buttons;
        this.cardAnim = anims;

        gamePicks = cardButtons.Count / 2;
        cardBackGroundImage = cardButtons[0].image.sprite;
        AddListeners( );
    }
    public void SetGameCardSprite(List<Sprite> gameCardSprite)
    {
        this.gameCardSprite = gameCardSprite;
    }
    public void SetLevel(int level)
    {
        this.level = level;
    }
    public void SetSelectedMod (string selectedMode )
    {
        this.selectedMode = selectedMode;
    }
}
