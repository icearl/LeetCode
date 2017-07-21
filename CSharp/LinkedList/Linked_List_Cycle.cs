using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//141. 判断链表是否有环 Linked List Cycle
//方一：哈希表（还没看）
//方二：快慢指针
namespace LinkedList {
    class Linked_List_Cycle {
        // 方二：快慢指针
        public static bool hasCycle(ListNode head) {

            // slow 一次一步， fast 一次两步。fast如果能追上贼有环，如果fast = null 或 fast.next = null 那么就无环，因为fast指针比slow指针走得快，所以只要判断fast指针是否为空就好。
            // 由于fast指针一次走两步，fast.next可能已经为空（当fast为尾结点时），
            // fast.next.next将会导致NullPointerException异常，所以在while循环中我们要判断fast.next是否为空；

            //这里fast的判断要先放到前面，这样在fast为null时便可直接退出循环，从而不访问fast.next
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
                // 追上了就有环
                if (slow == fast) {
                    return true;
                }
            }
            // 否则（即 fast = null 或 fast.next = null）无环
            return false;
        }
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(5);
            ListNode node5 = new ListNode(4);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            //node7.next = node1;
            bool tempBool = hasCycle(node1);
            Console.WriteLine("has circle? " + tempBool);
        }
    }
}
