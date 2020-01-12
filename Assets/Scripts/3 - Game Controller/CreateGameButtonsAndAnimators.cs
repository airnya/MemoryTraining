using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateGameButtonsAndAnimators : MonoBehaviour
{
    [SerializeField]
    private LayoutGirlButtons layoutGirlButtons;

    [SerializeField]
    private Button cardButton;

    private int cardGame1 = 6;
    private int cardGame2 = 12;
    private int cardGame3 = 18;
    private int cardGame4 = 24;
    private int cardGame5 = 32;

    private List<Button> level1Buttons = new List<Button>(); 
    private List<Button> level2Buttons = new List<Button>(); 
    private List<Button> level3Buttons = new List<Button>(); 
    private List<Button> level4Buttons = new List<Button>(); 
    private List<Button> level5Buttons = new List<Button>();   

    private List<Animator> level1Anim = new List<Animator>();
    private List<Animator> level2Anim = new List<Animator>();
    private List<Animator> level3Anim = new List<Animator>();
    private List<Animator> level4Anim = new List<Animator>();
    private List<Animator> level5Anim = new List<Animator>();
    void Awake()
    {
        CreateButtons();
        GetAnimators();
    }
    void CreateButtons()
    {
        for(int i = 0; i < cardGame1; i++ )
        {
            Button btn = Instantiate(cardButton);
            btn.gameObject.name = "" + i;
            level1Buttons.Add(btn);
        }

        for(int i = 0; i < cardGame2; i++ )
        {
            Button btn = Instantiate(cardButton);
            btn.gameObject.name = "" + i;
            level2Buttons.Add(btn);
        }

        for(int i = 0; i < cardGame3; i++ )
        {
            Button btn = Instantiate(cardButton);
            btn.gameObject.name = "" + i;
            level3Buttons.Add(btn);
        }

        for(int i = 0; i < cardGame4; i++ )
        {
            Button btn = Instantiate(cardButton);
            btn.gameObject.name = "" + i;
            level4Buttons.Add(btn);
        }

        for(int i = 0; i < cardGame5; i++ )
        {
            Button btn = Instantiate(cardButton);
            btn.gameObject.name = "" + i;
            level5Buttons.Add(btn);
        }                                
    }
    
    void GetAnimators()
    {
        for (int i = 0; i < level1Buttons.Count; i++ )
        {
            level1Anim.Add(level1Buttons[i].GetComponent<Animator>());
            level1Buttons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level2Buttons.Count; i++ )
        {
            level2Anim.Add(level2Buttons[i].GetComponent<Animator>());
            level2Buttons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level3Buttons.Count; i++ )
        {
            level3Anim.Add(level3Buttons[i].GetComponent<Animator>());
            level3Buttons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level4Buttons.Count; i++ )
        {
            level4Anim.Add(level4Buttons[i].GetComponent<Animator>());
            level4Buttons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level5Buttons.Count; i++ )
        {
            level5Anim.Add(level5Buttons[i].GetComponent<Animator>());
            level5Buttons[i].gameObject.SetActive(false);
        }        
    }
    void Start()
    {
        AssignButtonsAndAnim();
    }
    void AssignButtonsAndAnim()
    {
        layoutGirlButtons.level1Buttons = level1Buttons;
        layoutGirlButtons.level2Buttons = level2Buttons;
        layoutGirlButtons.level3Buttons = level3Buttons;
        layoutGirlButtons.level4Buttons = level4Buttons;
        layoutGirlButtons.level5Buttons = level5Buttons;

        layoutGirlButtons.level1Anims = level1Anim;
        layoutGirlButtons.level2Anims = level2Anim;
        layoutGirlButtons.level3Anims = level3Anim;
        layoutGirlButtons.level5Anims = level5Anim;
        layoutGirlButtons.level4Anims = level4Anim;
        
    }
    
}
