using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    #region fruit
    public static Action<Fruit, Fruit> OnMergeFruit;
    public static void InvokeMergeFruit(Fruit a, Fruit b) => OnMergeFruit?.Invoke(a, b);
    #endregion

}
