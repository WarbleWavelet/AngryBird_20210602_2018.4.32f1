using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public  class PanelStar
{
    public string name;
    public int star;      
}
[Serializable]
public class LevelStar
{
    public string name;
    public int star;
}
[Serializable]
public class Save
{
    public List<PanelStar> panelStarList;
    public List<LevelStar> levelStarList;

}



