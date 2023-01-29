using System;
namespace task_management_system
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException() : base() { }
        public RoleNotFoundException(string message) : base(message) { }
    }
}