﻿using System;
using System.Collections.Generic;
using System.Linq;
using GW2EIParser.EIData;
using GW2EIParser.Parser;
using GW2EIParser.Parser.ParsedData;
using GW2EIParser.Parser.ParsedData.CombatEvents;
using static GW2EIParser.Parser.ParseEnum.TrashIDS;

namespace GW2EIParser.Logic
{
    public class Samarog : RaidLogic
    {
        public Samarog(int triggerID) : base(triggerID)
        {
            MechanicList.AddRange(new List<Mechanic>
            {

            new HitOnPlayerMechanic(37996, "Shockwave", new MechanicPlotlySetting("circle","rgb(0,0,255)"), "Shockwave","Shockwave from Spears", "Shockwave",0,(de, log) => !de.To.HasBuff(log, 1122, de.Time)),
            new HitOnPlayerMechanic(38168, "Prisoner Sweep", new MechanicPlotlySetting("hexagon","rgb(0,0,255)"), "Sweep","Prisoner Sweep (horizontal)", "Sweep",0,(de, log) => !de.To.HasBuff(log, 1122, de.Time)),
            new HitOnPlayerMechanic(37797, "Trampling Rush", new MechanicPlotlySetting("triangle-right","rgb(255,0,0)"), "Trample","Trampling Rush (hit by stampede towards home)", "Trampling Rush",0),
            new HitOnPlayerMechanic(38305, "Bludgeon", new MechanicPlotlySetting("triangle-down","rgb(0,0,255)"), "Slam","Bludgeon (vertical Slam)", "Slam",0),
            new PlayerBuffApplyMechanic(37868, "Fixate: Samarog", new MechanicPlotlySetting("star","rgb(255,0,255)"), "Sam Fix","Fixated by Samarog", "Fixate: Samarog",0),
            new PlayerBuffApplyMechanic(38223, "Fixate: Guldhem", new MechanicPlotlySetting("star-open","rgb(255,100,0)"), "Ghuld Fix","Fixated by Guldhem", "Fixate: Guldhem",0),
            new PlayerBuffApplyMechanic(37693, "Fixate: Rigom", new MechanicPlotlySetting("star-open","rgb(255,0,0)"), "Rigom Fix","Fixated by Rigom", "Fixate: Rigom",0),
            new PlayerBuffApplyMechanic(37966, "Big Hug", new MechanicPlotlySetting("circle","rgb(0,128,0)"), "Big Green","Big Green (friends mechanic)", "Big Green",0),
            new PlayerBuffApplyMechanic(38247, "Small Hug", new MechanicPlotlySetting("circle-open","rgb(0,128,0)"), "Small Green","Small Green (friends mechanic)", "Small Green",0),
            new HitOnPlayerMechanic(38180, "Spear Return", new MechanicPlotlySetting("triangle-left","rgb(255,0,0)"), "Spear Return","Hit by Spear Return", "Spear Return",0),
            new HitOnPlayerMechanic(38260, "Inevitable Betrayal", new MechanicPlotlySetting("circle","rgb(255,0,0)"), "Green Fail","Inevitable Betrayal (failed Green)", "Failed Green",0),
            new HitOnPlayerMechanic(37851, "Inevitable Betrayal", new MechanicPlotlySetting("circle","rgb(255,0,0)"), "Green Fail","Inevitable Betrayal (failed Green)", "Failed Green",0),
            new HitOnPlayerMechanic(37901, "Effigy Pulse", new MechanicPlotlySetting("triangle-down-open","rgb(255,0,0)"), "Spear Pulse","Effigy Pulse (Stood in Spear AoE)", "Spear Aoe",0),
            new HitOnPlayerMechanic(37816, "Spear Impact", new MechanicPlotlySetting("triangle-down","rgb(255,0,0)"), "Spear Spawn","Spear Impact (hit by spawning Spear)", "Spear Spawned",0),
            new PlayerBuffApplyMechanic(38199, "Brutalize", new MechanicPlotlySetting("diamond-tall","rgb(255,0,255)"),"Brutalize","Brutalize (jumped upon by Samarog->Breakbar)", "Brutalize",0),
            new EnemyCastEndMechanic(38136, "Brutalize (Jump End)", new MechanicPlotlySetting("diamond-tall","rgb(0,160,150)"),"CC","Brutalize (Breakbar)", "Breakbar",0),
            new HitOnPlayerMechanic(38013, "Brutalize", new MechanicPlotlySetting("diamond-tall","rgb(255,0,0)"), "CC Fail","Brutalize (Failed CC)", "CC Fail",0, (de, log) => de.HasKilled),
            new EnemyBuffRemoveMechanic(38226, "Brutalize", new MechanicPlotlySetting("diamond-tall","rgb(0,160,0)"), "CC End","Ended Brutalize", "CC Ended",0),
            //new PlayerBoonRemoveMechanic(38199, "Brutalize", ParseEnum.BossIDS.Samarog, new MechanicPlotlySetting("diamond-tall","rgb(0,160,0)"), "CCed","Ended Brutalize (Breakbar broken)", "CCEnded",0),//(condition => condition.getCombatItem().IsBuffRemove == ParseEnum.BuffRemove.Manual)),
            //new Mechanic(38199, "Brutalize", Mechanic.MechType.EnemyBoonStrip, ParseEnum.BossIDS.Samarog, new MechanicPlotlySetting("diamond-tall","rgb(110,160,0)"), "CCed1","Ended Brutalize (Breakbar broken)", "CCed1",0),//(condition => condition.getCombatItem().IsBuffRemove == ParseEnum.BuffRemove.All)),
            new PlayerBuffApplyMechanic(37892, "Soul Swarm", new MechanicPlotlySetting("x-thin-open","rgb(0,255,255)"),"Wall","Soul Swarm (stood in or beyond Spear Wall)", "Spear Wall",0),
            new HitOnPlayerMechanic(38231, "Impaling Stab", new MechanicPlotlySetting("hourglass","rgb(0,0,255)"),"ShockWv Ctr","Impaling Stab (hit by Spears causing Shockwave)", "Shockwave Center",0),
            new HitOnPlayerMechanic(38314, "Anguished Bolt", new MechanicPlotlySetting("circle","rgb(255,140,0)"),"Stun","Anguished Bolt (AoE Stun Circle by Guldhem)", "Guldhem's Stun",0),
            
            //  new Mechanic(37816, "Brutalize", ParseEnum.BossIDS.Samarog, new MechanicPlotlySetting("star-square","rgb(255,0,0)"), "CC Target", casted without dmg odd
            });
            Extension = "sam";
            Icon = "https://wiki.guildwars2.com/images/f/f0/Mini_Samarog.png";
        }

        protected override CombatReplayMap GetCombatMapInternal()
        {
            return new CombatReplayMap("https://i.imgur.com/o2DHN29.png",
                            (1221, 1171),
                            (-6526, 1218, -2423, 5146),
                            (-27648, -9216, 27648, 12288),
                            (11774, 4480, 14078, 5376));
        }

        public override List<PhaseData> GetPhases(ParsedLog log, bool requirePhases)
        {
            List<PhaseData> phases = GetInitialPhase(log);
            NPC mainTarget = Targets.Find(x => x.ID == (int)ParseEnum.TargetIDS.Samarog);
            if (mainTarget == null)
            {
                throw new InvalidOperationException("Error Encountered: Samarog not found");
            }
            phases[0].Targets.Add(mainTarget);
            if (!requirePhases)
            {
                return phases;
            }
            // Determined check
            phases.AddRange(GetPhasesByInvul(log, 762, mainTarget, true, true));
            string[] namesSam = new[] { "Phase 1", "Split 1", "Phase 2", "Split 2", "Phase 3" };
            for (int i = 1; i < phases.Count; i++)
            {
                PhaseData phase = phases[i];
                phase.Name = namesSam[i - 1];
                if (i == 2 || i == 4)
                {
                    var ids = new List<int>
                    {
                       (int) Rigom,
                       (int) Guldhem
                    };
                    AddTargetsToPhase(phase, ids, log);
                }
                else
                {
                    phase.Targets.Add(mainTarget);
                }
            }
            return phases;
        }

        protected override List<int> GetFightTargetsIDs()
        {
            return new List<int>
            {
                (int)ParseEnum.TargetIDS.Samarog,
                (int)Rigom,
                (int)Guldhem,
            };
        }


        public override void ComputeNPCCombatReplayActors(NPC target, ParsedLog log, CombatReplay replay)
        {
            // TODO: facing information (shock wave)
            switch (target.ID)
            {
                case (int)ParseEnum.TargetIDS.Samarog:
                    List<AbstractBuffEvent> brutalize = GetFilteredList(log.CombatData, 38226, target, true);
                    int brutStart = 0;
                    foreach (AbstractBuffEvent c in brutalize)
                    {
                        if (c is BuffApplyEvent)
                        {
                            brutStart = (int)c.Time;
                        }
                        else
                        {
                            int brutEnd = (int)c.Time;
                            replay.Decorations.Add(new CircleDecoration(true, 0, 120, (brutStart, brutEnd), "rgba(0, 180, 255, 0.3)", new AgentConnector(target)));
                        }
                    }
                    break;
                case (int)Rigom:
                case (int)Guldhem:
                    break;
                default:
                    break;
            }
        }

        public override void ComputePlayerCombatReplayActors(Player p, ParsedLog log, CombatReplay replay)
        {
            // big bomb
            var bigbomb = log.CombatData.GetBuffData(37966).Where(x => (x.To == p.AgentItem && x is BuffApplyEvent)).ToList();
            foreach (AbstractBuffEvent c in bigbomb)
            {
                int bigStart = (int)c.Time;
                int bigEnd = bigStart + 6000;
                replay.Decorations.Add(new CircleDecoration(true, 0, 300, (bigStart, bigEnd), "rgba(150, 80, 0, 0.2)", new AgentConnector(p)));
                replay.Decorations.Add(new CircleDecoration(true, bigEnd, 300, (bigStart, bigEnd), "rgba(150, 80, 0, 0.2)", new AgentConnector(p)));
            }
            // small bomb
            var smallbomb = log.CombatData.GetBuffData(38247).Where(x => (x.To == p.AgentItem && x is BuffApplyEvent)).ToList();
            foreach (AbstractBuffEvent c in smallbomb)
            {
                int smallStart = (int)c.Time;
                int smallEnd = smallStart + 6000;
                replay.Decorations.Add(new CircleDecoration(true, 0, 80, (smallStart, smallEnd), "rgba(80, 150, 0, 0.3)", new AgentConnector(p)));
            }
            // fixated
            List<AbstractBuffEvent> fixatedSam = GetFilteredList(log.CombatData, 37868, p, true);
            int fixatedSamStart = 0;
            foreach (AbstractBuffEvent c in fixatedSam)
            {
                if (c is BuffApplyEvent)
                {
                    fixatedSamStart = Math.Max((int)c.Time, 0);
                }
                else
                {
                    int fixatedSamEnd = (int)c.Time;
                    replay.Decorations.Add(new CircleDecoration(true, 0, 80, (fixatedSamStart, fixatedSamEnd), "rgba(255, 80, 255, 0.3)", new AgentConnector(p)));
                }
            }
            //fixated Ghuldem
            List<AbstractBuffEvent> fixatedGuldhem = GetFilteredList(log.CombatData, 38223, p, true);
            int fixationGuldhemStart = 0;
            NPC guldhem = null;
            foreach (AbstractBuffEvent c in fixatedGuldhem)
            {
                if (c is BuffApplyEvent)
                {
                    fixationGuldhemStart = (int)c.Time;
                    long logTime = c.Time;
                    guldhem = Targets.FirstOrDefault(x => x.ID == (int)Guldhem && logTime >= x.FirstAware && logTime <= x.LastAware);
                }
                else
                {
                    int fixationGuldhemEnd = (int)c.Time;
                    if (guldhem != null)
                    {
                        replay.Decorations.Add(new LineDecoration(0, (fixationGuldhemStart, fixationGuldhemEnd), "rgba(255, 100, 0, 0.3)", new AgentConnector(p), new AgentConnector(guldhem)));
                    }
                }
            }
            //fixated Rigom
            List<AbstractBuffEvent> fixatedRigom = GetFilteredList(log.CombatData, 37693, p, true);
            int fixationRigomStart = 0;
            NPC rigom = null;
            foreach (AbstractBuffEvent c in fixatedRigom)
            {
                if (c is BuffApplyEvent)
                {
                    fixationRigomStart = (int)c.Time;
                    long logTime = c.Time;
                    rigom = Targets.FirstOrDefault(x => x.ID == (int)Rigom && logTime >= x.FirstAware && logTime <= x.LastAware);
                }
                else
                {
                    int fixationRigomEnd = (int)c.Time;
                    if (rigom != null)
                    {
                        replay.Decorations.Add(new LineDecoration(0, (fixationRigomStart, fixationRigomEnd), "rgba(255, 0, 0, 0.3)", new AgentConnector(p), new AgentConnector(rigom)));
                    }
                }
            }
        }

        public override int IsCM(CombatData combatData, AgentData agentData, FightData fightData)
        {
            NPC target = Targets.Find(x => x.ID == (int)ParseEnum.TargetIDS.Samarog);
            if (target == null)
            {
                throw new InvalidOperationException("Error Encountered: Samarog not found");
            }
            return (target.GetHealth(combatData) > 30e6) ? 1 : 0;
        }
    }
}
