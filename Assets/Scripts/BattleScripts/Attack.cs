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
}

public class Attack
{
    private readonly AttackStep attackStep;

    public Attack(AttackStep attackStep) {
        this.attackStep = attackStep;
    }

    public Attack(Part firstPart) : this(new AttackStep(firstPart, null)) { }

    public AttackStep GetAttackStep() {
        return attackStep;
    }

    public float GetPrecision()
    {
        throw new NotImplementedException();
    }

    public float GetStrength()
    {
        throw new NotImplementedException();
    }
}
