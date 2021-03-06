using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using UnityEngine;

namespace ECSTween
{
    // Removes all entities ( not gameObjects ) that have TweenRange beyond their lifetime
    [UpdateAfter(typeof(TweenCompleteSystem))]
    public class TweenRemoveSystem : ComponentSystem
    {
        public struct Data
        {
            public readonly int Length;
            [ReadOnly] public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<TweenComplete> _;
        }

        [Inject] private Data m_Data;

        protected override void OnUpdate()
        {
            var time = Time.time;
            var deltaTime = Time.deltaTime;

            for (int i = 0; i < m_Data.Length; ++i)
            {
                PostUpdateCommands.DestroyEntity(m_Data.Entities[i]);
            }
        }
    }
}