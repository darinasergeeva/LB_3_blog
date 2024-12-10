using System;
using System.Collections.Generic;

namespace LB_3_blog;

public partial class Post
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime DateOfPublicati { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
