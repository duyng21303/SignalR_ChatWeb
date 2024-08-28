using System;
using System.Collections.Generic;

namespace SimpleSignalR.Models;

public partial class Chat
{
    public string User { get; set; } = null!;

    public string? Message { get; set; }
}
