using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//21. 合并两个有序链表 Merge Two Sorted Lists
namespace LinkedList {
    class Merge_Two_Sorted_Lists {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
            ListNode nil = new ListNode(-1);
            ListNode p = nil;
            // 定义两个指针（始终指向两个链的头部）
            ListNode pl1 = l1;
            ListNode pl2 = l2;
            // 依次取两个链头部的较小者
            while (pl1 != null && pl2 != null) {
                if (pl1.val < pl2.val) {
                    p.next = pl1;
                    pl1 = pl1.next;
                    p = p.next;
                } else {
                    p.next = pl2;
                    pl2 = pl2.next;
                    p = p.next;
                }
            }
            // 剩下的直接把非空的那个接到后面即可（另一个已经为空）
            if (pl1 == null) {
                p.next = pl2;
            } else if (pl2 == null) {
                p.next = pl1;
            }
            return nil.next;
        }

        //Definition for singly-linked list.
        //public class ListNode {
        //    public int val;
        //    public ListNode next;
        //    public ListNode(int x) { val = x; }
        //}

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
            //        node4.next=node5;
            node5.next = node6;
            node6.next = node7;
            ListNode p = MergeTwoLists(node1,node5);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
