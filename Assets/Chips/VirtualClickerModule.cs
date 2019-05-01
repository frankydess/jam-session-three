﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualClickerModule : Module
{
    Stat incomeDelay = null;
    Stat incomePerTick = null;

    float accumulator;

    void Update()
    {
        if (!IsPowered) return;
        accumulator += Time.deltaTime;
        if (accumulator >= incomeDelay.ProcessedValue)
        {
            accumulator -= incomeDelay.ProcessedValue;
            Bank.Deposit(incomePerTick.ProcessedValue);
        }
    }

    public override void Tierify(int tier)
    {
        incomeDelay = stats[STAT_HERTZ];
        incomePerTick = stats[STAT_INCOME];
        base.Tierify(tier);
        price = tier;
        incomePerTick.BaseValue *= Mathf.Pow(2, tier);
    }
}
