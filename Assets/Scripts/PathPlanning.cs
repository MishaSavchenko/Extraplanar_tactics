using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPlanning
{
    public float heuristic(MapNode a, MapNode b)
    {
        return 0.0f;
    }

    public float cost(MapNode a)
    {
        return 0.0f;
    }

    public PathPlanning() {

        //PriortiyQueue<MapNode, float> frontier = new PriorityQueue<MapNode, float>();
        SortedList<MapNode, float> frontier = new SortedList<MapNode, float>();
        MapNode start = new MapNode("test_node", new Vector3(0.0f,0.0f,0.0f), new Color(0.0f,0.0f,0.0f,1.0f));
        MapNode goal = new MapNode("test_node", new Vector3(0.0f, 0.0f,0.0f), new Color(0.0f,0.0f,0.0f,1.0f));

        frontier.Add(start, 0);
        Dictionary<MapNode, float> came_from = new Dictionary<MapNode, float>();
        Dictionary<MapNode, float> cost_so_far = new Dictionary<MapNode, float>();

        //came_from[start] = null;
        cost_so_far[start] = 0;

        List<MapNode> graph;

        while (frontier.Count != 0)
        {
            //MapNode current = frontier.get();
            MapNode current = frontier.Keys[0];
            frontier.RemoveAt(0);

            if (current == goal)
            {
                break;
            }

            // Get neightbors of the current node from the map
            // neighbors = graph.neighbors(current);
            List<MapNode> neighbors;

            foreach (MapNode next in neighbors)
            {
                float new_cost = cost_so_far[current] + graph.cost(current, next);

                if (!cost_so_far.ContainsKey(next) || new_cost < cost_so_far[next])
                {
                    cost_so_far[next] = new_cost;
                    float priority = new_cost + heuristic(goal, next);
                    frontier.Add(next, priority);
                    came_from[next] = current;
                }
            }
        }
    }

}
