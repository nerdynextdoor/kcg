﻿using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Action
{
    // 
    public class ActionSchedulerSystem
    {
        public void Update(Contexts contexts, float deltaTime, ref Planet.PlanetState planet)
        {
            var group = contexts.agent.GetGroup(AgentMatcher.AgentActionScheduler);

            foreach (AgentEntity entity in group)
            {
                if (entity.agentActionScheduler.ActiveActionIDs.Count == 0 && entity.hasAgentAIController)
                {
                    if (entity.agentAIController.ActionIDs.Count == 0)
                        continue;
                    ScheduleAction(entity);
                }
                ExcuteActions(contexts, entity, deltaTime, ref planet);
            }
        }

        private void ExcuteActions(Contexts contexts, AgentEntity actorEntity, float deltaTime, ref Planet.PlanetState planet)
        {
            for (int i = 0; i < actorEntity.agentActionScheduler.ActiveActionIDs.Count; i++)
            {
                int actionID = actorEntity.agentActionScheduler.ActiveActionIDs[i];
                ActionEntity actionEntity = contexts.action.GetEntityWithActionIDID(actionID);

                if (actionEntity.hasActionExecution)
                {
                    switch (actionEntity.actionExecution.State)
                    {
                        case Enums.ActionState.Entry:
                            actionEntity.actionExecution.Logic.OnEnter(ref planet);
                            break;
                        case Enums.ActionState.Running:
                            actionEntity.actionExecution.Logic.OnUpdate(deltaTime, ref planet);
                            break;
                        case Enums.ActionState.Success:
                            actionEntity.actionExecution.Logic.OnExit(ref planet);
                            actorEntity.agentActionScheduler.ActiveActionIDs.RemoveAt(i--);
                            break;
                        case Enums.ActionState.Fail:
                            actionEntity.actionExecution.Logic.OnExit(ref planet);
                            actorEntity.agentActionScheduler.ActiveActionIDs.RemoveAt(i--);
                            break;
                        default:
                            Debug.Log("Not valid Action state.");
                            break;
                    }
                }

                /* Code to test AIGridWorld
                if (actionDeltaTime > ActionEntity.actionTime.Duration && actionDeltaTime != -1f)
                {
                    var Effects = ActionEntity.actionGoap.Effects;

                    // Todo: Create state class with get method.
                    if (Effects.states.ContainsKey("pos"))
                        ActorEntity.ReplaceAgentPositionDiscrete2D((Vector2Int)ActionEntity.actionGoap.Effects.states["pos"], Vector2Int.zero);
                    else
                        Debug.Log("There is no key called pos.");

                    // Action Complete remove it from list.
                    ActorEntity.agentActionScheduler.ActiveActionIDs.RemoveAt(i);
                }
                */
            }
        }
        private void ScheduleAction(AgentEntity agentEntity)
        {
            int actionID = agentEntity.agentAIController.ActionIDs.Dequeue();  // Get Next Action.
            agentEntity.agentActionScheduler.ActiveActionIDs.Add(actionID);
        }

        public void ScheduleAction(AgentEntity agentEntity, int actionID)
        {
            agentEntity.agentActionScheduler.ActiveActionIDs.Add(actionID);
        }
    }
}
