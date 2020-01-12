using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[Serializable]
public class GameData : MonoBehaviour
{
    private bool[] nonAdultCardLevels;
    private bool[] adultCardLevels;

    private int[] nonAdultCardLevelStars;
    private int[] adultCardLevelStars;
    private bool isGameStartedFirstTime;
    private float musicVolume;

    public void SetNonAdultCardLevels(bool[] nonAdultCardLevels)
    {
        this.nonAdultCardLevels = nonAdultCardLevels;
    }	
	public bool[] GetNonAdultCardLevels( )
    {
		return this.nonAdultCardLevels;
	}
	public void SetAdultCardLevels(bool[] adultCardLevels)
    {
        this.adultCardLevels = adultCardLevels;
    }
	public bool[] GetAdultCardLevel( )
    {
        return this.adultCardLevels;
    }
	
	public void SetNonAdultLevelStars(int[] nonAdultLevelStars) {
		this.nonAdultCardLevelStars = nonAdultLevelStars;
	}
	
	public int[] GetNonAdultLevelStars( ) {
		return this.nonAdultCardLevelStars;
	}
	
	public void SetAdultLevelStars(int[] adultLevelStars) 
    {
		this.adultCardLevelStars = adultLevelStars;
	}
	
	public int[] GetAdultLevelStars( ) 
    {
		return this.adultCardLevelStars;
	}

	public void SetIsGameStartedForTheFirstTime(bool isGameStartedFirstTime) 
    {
		this.isGameStartedFirstTime = isGameStartedFirstTime;
	}
	
	public bool GetIsGameStartedForTheFirstTime( ) 
    {
		return this.isGameStartedFirstTime;
	}
	
	public void SetMusicVolume(float musicVolume) {
		this.musicVolume = musicVolume;
	}
	
	public float GetMusicVolume() {
		return this.musicVolume;
	}
}
