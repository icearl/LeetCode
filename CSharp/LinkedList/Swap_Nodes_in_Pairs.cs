using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**第24 成对对调链表节点 Swap Nodes in Pairs
 * Given a linked list, swap every two adjacent nodes and return its head.
     For example,
     Given 1->2->3->4, you should return the list as 2->1->4->3.
    Your algorithm should use only constant space. You may not modify the values in the list,
    only nodes itself can be changed.
 */
namespace LinkedList {
    class Swap_Nodes_in_Pairs {
        public ListNode SwapPairs(ListNode head) {
            //判断节点 >=2
            if(head == null || head.next == null) {
                return head;
            }
            //初始化
            ListNode nil = new ListNode(-1);
            nil.next = head;
            //定义三巨头
            ListNode pre = nil;
            ListNode first = nil.next;
            ListNode second = first.next;
            while(second != null) {
                ListNode nextFirst = second.next;
                ListNode nextSecond = null;
                if (nextFirst != null) {
                    nextSecond = nextFirst.next;
                }
                //节点next替换
                pre.next = second;
                second.next = first;
                first.next = nextFirst;
                //更新三巨头
                pre = first;
                first = nextFirst;
                second = nextSecond;
            }
            return nil.next;
        }
        // test
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(4);
            //ListNode node5 = new ListNode(5);
            //ListNode node6 = new ListNode(6);
            //ListNode node7 = new ListNode(7);
            node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;
            //node5.next = node6;
            //node6.next = node7;
            ListNode p = SwapPairs(node1);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
