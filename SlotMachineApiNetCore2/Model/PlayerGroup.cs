namespace SlotMachineApiNetCore2.Model
{
    public enum PlayerGroup
    {
        // answer GRCS questions only
        Control = 1,
        // see the fact/fiction messages then answer the GRCS questions
        Information = 2,
        // see how long they have been playing and how many bets they have made then answer the GRCS questions
        SelfAppraisal = 3
    }
}