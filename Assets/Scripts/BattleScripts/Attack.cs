using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStep {
    private Part attackingPart;
    private Part previousPart;
    private List<AttackStep> nextAttacks;

    public AttackStep(Part attackingPart, Part previousPart, List<AttackStep> nextAttacks = null) {
        this.attackingPart = attackingPart;
        this.previousPart = previousPart;
        if (nextAttacks == null) {
            nextAttacks = new List<AttackStep>();
        }
    }

    public Part GetPart() {
        return attackingPart;
    }

    public List<AttackStep> GetNextAttacks() {
        return nextAttacks;
    }

    public void SetNextAttacks(List<AttackStep> nextAttacks) {
        this.nextAttacks = nextAttacks;
    }

    public void AddNextPart(Part nextPart) {
        nextAttacks.Add(new AttackStep(nextPart, attackingPart));
    }

    internal float GetStrength() {//does not require loop guard, because attacks should not be able to trigger loops
        float totalStrength = attackingPart.GetStrength();
        foreach (AttackStep step in nextAttacks) { 
            totalStrength += step.GetStrength(); 
        }
        return totalStrength / nextAttacks.Count;
    }

    internal float GetPrecision() {
        float totalPrecision = attackingPart.GetPrecision();
        foreach (AttackStep step in nextAttacks) {
            totalPrecision *= step.GetPrecision();
        }
        return totalPrecision / nextAttacks.Count;
    }

    internal void GetFinalParts(ref List<Part> finalparts) {
        if (nextAttacks.Count == 0) {
            finalparts.Add(GetPart());
        } else {
            foreach (AttackStep step in nextAttacks) {
                step.GetFinalParts(ref finalparts);
            }
        }
    }
}

public class Attack {
    private readonly AttackStep attackStep;
    private Creature attackedCreature;
    private List<Part> attackedParts;

    public Attack(AttackStep attackStep) {
        this.attackStep = attackStep;
    }

    public Attack(Part firstPart) : this(new AttackStep(firstPart, null)) { }

    public AttackStep GetAttackStep() {
        return attackStep;
    }

    public void SetAttackedCreatureAndParts(Creature creature, List<Part> part) {
        attackedCreature = creature;
        attackedParts = part;
    }

    public List<Part> GetAttackedPart() {
        return attackedParts;
    }

    public Creature GetAttackedCreature() {
        return attackedCreature;
    }

    public float GetPrecision() {
        return attackStep.GetPrecision();
    }

    public float GetStrength() {
        return attackStep.GetStrength();
    }

    internal List<Part> GetFinalParts() {
        List<Part> finalparts = new List<Part>();
        attackStep.GetFinalParts(ref finalparts);
        return finalparts;
    }
}
