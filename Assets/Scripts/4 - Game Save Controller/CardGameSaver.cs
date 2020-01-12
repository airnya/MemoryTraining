using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class CardGameSaver : MonoBehaviour
{
    private GameData gameData;
    public bool[] nonAdultCardLevels;
    public bool[] adultCardLevels;

    public int[] nonAdultCardLevelStars;
    public int[] adultCardLevelStars;
    private bool isGameStartedFirstTime;
    public float musicVolume;

    void Awake ( )
    {
        InitalizeGame( );
    }

    void InitalizeGame( )
    {
        LoadGameData( );

        if(gameData != null) isGameStartedFirstTime = gameData.GetIsGameStartedForTheFirstTime( );
        else isGameStartedFirstTime = true;

        if(isGameStartedFirstTime)
        {
            isGameStartedFirstTime = false;
            musicVolume = 0;
            adultCardLevels = new bool[6];
            nonAdultCardLevels = new bool[6];

            adultCardLevels[0] = true;
            nonAdultCardLevels[0] = true;

            //lock all level if we playing first time
            for (int i = 1; i < adultCardLevels.Length; i++)
            {
                adultCardLevels[i] = false;
                nonAdultCardLevels[i] = false;
            }

            adultCardLevelStars = new int[6];
            nonAdultCardLevelStars = new int[6];

            for (int i = 0; i < adultCardLevelStars.Length; i++)
            {
                adultCardLevelStars[i] = 0;
                nonAdultCardLevelStars[i] = 0;                
            }

            gameData = new GameData( );

            gameData.SetNonAdultCardLevels(nonAdultCardLevels);
            gameData.SetAdultCardLevels(adultCardLevels);

            gameData.SetNonAdultLevelStars(nonAdultCardLevelStars);
            gameData.SetAdultLevelStars(adultCardLevelStars);

            gameData.SetIsGameStartedForTheFirstTime(isGameStartedFirstTime);
            gameData.SetMusicVolume(musicVolume);

            SaveGameData( );
            LoadGameData( );
        }
    }

    void SaveGameData( )
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter( );
            file = File.Create(Application.persistentDataPath + "/GameData.dat");

            if(gameData != null)
            {
                gameData.SetNonAdultCardLevels(nonAdultCardLevels);
                gameData.SetAdultCardLevels(adultCardLevels);

                gameData.SetNonAdultLevelStars(nonAdultCardLevelStars);
                gameData.SetAdultLevelStars(adultCardLevelStars);

                gameData.SetIsGameStartedForTheFirstTime(isGameStartedFirstTime);
                gameData.SetMusicVolume(musicVolume);

                bf.Serialize(file, gameData);    
            }
        }
        catch (Exception e)
        {

        }
        finally
        {
            if(file != null) file.Close( );
        }
    }

    void LoadGameData( ) 
    {
        FileStream file =null;
        try 
        {
            BinaryFormatter bf = new BinaryFormatter( );
            file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            gameData = (GameData)bf.Deserialize(file);

            if(gameData != null)
            {
                adultCardLevels = gameData.GetAdultCardLevel( );
                nonAdultCardLevels = gameData.GetNonAdultCardLevels( );

                adultCardLevelStars = gameData.GetAdultLevelStars( );
                nonAdultCardLevelStars = gameData.GetNonAdultLevelStars( );

                musicVolume = gameData.GetMusicVolume( );
            }
        } catch (Exception ex){}
        finally
        {
            if(file != null) file.Close( );
        }
    }

    public void Save(int level, string selectedMode, int stars)
    {
        int unlockNextLevel = -1;

        switch (selectedMode)
        {
            case "Play":
                unlockNextLevel = level + 1;
                nonAdultCardLevelStars[level] = stars;

                if(unlockNextLevel < nonAdultCardLevels.Length)
                {
                    nonAdultCardLevels[unlockNextLevel] = true;
                }
                break;

            case "Dlc Play Button":
                unlockNextLevel = level + 1;
                nonAdultCardLevelStars[level] = stars;

                if(unlockNextLevel < nonAdultCardLevels.Length)
                {
                    nonAdultCardLevels[unlockNextLevel] = true;
                }
                break;                
        }
    }
}
