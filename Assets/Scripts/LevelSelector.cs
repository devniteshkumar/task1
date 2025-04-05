using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void LoadLevel(int levelNo)
    {
        Application.LoadLevel(levelNo);
    }
}
