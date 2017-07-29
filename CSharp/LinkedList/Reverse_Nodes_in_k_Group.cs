using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**25. 每K个为一组进行逆转，最后剩下的不逆转 Reverse Nodes in k-Group   
 * Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
     k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
     You may not alter the values in the nodes, only nodes itself may be changed.
     Only constant memory is allowed.
     For example,
     Given this linked list: 1->2->3->4->5
     For k = 2, you should return: 2->1->4->3->5
     For k = 3, you should return: 3->2->1->4->5
 */
namespace LinkedList {
    class Reverse_Nodes_in_k_Group {
        public ListNode ReverseKGroup(ListNode head, int k) {
            if (head == null || head.next == null) {
                return head;
            }
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            int count = 0;
            ListNode pre = dummy;
            ListNode cur = head;
            while (cur != null) {
                count++;
                ListNode next = cur.next;
                if (count % k == 0) {
                    pre = ReverseBetween2(pre, next);
                }
                cur = next;
            }
            return dummy.next;
        }
        /**w
        * Reverse a link list between pre and next exclusively
        * an example:
        * a linked list:
        * 0->1->2->3->4->5->6
        * |           |
        * pre        next
        * after call pre = reverse(pre, next)
        *
        * 0->3->2->1->4->5->6
        *          |  |
        *          pre next
        */
        private ListNode ReverseBetween(ListNode pre, ListNode next) {
            ListNode last = pre.next; 
            ListNode cur = last.next;
            while (cur != next) {
                //            ListNode p = cur.next;
                //            cur.next=pre.next;
                //            pre.next=cur;
                //            cur=p;
                last.next = cur.next;
                cur.next = pre.next;
                pre.next = cur;
                cur = last.next;
            }
            //        last.next=next;
            return last;
        }
        //好理解的前插法
        private ListNode ReverseBetween2(ListNode pre, ListNode next) {
            ListNode prev = null;
            ListNode cur = pre.next;
            while (cur != next) {
                ListNode nextTemp = cur.next;

                cur.next = prev;

                prev  = cur;
                cur = nextTemp;
            }
            
            pre.next.next = cur;
            ListNode last = pre.next;
            pre.next = prev;
            ListNode first = prev;

            return last;
        }
        // test
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
            ListNode p = ReverseKGroup(node1, 3);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
