/*=============================================
-----------------------------------
Copyright (c) 2018 Yongli Wang
-----------------------------------
@file: Delegates.cs
@date: 19/03/2018
@author: Yongli Wang
@brief: Script to do delegates
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public delegate void EventCallback();

    public delegate void FloatCallback(float value);

    public delegate void BoolCallback(bool value);
}
