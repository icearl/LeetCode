using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**第86题 链表分大小两半 Partition List   
 * Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

     You should preserve the original relative order of the nodes in each of the two partitions.
     For example,
     Given 1->4->3->2->5->2 and x = 3,
     return 1->2->2->4->3->5.
 */
namespace LinkedList {
    class Partition_List {
        public ListNode Partition(ListNode head, int x) {
            // 把小于的记录在一个链里，大于等于的记录在另一个链里，然后连起来
            ListNode nil_small = new ListNode(0);
            ListNode nil_big = new ListNode(0);
            ListNode nil = new ListNode(0);
            nil.next = head;
            ListNode p = nil.next, p1 = nil_small, p2 = nil_big;
            while(p != null) {
                if (p.val < x) {
                    p1.next = p;
                    p1 = p1.next;
                } else {
                    p2.next = p;
                    p2 = p2.next;
                }
                //Console.WriteLine("p1: " + p1.val);
                //Console.WriteLine("        p2: " + p2.val);
                p = p.next;
                
            }
            // 给两个链添加 null 尾巴
            if (p1 != null) {
                p1.next = null;
            }
            if (p2 != null) {
                p2.next = null;
            }
            // 如果一个链为空，直接输出另一个链
            if (nil_small.next == null) {
                return nil_big.next;
            }
            if (nil_big.next == null) {
                return nil_small.next;
            }
            //把两个链连起来
            p1.next = nil_big.next; 
            return nil_small.next;
        }
        public void main() {
            ListNode node1 = new ListNode(4);
            ListNode node2 = new ListNode(4);
            ListNode node3 = new ListNode(5);
            ListNode node4 = new ListNode(1);
            ListNode node5 = new ListNode(3);
            ListNode node6 = new ListNode(2);
            ListNode node7 = new ListNode(7);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            ListNode p = Partition(node1, 4);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
