using System.Collections.Generic;
using BehaviorTree;

public class PlayerBT : Tree
{
    //public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;

    public UnityEngine.Transform _Camera;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        new CheckSprintPressed(transform),
                        new TaskSprinting(transform, _Camera),

                    }),
                    new Sequence(new List<Node>
                    {
                        new CheckMovementPressed(transform),
                        new TaskMovement(transform, _Camera),

                    }),

                }),

            }),
            new TaskIdle(transform),

        });;

        return root;
    }
}