using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**第142题 Linked List Cycle II 快慢指针变形
 * Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
     Note: Do not modify the linked list.
     Follow up:
     Can you solve it without using extra space?
 
 */

// 快慢指针
// 关于这道题的解释和变形参考http://blog.sina.com.cn/s/blog_6f611c300101fs1l.html
// 本解利用的是方法 3

namespace LinkedList {
    class Linked_List_Cycle_II {
        public ListNode DetectCycle(ListNode head) {
            ListNode slow = head;
            ListNode fast = head;
            bool flag = false;

            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                slow = head;
                while (slow != fast) {
                    slow = slow.next;
                    fast = fast.next;
                }
                return slow;
            } else {
                return null;
            }
        }
        //test
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node4;
            //node7.next = node1;
            ListNode temp = DetectCycle(node1);
            Console.WriteLine("first of the circle: " + temp.val);
        }
    }
}
