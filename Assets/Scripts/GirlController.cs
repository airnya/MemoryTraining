using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GirlController : MonoBehaviour
{
    public Button button;
    public Button outfit;
    public Button Nude;
    public Button Fucked;    
    public MeshRenderer QuadRenderer;
    public int defaultGirlIndex;

    void Start()
    {
        //defaultGirlIndex = DataBase.Instance.CurrentIndex;
        if (DataBase.Instance.SelectedGirl == Girls.FirstGirl) 
        {
            DataBase.Instance.CurrentIndex = 0;
            //QuadRenderer.material = DataBase.Instance.CurrentBackground;
            ChangeGirlBackground( DataBase.Instance.CurrentIndex );
        } else if (DataBase.Instance.SelectedGirl == Girls.SecondGirl)
        {
            DataBase.Instance.CurrentIndex += 3;
            //QuadRenderer.material = DataBase.Instance.CurrentBackground;
            ChangeGirlBackground( DataBase.Instance.CurrentIndex );
        }
        defaultGirlIndex = DataBase.Instance.CurrentIndex;
    }

    public void ChangeGirlBackground (int index) 
    {
        DataBase.Instance.CurrentBackground = DataBase.Instance.BackgroundMaterials[index];
        QuadRenderer.material = DataBase.Instance.CurrentBackground;        
    }

    public void OnButtonClicked( string button)
    {
        switch (button) 
        {
            case "Outfit":
            ChangeGirlBackground( defaultGirlIndex );
            break;
            case "Nude":
            //DataBase.Instance.CurrentIndex += 1;
            ChangeGirlBackground(  defaultGirlIndex + 1 );
            break;
            case "Fucked":
            //DataBase.Instance.CurrentIndex += 2;
            ChangeGirlBackground(  defaultGirlIndex + 2);
            break;                        
        }
    }
    public void OnButtonOutfit()
    {
        ChangeGirlBackground( defaultGirlIndex );                 
    }    
    void Update()
    {
        
    }
}
