using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using UnityEngine;

public class LevelParser
{
    void Start()
    {

    }
}

public class Level
{
    public int levelOrder;
    public string size;
    public List<Block> blockSpawnList;
    public string blockMaterialPath;
}

public class BlockToSpawn
{
    int x;
    int y;
}