using System;
using System.Threading;
namespace Synchronization
{
    public class LockNode
{
    // Shared node instance
    public static readonly LockNode NODE_SHARED = new LockNode();
    // Exclusive node instance
    public static readonly LockNode NODE_EXCLUSIVE = null;
    // Threshold for read chain length
    public static int ReadThreshold = 5;

    // Node states
    public static readonly int STATE_CANCELLED = 1;
    public static readonly int STATE_RUNNING = -1;
    public static readonly int STATE_WAITING = -2;
    public static readonly int STATE_SIGNAL = -3;


    // Node waiting status
    public int status;

    // Predecessor node
    public LockNode previous;
    // Successor node
    public LockNode next;
    // Thread that owns the node
    public Thread currentThread;

    // The following are applicable only for read nodes
    // Head of the read chain
    public LockNode headReader;
    // Next read node in the chain
    public LockNode subsequentReader;
    // Length of the read chain
    public int countReaders = 1;

    // Node type (shared or exclusive)
    public LockNode nodeType;

 


    // Constructor for creating a node
    public LockNode()
    {
    }

    // Constructor for shared or exclusive node
    public LockNode(Thread threadToHold, LockNode type)
    {
        this.nodeType = type;
        this.currentThread = threadToHold;
    }

    // Method to check if node is shared
    public bool isNodeShared()
    {
        return nodeType == NODE_SHARED;
    }

    // Method to get status description
    public static string DescribeStatus(int statusCode)
    {
        switch (statusCode)
        {
            case 1:
                return "CANCELLED";
            case -1:
                return "RUNNING";
            case -2:
                return "WAITING";
            case -3:
                return "SIGNAL";
            default:
                return "UNKNOWN";
        }
    }
}
}
