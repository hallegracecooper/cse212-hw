using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and verify highest priority is dequeued first
    // Expected Result: Items should be dequeued in order of priority (highest first): "C", "B", "A"
    // Defect(s) Found: The Dequeue method has an off-by-one error in its loop condition, causing it to miss checking the last item in the queue
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue(), "Highest priority (3) should be dequeued first");
        Assert.AreEqual("B", priorityQueue.Dequeue(), "Second highest priority (2) should be dequeued second");
        Assert.AreEqual("A", priorityQueue.Dequeue(), "Lowest priority (1) should be dequeued last");
    }

    [TestMethod]
    // Scenario: Add multiple items with same priority and verify FIFO order is maintained
    // Expected Result: Items with same priority should be dequeued in the order they were added: "A", "B", "C"
    // Defect(s) Found: The implementation uses >= for priority comparison which violates FIFO order for equal priorities
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue(), "First item added should be dequeued first when priorities are equal");
        Assert.AreEqual("B", priorityQueue.Dequeue(), "Second item added should be dequeued second when priorities are equal");
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Third item added should be dequeued last when priorities are equal");
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - empty queue case is handled correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Should have thrown an exception for empty queue");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Mix of same and different priorities to test both priority ordering and FIFO behavior
    // Expected Result: Items should be dequeued in order: "D", "A", "B", "C"
    // Defect(s) Found: Multiple defects: 1) Off-by-one error in loop 2) Incorrect handling of equal priorities
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 3);

        Assert.AreEqual("D", priorityQueue.Dequeue(), "Highest priority (3) should be dequeued first");
        Assert.AreEqual("A", priorityQueue.Dequeue(), "First item with priority 2 should be dequeued second");
        Assert.AreEqual("B", priorityQueue.Dequeue(), "Second item with priority 2 should be dequeued third");
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Lowest priority (1) should be dequeued last");
    }

    // Add more test cases as needed below.
}