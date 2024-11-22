using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public List<Vector2> controlSpeed;
        public float startSpeed = 5;
        public float distanceTravelled;

        float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }

        float CalculatePercentage(float min, float max, float value)
        {
            if (Mathf.Approximately(max, min))
            {
                return 0f;
            }
            return (value - min) / (max - min);
        }

        float GetSpeed()
        {
            float speed = startSpeed;

            if (controlSpeed == null || controlSpeed.Count == 0)
            {
                return speed;
            }

            if (distanceTravelled <= controlSpeed[0].x)
            {
                return controlSpeed[0].y;
            }

            Vector2 prev = controlSpeed[0];
            for (int i = 1; i < controlSpeed.Count; i++)
            {
                Vector2 current = controlSpeed[i];
                if (distanceTravelled < current.x)
                {
                    speed = Lerp(prev.y, current.y, CalculatePercentage(prev.x, current.x, distanceTravelled));
                    return speed;
                }
                prev = current;
            }

            return controlSpeed[controlSpeed.Count - 1].y;
        }

        void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += GetSpeed() * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}