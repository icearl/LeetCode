using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//82. 把重复的全删掉，只留下没有重复过的数字 Remove Duplicates from Sorted List II
//Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.

//For example,
//Given 1->2->3->3->4->4->5, return 1->2->5.
//Given 1->1->1->2->3, return 2->3.

namespace LinkedList {
    class Remove_Duplicates_from_Sorted_ArrayII {
        public ListNode DeleteDuplicates(ListNode head) {
            if (head == null || head.next == null)
                return head;
            ListNode nil = new ListNode(-1);
            nil.next = head;
            ListNode p = nil;
            while (p.next != null && p.next.next != null) {
                if (p.next.val == p.next.next.val) {
                    //记录重复的值
                    int value = p.next.val;
                    //将有重复值的节点跳过，注意这里判断的是head.next的值，跳过的是next，从而将重复节点全部删除
                    while (p.next != null && p.next.val == value) {
                        p.next = p.next.next;
                    } 
                } else {
                    p = p.next;
                }
            }
            return nil.next;
        }
        // test
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(1);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(4);
            ListNode node6 = new ListNode(7);
            ListNode node7 = new ListNode(7);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            ListNode p = DeleteDuplicates(node1);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
