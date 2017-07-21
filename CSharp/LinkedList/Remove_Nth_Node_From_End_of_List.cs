using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 19 移除链表倒数第 n 个节点 Remove Nth Node From End of List 链表快慢指针
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
        // 倒数第 n 个就是正数第 length - n + 1  个
        // 遍历一次得到 length，再遍历一次得到第 length - n 个node，然后跳过 next 就好了
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
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

    }
}
