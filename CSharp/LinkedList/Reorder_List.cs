using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//143 重排链表：链表倒序 快慢指针 合并链表
//Reorder List
namespace LinkedList {
    class Reorder_List {
        //链表长度分两半 + 前插法倒序 + 合并
        public static void ReorderList1(ListNode head) {
            if (head == null || head.next == null) {
                return;
            }
            //先计算链表的长度
            ListNode p = head;
            int num = 0;
            while (p != null) {
                num++;
                p = p.next;
            }
            //取半
            int length = num / 2;
            p = head;
            for (int i = 0; i < length - 1; i++) {
                p = p.next;
            }
            //利用前插法将后半部分倒序，newhead将指向后半部分的首部
            ListNode newHead = p.next;
            p.next = null;
            ListNode prev = null;
            while (newHead != null) {
                ListNode nextTemp = newHead.next;
                newHead.next = prev;

                prev = newHead;
                newHead = nextTemp;
            }
            //交替插入
            ListNode p1 = head;
            ListNode p2 = prev;
            ListNode ppre = null;
            while (p1 != null && p2 != null) {
                ListNode p1Next = p1.next;
                ListNode p2Next = p2.next;

                p1.next = p2;
                p2.next = p1Next;

                ppre = p1;

                p1 = p1Next;
                p2 = p2Next;
            }
            // 如果总数是奇数，这一步是必要的。
            ppre.next.next = p2;
        }
        // 快慢指针分两半 + 前插法倒序 + 合并
        // 利用快慢两个指针将链表一分为二，针对第二个子链表求倒序，最后将两个子链表合并。
        public static void ReorderList2(ListNode head) {
            if (head == null || head.next == null) {
                return;
            }

            // find the second half head
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null) {
                fast = fast.next.next;
                slow = slow.next;
            }

            // reverse the second half
            ListNode newHead = slow.next;
            slow.next = null; // cut the first half
            ListNode prev = null;
            while (newHead != null) {
                ListNode nextTemp = newHead.next;
                newHead.next = prev;
                prev = newHead;
                newHead = nextTemp;
            }

            // combine two halves
            ListNode l1 = head;
            ListNode l2 = prev;
            //ListNode ppre = null; 不用加这个，因为 l1 比 l2 多一个或两个元素
            while (l1 != null && l2 != null) {
                ListNode l1Next = l1.next;
                ListNode l2Next = l2.next;

                l1.next = l2;
                l2.next = l1Next;

                //ppre = l1;

                l1 = l1Next;
                l2 = l2Next;
            }
        }

        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            //ListNode node8 = new ListNode(8);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            //node7.next = node8;
            ReorderList2(node1);
            ListNode p = node1;
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
