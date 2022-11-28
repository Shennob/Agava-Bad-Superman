using GleyTrafficSystem;
using System.Collections.Generic;
using UnityEngine;

namespace GleyUrbanAssets
{
    public partial class CurrentSceneData : MonoBehaviour
    {
        public Waypoint[] allWaypoints;
        public IntersectionData[] allIntersections;
        public PriorityIntersection[] allPriorityIntersections;
        public TrafficLightsIntersection[] allLightsIntersections;
    }
}