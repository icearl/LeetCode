using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//83. Remove Duplicates from Sorted List
//Given a sorted linked list, delete all duplicates such that each element appear only once.

//For example,
//Given 1->1->2, return 1->2.
//Given 1->1->2->3->3, return 1->2->3.
namespace LinkedList {
    class Remove_Duplicates_from_Sorted_List {

        public ListNode DeleteDuplicates(ListNode head) {
            ListNode current = head;
            // 当元素 >= 2 个的时候，才需要比较
            while (current != null && current.next != null) {
                // 如果相等就跳过后面的
                if (current.next.val == current.val) {
                    current.next = current.next.next;
                } else {
                    current = current.next;
                }
            }
            return head;
        }

        //Definition for singly-linked list.
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(2);
            ListNode node4 = new ListNode(5);
            ListNode node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            ListNode p = DeleteDuplicates(node1);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
        // main 函数调用
        class __main {
            static void Main(string[] args) {
                var temp = new Remove_Duplicates_from_Sorted_List();
                temp.main();
            }
        }
    }
}
