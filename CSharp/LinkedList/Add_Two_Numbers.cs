using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**第2题 模拟加法运算 Add Two Numbers
 * You are given two non-empty linked lists representing two non-negative integers.
 * The digits are stored in reverse order and each of their nodes contain a single digit.
 * Add the two numbers and return it as a linked list.
   You may assume the two numbers do not contain any leading zero, except the number 0 itself.
     Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
     Output: 7 -> 0 -> 8
 */

namespace LinkedList {
    class Add_Two_Numbers {
        // 从低位挨个往上加就好，主要是保存好指针和进位
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            // 如果一个为空，直接返回另一个作为和
            if (l1 == null) {
                return l2;
            }
            if (l2 == null) {
                return l1;
            }
            ListNode nil = new ListNode(-1);
            ListNode p1 = l1, p2 = l2, pre = nil;
            int carry = 0;
            while (p1 != null || p2 != null) {
                if (p1 != null) {
                    carry += p1.val;
                    p1 = p1.next;
                }
                if (p2 != null) {
                    carry += p2.val;
                    p2 = p2.next;
                }
                // 把这一位的数加上
                pre.next = new ListNode(carry % 10);
                // 往上进位
                carry = carry / 10;
                // 移动节点
                pre = pre.next;
            }
            if (carry == 1) {
                pre.next = new ListNode(1);
            }
            return nil.next;
        }
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
            //node4.next = node5;

            node5.next = node6;
            node6.next = node7;
            ListNode p = AddTwoNumbers(node1, node5);
            
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
