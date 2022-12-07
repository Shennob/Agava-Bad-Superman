using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using HelpURL = BehaviorDesigner.Runtime.Tasks.HelpURLAttribute;

namespace BehaviorDesigner.Runtime.Tactical.Tasks
{
    [TaskCategory("Tactical")]
    [TaskDescription("Moves to the closest target and starts attacking as soon as the agent is within distance")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-tactical-pack/")]
    [TaskIcon("Assets/Behavior Designer Tactical/Editor/Icons/{SkinColor}AttackIcon.png")]
    public class Attack : NavMeshTacticalGroup
    {
        public override TaskStatus OnUpdate()
        {
            var baseStatus = base.OnUpdate();
            Animator animator = gameObject.GetComponent<Animator>();

            if (baseStatus != TaskStatus.Running || !started) {
                animator.SetBool("IsPistolIdle", true);
                return baseStatus;
            }

            if (MoveToAttackPosition()) {
                tacticalAgent.TryAttack();
                animator.SetBool("IsPistolIdle", true);
            }

            if(baseStatus == TaskStatus.Running)
            {
                animator.SetBool("IsPistolWalk", true);
                animator.SetBool("IsPistolIdle", false);
            }

            Debug.Log(baseStatus);

            return TaskStatus.Running;
        }
    }
}