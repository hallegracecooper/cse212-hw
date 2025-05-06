public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
{
    // Step 1: Create an array of doubles with the size equal to 'length'.
    // Step 2: Use a loop that runs from 0 to length - 1.
    // Step 3: On each iteration, calculate the multiple by multiplying 'number' by (i + 1).
    //         This gives: number * 1, number * 2, ..., up to number * length.
    // Step 4: Store each multiple in the array.
    // Step 5: Return the array.

    double[] multiples = new double[length];

    for (int i = 0; i < length; i++)
    {
        multiples[i] = number * (i + 1);
    }

    return multiples;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
{
    // Step 1: Determine the index where the rotation should split the list.
    int splitIndex = data.Count - amount;

    // Step 2: Get the two slices of the list.
    List<int> rightSlice = data.GetRange(splitIndex, amount);
    List<int> leftSlice = data.GetRange(0, splitIndex);

    // Step 3: Clear the original list.
    data.Clear();

    // Step 4: Add the right slice to the front of the list.
    data.AddRange(rightSlice);

    // Step 5: Add the left slice after the right slice.
    data.AddRange(leftSlice);
}
}
