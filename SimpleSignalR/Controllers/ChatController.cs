using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SimpleSignalR.Controllers
{
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private static List<(string User, string Message)> _messages = new List<(string User, string Message)>();

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string user, string message)
        {
            _messages.Add((user, message));
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            ViewBag.Messages = _messages;
            return View();
        }
    }
}
