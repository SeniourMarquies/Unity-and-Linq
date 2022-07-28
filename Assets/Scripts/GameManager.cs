using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    // We gonna see basic linq stuff usage with Unity 
    // to simplify works...


    [SerializeField] Vector3 targetPoints;
    [SerializeField] float maxRange;
    void Start()
    {
        // Instead this
       // List<NPC> allNPCs = new List<NPC>(FindObjectsOfType<NPC>());

        // Do this...
        List<NPC> allNPCs = FindObjectsOfType<NPC>().ToList();
        

        // Find npcs that's life bigger than 80 and add them to var as list.
        var highHealthNPCs = allNPCs.Where(npc => npc.CurrentHealth >= 80f).ToList();
        foreach (var npc in highHealthNPCs)
        {
            Debug.Log($"{npc.gameObject.name} : {npc.CurrentHealth}");
        }
        // Find npcs that is life lesser than 50 and ordered by health adding them to var as list.
        var lowHealthNPCs = allNPCs.Where(npc => npc.CurrentHealth <= 50).OrderBy(npc => npc.CurrentHealth).ToList();

        foreach (var npc in lowHealthNPCs)
        {
            Debug.Log($"{npc.gameObject.name} : {npc.CurrentHealth}");
        }


        // Let's find all npc names and store them into a variable as list...

        var allNPCsNames = allNPCs.OrderBy(npc=> npc.CurrentHealth).Select(npc => npc.gameObject.name).ToList();
        foreach (var npcName in allNPCsNames)
        {
            Debug.Log($"Npc name is : {npcName}");
        }

        // Get all npc near target point within range and sorted by range...
        var NpcSortedByDistance = allNPCs.Where(npc => Vector3.Distance(targetPoints, npc.transform.position) <= maxRange)
                                        .OrderBy(npc => Vector3.Distance(targetPoints, npc.transform.position)).ToList();
        foreach (var npc in NpcSortedByDistance)
        {
            Debug.Log(npc.gameObject.name + " + " + Vector3.Distance(targetPoints, npc.transform.position).ToString());
        }
        // Get all npc that startswith "NPC...
        var NpcOfNames = allNPCs.Where(npc => npc.gameObject.name.StartsWith("NPC")).ToList();
        Debug.Log("-------------------");
        foreach (var npc in NpcOfNames)
        {
            Debug.Log(npc.gameObject.name);
        }

        // Do not forget that using linq in your big project can be costly,
        // it is generalley better for prototyping projects.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
