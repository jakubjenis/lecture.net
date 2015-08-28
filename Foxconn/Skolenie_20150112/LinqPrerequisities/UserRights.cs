using System;
using System.ComponentModel.DataAnnotations;

namespace LinqPrerequisities
{
    [Flags]
    public enum UserRights
    {
        Login = 0x1,

        Edit = 0x2,

        [Display(Name="Delete user from database")]
        Delete = 0x4
    }
}