using System;
using System.Collections.Generic;
using System.Text;

public class Tuple<T1, T2>
{
    private T1 itemOne;
    private T2 itemTwo;

    public Tuple(T1 item1, T2 item2)
    {
        this.itemOne = item1;
        this.itemTwo = item2;
    }

    public override string ToString()
    {
        return $"{itemOne} -> {itemTwo}";
    }
}