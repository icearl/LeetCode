using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**第61 右 k 个前移 Rotate List
 * Given a list, rotate the list to the right by k places, where k is non-negative.
     For example:
     Given 1->2->3->4->5->NULL and k = 2,
     return 4->5->1->2->3->NULL.
 
 */
//链表，倒数，用快慢指针
namespace LinkedList {
    class Rotate_List {
        //得到两段子链表的四个边界节点，然后接起来就好，这里用遍历来得到边界节点
        public ListNode RotateRight(ListNode head, int k) {
            if (head == null || head.next == null) {
                return head;
            }
            if (k <= 0) {
                return head;
            }
            ListNode dummy = new ListNode(-1);
            ListNode p = head;
            ListNode last = null;
            //获取链表长度 & 取得最后一个元素
            int num = 0;
            while (p != null) {
                num++;
                last = p;
                p = p.next;
            }
            //k是可以大于整个list的长度的，所以这时要对k对len取模如果取模之后得0，相当于不用rotate，直接返回
            k = k % num;
            if (k == 0) {
                return head;
            }
            // 左边有 prenum 个
            int prenum = num - k;
            // 得到左边的最后一个节点ppre & 右边第一个节点 p
            ListNode lLast = null;
            p = head;
            for (int i = 0; i < prenum; i++) {
                lLast = p;
                p = p.next;
            }
            dummy.next = p;
            lLast.next = null;
            last.next = head;
            return dummy.next;
        }
        // 和上面的思路一样，只是用快慢指针代替遍历 prenum 次
        public ListNode RotateRightII(ListNode head, int k) {
            if (head == null || head.next == null) {
                return head;
            }
            if (k <= 0) {
                return head;
            }
            ListNode dummy = new ListNode(-1);
            ListNode fast = head, slow = head, p = head;
            int num = 0;
            while (p != null) {
                num++;
                p = p.next;
            }
            //k是可以大于整个list的长度的，所以这时要对k对len取模如果取模之后得0，相当于不用rotate，直接返回
            int n = k % num;
            if (n == 0) {
                return head;
            }
            //先对faster设步长为n (然后faster和slower再一起走)
            for (int i = 0; i < n; i++) {
                fast = fast.next;
            }
            // 知道faster.next==null，说明slower指向要倒着数的开始点的前一个位置。
            while (fast.next != null) {
                fast = fast.next;
                slow = slow.next;
            }
            ListNode pre = slow;
            //slow.next就是要返回的newhead，保存一下。
            slow = slow.next;
            //faster.next接到head上
            fast.next = head;
            //pre.next存为null，作队尾。
            pre.next = null;
            dummy.next = slow;
            return dummy.next;
        }
        //把整个list连起来，变成环，找到切分点断开
        public static ListNode RotateRightIII(ListNode head, int k) {
            if (head == null || head.next == null) {
                return head;
            }
            if (k <= 0) {
                return head;
            }
            ListNode p = head;
            int num = 1;
            while (p.next != null) {
                num++;
                p = p.next;
            }
            p.next = head;
            int n = k % num;
            // 遍历到左边最后一个
            for (int i = 0; i < num - n; i++) {
                p = p.next;
            }
            head = p.next;
            p.next = null;
            return head;
        }
        // test
        public void main() {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            ListNode p = RotateRightII(node1, 2);
            while (p != null) {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
