﻿using LuckParser.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LuckParser.Models.ParseModels.BoonSimulator;

namespace LuckParser.Models.ParseModels
{
    public abstract class StackingLogic
    {
        public abstract bool stackEffect(ParsedLog log, BoonStackItem toAdd, List<BoonStackItem> stacks, List<BoonSimulationItem> simulation);

        public abstract void sort(ParsedLog log, List<BoonStackItem> stacks);
    }
}