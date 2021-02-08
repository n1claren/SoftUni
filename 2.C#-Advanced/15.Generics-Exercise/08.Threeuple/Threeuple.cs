public class Threeuple<T1, T2, T3>
{
    private T1 itemOne;
    private T2 itemTwo;
    private T3 itemThree;

    public Threeuple(T1 itemOne, T2 itemTwo, T3 itemThree)
    {
        this.itemOne = itemOne;
        this.itemTwo = itemTwo;
        this.itemThree = itemThree;
    }

    public override string ToString()
    {
        return $"{itemOne} -> {itemTwo} -> {itemThree}";
    }
}