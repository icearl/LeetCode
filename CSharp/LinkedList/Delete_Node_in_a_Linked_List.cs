using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 237. Delete Node in a Linked List
 * Write a function to delete a node(except the tail) in a singly linked list, given only access to that node.
 * Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.
*/

// 除了尾结点以外的删除方法，非常简单。用后面的节点覆盖这个值，然后跳过后面的那个节点就好了。
namespace LinkedList {
    //Definition for singly-linked list.
    //public class ListNode {
    //    public int val;
    //    public ListNode next;
    //    public ListNode(int x) { val = x; }
    //}

    class Delete_Node_in_a_Linked_List {
        public void DeleteNode(ListNode node) {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
