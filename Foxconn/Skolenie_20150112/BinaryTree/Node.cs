using System;

namespace BinaryTree
{
    public class Node<T> where T: IComparable<T>
    {
        private Node<T> _left = null;
        private Node<T> _right = null;

        private T _value;

        public Node(T value)
        {
            _value = value;
        }

        public bool HasValue(T value)
        {
            if (value.CompareTo(_value)==0)
            {
                return true;
            }
            else if (value.CompareTo(_value) > 0)
            {
                if (_right == null) return false;
                return _right.HasValue(value);
            } 
            else
            {
                if (_left == null) return false;
                return _left.HasValue(value);
            }
        }

        public void Vypis()
        {
            if(_left!=null) _left.Vypis();
            Console.WriteLine(_value + " ");
            if(_right!=null) _right.Vypis();
        }

        public void Insert(T value)
        {
            if (value.CompareTo(_value) < 0)
            {
                if (_left == null)
                {
                    _left = new Node<T>(value);
                }
                else
                {
                    _left.Insert(value);
                };
            }
            else if (value.CompareTo(_value) > 0)
            {
                if (_right == null)
                {
                    _right = new Node<T>(value);
                }
                else
                {
                    _right.Insert(value);
                }
            }
        }
    }
}
