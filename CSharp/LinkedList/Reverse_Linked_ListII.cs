using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**第92题 链表部分倒序 Reverse Linked List II
 * Reverse a linked list from position m to n. Do it in-place and in one-pass.
     For example:
     Given 1->2->3->4->5->NULL, m = 2 and n = 4,
     return 1->4->3->2->5->NULL.
     Note:
     Given m, n satisfy the following condition:
     1 ≤ m ≤ n ≤ length of list.
 
 */


namespace LinkedList {
    class Reverse_Linked_ListII {
        public ListNode ReverseBetween(ListNode head, int m, int n) {
            if(head == null || head.next == null) {
                return head;
            }

            ListNode nil = new ListNode(0);
            nil.next = head;
            ListNode p = nil;
            // p 往前走，走到第 m - 1 个
            for(int i = 1; i < m; i++) {
                p = p.next;
            }
            ListNode before = p;

            //这里是把m,n之间（包括 m，n）的节点全部从原链表拉出来倒序排
            ListNode prev = null;
            ListNode newHead = p.next, newTail = p.next;
            
            for (int i = m; i <= n; i++) {
                ListNode nextTemp = newHead.next;

                newHead.next = prev;

                prev = newHead;
                newHead = nextTemp;
            }
            // 第 n + 1 个节点
            ListNode after = newHead;
           //连起来
            before.next = prev;
            newTail.next = after;
            //这里不能是head，否则当m=1时，head并不是链表头
            return nil.next;
        }
        //test
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(4);
            //ListNode node5 = new ListNode(5);
            node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;
            ListNode p = ReverseBetween(node1, 1, 2);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
