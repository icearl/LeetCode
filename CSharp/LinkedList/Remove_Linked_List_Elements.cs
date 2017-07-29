using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
203. 去掉链表中 val 为某值的所有元素 Remove Linked List Elements
namespace LinkedList {
    class Remove_Linked_List_Elements {
        public ListNode RemoveElements(ListNode head, int val) {
            ListNode nil = new ListNode(-1);
            nil.next = head;

            ListNode pre = nil;
            ListNode cur = nil.next;
            while(cur != null) {
                if(cur.val == val) {
                    pre.next = cur.next;

                    cur = cur.next;
                } else {
                    pre = cur;
                    cur = cur.next;
                }
            }
            return nil.next;
        }
        // test
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(4);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(4);
            ListNode node7 = new ListNode(7);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            ListNode p = RemoveElements(node1,4);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
