using System;
using System.Collections.Generic;

namespace LB_3_blog.Moldes;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? Brithday { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
