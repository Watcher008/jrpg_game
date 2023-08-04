using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private Transform[] playerPositions;
    [SerializeField] private Transform[] enemyPositions;

    private List<Combatant> combatants = new List<Combatant>();
    private List<Combatant> playerCombatants = new List<Combatant>();
    private List<Combatant> enemyCombatants = new List<Combatant>();
    private int turnIndex = 0;

    public void SetCombatants(List<Combatant> enemies, List<Combatant> players)
    {
        combatants.Clear();
        playerCombatants.Clear();
        enemyCombatants.Clear();
        turnIndex = 0;

        for (int i = 0; i < players.Count; i++)
        {
            //Instantiate combat prefab at position
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            //Instantiate combat prefab at position
        }

        combatants.AddRange(players);
        combatants.AddRange(enemies);
        playerCombatants.AddRange(players);
        enemyCombatants.AddRange(enemies);

        //Sorts combatants based on Speed
        combatants.Sort();

        OnStartTurn(combatants[turnIndex]);
    }


    private void OnStartTurn(Combatant character)
    {
        //if enemy combatant, run AI

        //else if player then wait for input
    }

    private void OnEndTurn(Combatant character)
    {

        IterateTurn();
    }

    private void IterateTurn()
    {
        turnIndex++;
        if(turnIndex >= combatants.Count) turnIndex = 0;
        OnStartTurn(combatants[turnIndex]);
    }

    private void OnCharacterDefeated(Combatant character)
    {
        //Character died on their own turn, end it and proceed to the next character
        bool endTurn = false;
        if (combatants[turnIndex] == character)
        {
            endTurn = true;
        }

        combatants.Remove(character);

        //Probably wait for a deat animation to play

        //If it is an enemy, add their xp to some pool, or just store all initial enemies

        if (AllEnemiesDefeated()) OnPlayerVictory();
        else if (AllPlayersDefeated()) OnPlayerDefeat();
        else if (endTurn) OnEndTurn(character);
    }

    private bool AllEnemiesDefeated()
    {
        for (int i = 0; i < enemyCombatants.Count; i++)
        {
            if (enemyCombatants[i].Stats.currentHealth > 0) return false;
        }

        return true;
    }

    private bool AllPlayersDefeated()
    {
        for (int i = 0; i < playerCombatants.Count; i++)
        {
            if (playerCombatants[i].Stats.currentHealth > 0) return false;
        }

        return true;
    }

    private void OnPlayerVictory()
    {
        //Grant xp for each enemy

        //Unload scene
    }

    private void OnPlayerDefeat()
    {
        //Reload last save?
    }
}
