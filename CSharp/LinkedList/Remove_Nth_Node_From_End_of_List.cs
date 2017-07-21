using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 19 移除链表倒数第 n 个节点 Remove Nth Node From End of List 链表快慢指针得到边界条件
Given a linked list, remove the nth node from the end of list and return its head.

For example,
Given linked list: 1->2->3->4->5, and n = 2.
After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:
Given n will always be valid.
Try to do this in one pass.

 */
namespace LinkedList {
    class Remove_Nth_Node_From_End_of_List {
        // 方一：
        // 倒数第 n 个就是正数第 length - n + 1  个
        // 遍历一次得到 length，再遍历一次得到第 length - n 个node，然后跳过 next 就好了
        public ListNode RemoveNthFromEnd1(ListNode head, int n) {
            ListNode nil = new ListNode(0);
            nil.next = head;
            int length = 0;
            ListNode first = head;
            while (first != null) {
                length++;
                first = first.next;
            }
            length -= n;
            first = nil;
            while (length > 0) {
                length--;
                first = first.next;
            }
            first.next = first.next.next;
            return nil.next;
        }
        // 方二：前后双指针 
        // 两指针隔 n + 1 个，第二个指针为 null 的时候，第一个就是倒数第 n + 1 个，把倒数第 n + 1 的 next 后移两个即可
        public ListNode RemoveNthFromEnd2(ListNode head, int n) {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            ListNode second = dummy;
            // Advances first pointer so that the gap between first and second is n nodes apart
            for (int i = 1; i <= n + 1; i++) {
                first = first.next;
            }
            // Move first to the end, maintaining the gap
            while (first != null) {
                first = first.next;
                second = second.next;
            }
            second.next = second.next.next;
            return dummy.next;
        }
        
        // test
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(5);
            ListNode node5 = new ListNode(4);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(8);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            ListNode p = RemoveNthFromEnd1(node1, 3);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
