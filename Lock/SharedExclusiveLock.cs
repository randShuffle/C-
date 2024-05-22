using System;
using System.Text;
using System.Threading;
namespace Synchronization
{
    public class SharedExclusiveLock
    {
        private volatile LockNode listHead;
        private volatile LockNode listTail;
        private volatile Thread currentOwner;
        private volatile int entryCount;

        public SharedExclusiveLock()
        {
        }

        public void LockExclusive()
        {
            LockNode current = null;
            lock (this)
            {
                if (listHead == null)
                {
                    listHead = new LockNode();
                }
            }
            lock (this)
            {
                if (listTail == null)
                {
                    AppendWhenTailEmpty(LockNode.NODE_EXCLUSIVE);
                    return;
                }
            }
            lock (this)
            {
                if (currentOwner == Thread.CurrentThread)
                {
                    entryCount += 1;
                    return;
                }
                else
                {
                    LockNode t = listTail;
                    if (t == null)
                    {
                        AppendWhenTailEmpty(LockNode.NODE_EXCLUSIVE);
                        return;
                    }
                    else
                        current = Append(LockNode.NODE_EXCLUSIVE);
                }
            }
            while (current.status != LockNode.STATE_SIGNAL) { }
            entryCount = 1;
            current.status = LockNode.STATE_RUNNING;
            currentOwner = Thread.CurrentThread;
        }
        public void UnlockExclusive()
        {
            lock (this)
            {
                entryCount -= 1;
                LockNode node = GetNextNode();
                if (node != null)
                {
                    if (entryCount == 0)
                    {
                        node.status = LockNode.STATE_CANCELLED;
                        SignalNext();
                    }
                }
            }
        }
        public void LockShared()
        {
            LockNode reader = null;
            lock (this)
            {
                if (listHead == null)
                {
                    listHead = new LockNode();
                }
            }
            Thread currentThread = Thread.CurrentThread;
            lock (this)
            {
                if (listTail == null)
                {
                    AppendWhenTailEmpty(LockNode.NODE_SHARED);
                    return;
                }
            }
            LockNode current = null;
            lock (this)
            {
                if (CanReenterShared())
                {
                    entryCount += 1;
                    return;
                }
                LockNode node = listHead.next;
                if (node == null)
                {
                    AppendWhenTailEmpty(LockNode.NODE_SHARED);
                    return;
                }
                else
                {
                    if (WriterExists())
                    {
                        reader = new LockNode(currentThread, LockNode.NODE_SHARED);
                        while (node != null && (!node.isNodeShared() || node.status == LockNode.STATE_CANCELLED))
                        {
                            if (node.isNodeShared())
                            {
                                if (!IsReadChainDone(node))
                                    break;
                                else
                                    node = node.next;
                            }
                            else
                                node = node.next;
                        }
                        if (node == null)
                        {
                            current = Append(LockNode.NODE_SHARED);
                        }
                        else
                        {
                            if (node.countReaders < LockNode.ReadThreshold)
                            {
                                current = AddToReadChain(node, reader);
                                if (node.status == LockNode.STATE_RUNNING)
                                {
                                    reader.status = LockNode.STATE_RUNNING;
                                    entryCount += 1;
                                    return;
                                }
                            }
                            else
                            {
                                LockNode t = listTail;
                                if (!t.isNodeShared() || (t.isNodeShared() && t.countReaders >= LockNode.ReadThreshold))
                                    current = Append(LockNode.NODE_SHARED);
                                else
                                {
                                    current = AddToReadChain(t, reader);
                                    if (t.status == LockNode.STATE_RUNNING)
                                    {
                                        reader.status = LockNode.STATE_RUNNING;
                                        entryCount += 1;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (listTail == null)
                        {
                            AppendWhenTailEmpty(LockNode.NODE_SHARED);
                            return;
                        }
                        if (listTail.countReaders < LockNode.ReadThreshold)
                        {
                            reader = new LockNode(currentThread, LockNode.NODE_SHARED);
                            current = AddToReadChain(listTail, reader);
                            if (listTail.status == LockNode.STATE_RUNNING)
                            {
                                reader.status = LockNode.STATE_RUNNING;
                                entryCount += 1;
                                return;
                            }
                        }
                        else
                        {
                            current = Append(LockNode.NODE_SHARED);
                        }
                    }
                }
            }
            while (current.status != LockNode.STATE_SIGNAL) { }
            current.status = LockNode.STATE_RUNNING;
            entryCount = current.headReader.countReaders;
            currentOwner = current.headReader == null ? null : current.headReader.currentThread;
        }
        public void UnlockShared()
        {
            lock (this)
            {
                entryCount -= 1;
                LockNode node = listHead.next;
                while (node != null)
                {
                    if (IsReadChainDone(node))
                    {
                        node = node.next;
                        listHead.next = node;
                        if (node != null)
                            node.previous = listHead;
                    }
                    else
                        break;
                }
                if (node != null)
                {
                    node = GetReaderNode(node);
                    node.status = LockNode.STATE_CANCELLED;
                    if (entryCount == 0)
                        SignalNext();
                }
            }
        }
        private void SignalNext()
        {
            LockNode node = GetNextNode();
            if (node == null)
            {
                listTail = null;
                currentOwner = null;
                entryCount = 0;
                return;
            }
            else
            {
                node.previous = listHead;
                entryCount = node.countReaders;
                while (node != null)
                {
                    node.status = LockNode.STATE_SIGNAL;
                    node = node.subsequentReader;
                    if (node != null)
                        node.previous = listHead;
                }
            }
        }
        private LockNode GetNextNode()
        {
            LockNode node = listHead.next;
            while (node != null && node.status == LockNode.STATE_CANCELLED)
            {
                node = node.next;
            }
            listHead.next = node;
            if (node != null)
                node.previous = listHead;
            return node;
        }
        private bool WriterExists()
        {
            bool hasExclusive = false;
            LockNode exclusiveNode = listHead.next;
            while (exclusiveNode != null)
            {
                if (!exclusiveNode.isNodeShared())
                {
                    hasExclusive = true;
                    break;
                }
                exclusiveNode = exclusiveNode.next;
            }
            return hasExclusive;
        }
        private LockNode Append(LockNode nodeType)
        {
            LockNode t = listTail;
            LockNode node = new LockNode(Thread.CurrentThread, nodeType);
            t.next = node;
            node.previous = t;
            listTail = node;
            node.status = LockNode.STATE_WAITING;
            if (node.isNodeShared())
                node.headReader = node;
            return node;
        }
        private void AppendWhenTailEmpty(LockNode nodeType)
        {
            LockNode node = new LockNode(Thread.CurrentThread, nodeType);
            node.status = LockNode.STATE_RUNNING;
            listTail = node;
            currentOwner = Thread.CurrentThread;
            entryCount = 1;
            listHead.next = node;
            node.previous = listHead;
            if (node.isNodeShared())
                node.headReader = node;
        }
        private LockNode GetReaderNode(LockNode node)
        {
            LockNode subsequentReader = node.headReader;
            while (subsequentReader != null)
            {
                if (subsequentReader.currentThread.Name.Equals(Thread.CurrentThread.Name))
                    return subsequentReader;
                else
                    subsequentReader = subsequentReader.subsequentReader;
            }
            return null;
        }
        private bool IsReadChainDone(LockNode node)
        {
            LockNode subsequentReader = node.headReader;
            while (subsequentReader != null)
            {
                if (subsequentReader.status != LockNode.STATE_CANCELLED)
                    return false;
                else
                    subsequentReader = subsequentReader.subsequentReader;
            }
            return true;
        }
        private LockNode AddToReadChain(LockNode headReader, LockNode node)
        {
            LockNode readerTail = headReader;
            while (readerTail.subsequentReader != null)
            {
                readerTail = readerTail.subsequentReader;
            }
            node.previous = readerTail.previous;
            readerTail.subsequentReader = node;
            node.headReader = headReader;
            node.status = headReader.status;
            headReader.countReaders++;
            return node;
        }
        private bool CanReenterShared()
        {
            LockNode node = listHead.next;
            if (node == null || !node.isNodeShared())
                return false;
            else
            {
                LockNode reader = node;
                while (reader != null)
                {
                    if (reader.currentThread == Thread.CurrentThread)
                    {
                        return true;
                    }
                    reader = reader.subsequentReader;
                }
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (listHead != null)
            {
                if (currentOwner != null)
                    sb.Append("Head(Owner Thread:" + currentOwner.Name + ", Entry Count:" + entryCount + ")\n");
                else
                    sb.Append("Head(Owner Thread: None, Entry Count:" + entryCount + ")\n");
                LockNode node = listHead.next;
                while (node != null)
                {
                    LockNode reader = node;
                    if (node.isNodeShared())
                    {
                        while (reader != null)
                        {
                            sb.AppendFormat("-> [Thread Name:{0}, Type: Read, Status:{1}]", reader.currentThread.Name, LockNode.DescribeStatus(reader.status));
                            reader = reader.subsequentReader;
                        }
                        sb.AppendLine();
                    }
                    else
                    {
                        sb.AppendFormat("-> [Thread Name:{0}, Type: Write, Status:{1}]", node.currentThread.Name, LockNode.DescribeStatus(node.status));
                        sb.AppendLine();
                    }
                    node = node.next;
                }
            }
            return sb.ToString();
        }
        public void DisplayQueue()
        {
            Console.WriteLine(ToString());
        }
        public void DebugLockOperation(bool isLocked, bool isNodeShared)
        {
            if (isNodeShared)
            {
                if (isLocked)
                    Console.WriteLine(Thread.CurrentThread.Name + ": Acquired Read Lock");
                else
                    Console.WriteLine(Thread.CurrentThread.Name + ": Released Read Lock");
            }
            else
            {
                if (isLocked)
                    Console.WriteLine(Thread.CurrentThread.Name + ": Acquired Write Lock");
                else
                    Console.WriteLine(Thread.CurrentThread.Name + ": Released Write Lock");
            }
        }
    }
}