using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 206. Reverse a singly linked list.
*/

// 单链表倒序（前插法）
namespace LinkedList {
    class Reverse_Linked_List {
        // 迭代版本
        // Complexity analysis
        // Time complexity : O(n). Assume that nn is the list's length, the time complexity is O(n).
        // Space complexity : O(1).

        public ListNode ReverseListIterative(ListNode head) {
            //只有 1 个或 0 个就直接返回
            if (head == null || head.next == null) {
                return head;
            }
            //初始化
            ListNode prev = null;
            ListNode newHead = head;

            while (newHead != null) {
                // 存好下一个节点
                ListNode nextTemp = newHead.next;
                // 核心：把当前节点的 next 指向前一节点
                newHead.next = prev;
                // 调整指针，为下次迭代准备
                prev = newHead;
                newHead = nextTemp;
            }
            // 如果当前的是 null，说明到头了，返回 null 的前一个，即 prev
            return prev;
        }
        // 递归版本
        //Complexity analysis
        //Time complexity : O(n)O(n). Assume that nn is the list's length, the time complexity is O(n)O(n).
        //Space complexity : O(n)O(n). The extra space comes from implicit stack space due to recursion.The recursion could go up to nn levels deep.
        public ListNode ReverseListRecursive(ListNode head) {
            // 只有 1 个或 0 个就直接返回
            if (head == null || head.next == null) return head;
            // n1 → … → nk-1 → nk → nk+1 ← … ← nm
            // k + 1开始往后已经排好了，但 k 还是指向 k + 1
            ListNode p = ReverseListRecursive(head.next);
            // 把 k 加到后面排好的里面
            head.next.next = head;
            head.next = null;

            return p;
        }

        //public class ListNode {
        //    public int val;
        //    public ListNode next;
        //    public ListNode(int x) { val = x; }
        //}

        // 测试
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            ListNode p = ReverseListRecursive(node1);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
        // 主函数调用方法
        //class __main {
        //    static void Main(string[] args) {
        //        Reverse_Linked_List temp = new Reverse_Linked_List();
        //        temp.main();
        //    }
        //}
    }
}
