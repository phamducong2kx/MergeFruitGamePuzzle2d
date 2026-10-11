using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum TypeFruit
{
    orange,
    banana,
    duahau,
    lemone,
    duachuot,
    nho,
    apple,
    dragon
}


[CreateAssetMenu(fileName = "FruitData", menuName = "FruitMergr/FruitData")]
public class FruitData : ScriptableObject
{
    public List<FruitDataInfor> listFruits = new List<FruitDataInfor>();
}

[Serializable]
public class FruitDataInfor
{
    public int point;
    public TypeFruit typeOrigin;
    public TypeFruit typeAfterMerge;


}

